import Nat32 "mo:base/Nat32";
import List "mo:base/List";
import RBTree "mo:base/RBTree";
import Debug "mo:base/Debug";
import Bool "mo:base/Bool";
import Option "mo:base/Option";
import Int16 "mo:base/Int16";
import Iter "mo:base/Iter";
import Types "./types";
import Float "mo:base/Float";
import Principal "mo:base/Principal";
import HashMap "mo:base/HashMap";
import Error "mo:base/Error";
import Blob "mo:base/Blob";
import Text "mo:base/Text";
import Nat "mo:base/Nat";
import Nat64 "mo:base/Nat64";
import Time "mo:base/Time";
import Int "mo:base/Int";
import Nat8 "mo:base/Nat8";
import Array "mo:base/Array";


actor LoyaltyGame {
  //=========== DISTRUBUTION TIME ==========
  stable var isWeeklyCompetitionRunning : Bool = false;
  stable var lastRewardedSundayId : Nat = 0;
  stable var rewardAmount : Nat = 1_000_000_000;  //// Reward top 10 players with 10 ICP each

  // ========== TYPE ALIASES ==========
  type GameData = Types.GameData;
  type GameDataShared = Types.GameDataShared;
  type RankingResult = Types.RankingResult;
  type PRank = Types.PRank;
  type Account = {owner : Principal; subaccount : ?Blob;};
  type GameDataWithPrincipal = {principal : Principal; data : GameDataShared;};

  // ========== CONSTANTS ==========
  let INITIAL_CAPACITY = 16;
  let EMPTY_RANK : PRank = {name=""; isMale=true; rank=0; score=0; playerAddress=""};

  // ========== PLAYER DATA STORAGE ==========
  // Player data storage
  stable var playerDataStable : [(Principal, GameData)] = [];
  var playerData = HashMap.HashMap<Principal, GameData>(INITIAL_CAPACITY, Principal.equal, Principal.hash);

  // ========== SYSTEM METHODS ==========
  system func preupgrade() {
    playerDataStable := Iter.toArray(playerData.entries());
  };

  system func postupgrade() {
    // Rebuild player data
    playerData := HashMap.fromIter<Principal, GameData>(
      playerDataStable.vals(),
      INITIAL_CAPACITY,
      Principal.equal, 
      Principal.hash
    );
  };

  // ========== PLAYER MANAGEMENT ==========
  //remainder to make if possible if the player is already register reject the resgistration
  public shared(msg) func registerPlayer(name: Text, isMale: Bool) : async GameDataShared {
  if (Principal.isAnonymous(msg.caller)) {
    throw Error.reject("Anonymous users are not allowed to register.");
  };
  let user = msg.caller;

  switch (playerData.get(user)) {
    case (?existing) {
      // Player already registered — return their current shared data
      Debug.print("Player already exists");
      return toGameDataShared(existing);
    };
    case null {
      let userAddress = await getAccountAddress(user);
      // Register new player
      let newPlayer : GameData = {
        name = name;
        isMale = isMale;
        var score = 0;
        var rank = -99;
        playerAddress = userAddress;
      };
      playerData.put(user, newPlayer);
      recalculateRanks();
      return toGameDataShared(newPlayer);
    };
  };
};

  public shared(msg) func updatePlayerScore(newScore: Nat32) : async () {
    if (Principal.isAnonymous(msg.caller)) {
      throw Error.reject("Anonymous access not allowed.");
    };
    let caller = msg.caller;

    switch (playerData.get(caller)) {
      case (?data) {
        data.score := newScore;
        playerData.put(caller, data);
        Debug.print("Updated score: " # Nat32.toText(newScore));
        recalculateRanks(); // refresh rank after score update
      };
      case null {
        throw Error.reject("Player not found. Please register first.");
      };
    };
  };

  func recalculateRanks() {
    let allPlayers = Iter.toArray(playerData.entries());
    let sorted = Array.sort<(Principal, GameData)>(
      allPlayers,
      func((_, a : GameData), (_, b : GameData)) : {#less; #equal; #greater} {
        Nat32.compare(b.score, a.score)
      }
    );

    var i: Int = 1;
    for ((principal, data) in sorted.vals()) {
      data.rank := Int16.fromInt(i);
      playerData.put(principal, data);
      i += 1;
    };

    Debug.print("Recalculated ranks.");
  };

  public shared(msg) func getGameData() : async GameDataShared {
    if (Principal.isAnonymous(msg.caller)) {
      throw Error.reject("Anonymous access not allowed.");
    };

    let caller = msg.caller;

    await checkAndMaybeDistributeReward(); // reward distribution call

    switch (playerData.get(caller)) {
      case (?data) 
      {
        return toGameDataShared(data); // then return the data
      };
      case null { throw Error.reject("Player not found.");};
    }
  };

  func getTopRankingWithPrincipal() : async [GameDataWithPrincipal] {
    let allPlayers = Iter.toArray(playerData.entries());
    let sorted = Array.sort<(Principal, GameData)>(
      allPlayers,
      func((_, a), (_, b)) {
        Nat32.compare(b.score, a.score)
      }
    );

    let count = min(10, sorted.size());

    Array.tabulate<GameDataWithPrincipal>(
      count,
      func(i) {
        let (principal, data) = sorted[i];
        {
          principal = principal;
          data = toGameDataShared(data);
        }
      }
    )
  };

  public shared (msg) func getCurrentRanking() : async Types.PRank {
    let caller = msg.caller;

    if (Principal.isAnonymous(caller)) {
      throw Error.reject("Anonymous access not allowed.");
    };

    switch (playerData.get(caller)) {
      case (?data) {
        if (data.rank < 1) {
          recalculateRanks(); // Refresh ranks if the player's rank hasn't been set
        };
        {
          name = data.name;
          isMale = data.isMale;
          score = data.score;
          rank = data.rank;
          playerAddress = data.playerAddress;
        };
      };
      case null {
        throw Error.reject("Player not found. Please register first.");
      };
    };
  };

  public shared func getRanking(before: Nat32, after: Nat32, rank: Int16) : async RankingResult {
    let allPlayers = Iter.toArray(playerData.vals());
    // Sort players by descending score
    let sorted = Array.sort<GameData>(
      allPlayers,
      func(a, b) { Nat32.compare(b.score, a.score) } // descending
    );

    // Safely convert Nat32 to Int16 using range check
    func safeToInt16(n: Nat32) : Int16 {
      if (n <= 32_767) {
        Int16.fromNat16(Nat32.toNat16(n));
      } else {
        Int16.fromNat16(0);
      }
    };

    let beforeInt16 = safeToInt16(before);
    let afterInt16 = safeToInt16(after);

    // Helper to convert GameData → PRank
    func toPRank(g : GameData) : PRank {
      {
        name = g.name;
        isMale = g.isMale;
        score = g.score;
        rank = g.rank;
        playerAddress = g.playerAddress;
      }
    };

    var list = List.nil<PRank>();
    for (player in sorted.vals()) {
      if (player.rank >= rank - beforeInt16 and player.rank <= rank + afterInt16) {
        list := List.push(toPRank(player), list);
      };
    };

    { ranking = List.toArray(List.reverse(list)) }
  };

  //=========== DSTRUTUBION ON SUNDAY ============

  // Determines which Sunday "this week" corresponds to
  func getLatestSundayIdFromNow() : Nat {
    let now = Time.now();
    let secondsSinceEpoch = Int.abs(now) / 1_000_000_000;
    let daysSinceEpoch = secondsSinceEpoch / 86_400;

    // Unix epoch (Jan 1, 1970) was a Thursday, so Sunday = -3 offset
    let latestSundayDayIndex = (daysSinceEpoch - ((daysSinceEpoch + 3) % 7)) / 7;
    return latestSundayDayIndex; // Always positive Nat
  };

  public shared func checkAndMaybeDistributeReward() : async () {
    let sundayId = getLatestSundayIdFromNow();

    if (not isWeeklyCompetitionRunning) {
      isWeeklyCompetitionRunning := true;
      lastRewardedSundayId := sundayId;
      Debug.print("Competition started on Sunday ID: " # Nat.toText(sundayId));
      return;
    }
    else
    {
      // if (sundayId == lastRewardedSundayId) {
      if (sundayId > lastRewardedSundayId) {
        Debug.print("Distributing reward for new week. Sunday ID: " # Nat.toText(sundayId));

        await rewardTop10(rewardAmount); //rewaring top 10 player

        lastRewardedSundayId := sundayId;
        Debug.print("Reward given and marked for Sunday ID: " # Nat.toText(sundayId));
      } else {
        Debug.print("Reward already distributed for the latest Sunday or Wait till next sunda.");
      };
    };
  };


  // ========== LEDGER INTERACTION ==========
  func rewardTop10(amountPerPlayerE8s: Nat) : async () {
    let topPlayers = await getTopRankingWithPrincipal();
    for (player in topPlayers.vals()) {
      Debug.print("Sending to: " # player.data.name);
      try {
        let blockIndex = await sendIcp(player.principal, amountPerPlayerE8s);
        Debug.print("Sent to " # player.data.name # " | Block: " # Nat.toText(blockIndex));
      } catch (e) {
        Debug.print("Failed for " # player.data.name # ": " # Error.message(e));
      };
    };
  };

  let ledger : actor {
    icrc1_balance_of : shared Account -> async Nat;
  } = actor("ryjl3-tyaaa-aaaaa-aaaba-cai"); // ICP Ledger canister on local network

  // Balance in e8s (1 ICP = 100 000 000 e8s)
  func getMyCanisterBalance() : async Nat {
    let account : Account = {
      owner      = Principal.fromActor(LoyaltyGame);
      subaccount = null;
    };

    // This awaits the remote ledger call and returns the Nat result.
    await ledger.icrc1_balance_of(account)
  };

  public shared func getMyCanisterBalanceTxt() : async Text {
    let e8s : Nat = await getMyCanisterBalance();
    let whole      = e8s / 100_000_000;
    let fractional = e8s % 100_000_000;
    // pad the fractional part to 8 digits
    let fracTxt  = Nat.toText(fractional);
    let padded   = repeatChar("0", 8 - fracTxt.size()) # fracTxt;
    Debug.print(Nat.toText(whole) # "." # padded # " ICP" );
    Nat.toText(whole) # "." # padded # " ICP"
  };

  let ledgerAccountIdentifier : actor {
    account_identifier : shared Account -> async Blob;
  } = actor("ryjl3-tyaaa-aaaaa-aaaba-cai"); // ICP Ledger canister on local network

  func getAccountAddress(userPrincipal: Principal) : async Text {
    let account : Account = {
      owner = userPrincipal;
      subaccount = null;
    };

    let blob : Blob = await ledgerAccountIdentifier.account_identifier(account);
    blobToHex(blob)
  };

  // ========== UTILITIES ==========
  func toGameDataShared(data: GameData) : GameDataShared {
    {
      name = data.name;
      isMale = data.isMale;
      score = data.score;
      rank = data.rank;
      playerAddress = data.playerAddress;
    }
  };

  func blobToHex(b : Blob) : Text {
    let bytes = Blob.toArray(b);
    Array.foldLeft<Nat8, Text>(bytes, "", func (acc, byte) {
      acc # byteToHex(byte)
    })
  };

  func byteToHex(n : Nat8) : Text {
    let hexChars = "0123456789abcdef";
    let hi = Nat8.toNat(n / 16);
    let lo = Nat8.toNat(n % 16);

    func charAt(txt: Text, idx: Nat) : Char {
      var i = 0;
      for (c in txt.chars()) {
        if (i == idx) return c;
        i += 1;
      };
      return '\u{0}';
    };

    Text.fromChar(charAt(hexChars, hi)) # Text.fromChar(charAt(hexChars, lo))
  };

  func repeatChar(c: Text, n: Nat) : Text {
    var result = "";
    var i = 0;
    while (i < n) {
      result := result # c;
      i += 1;
    };
    result
  };

  // ========== TRANSFER TOKEN ==========
  let ledgerTransfer : actor {
    icrc1_transfer: shared {
      from_subaccount: ?Blob;
      to: {
        owner: Principal;
        subaccount: ?Blob;
      };
      amount: Nat;
      fee: ?{ e8s: Nat };
      memo: ?Blob;
      created_at_time: ?{ timestamp_nanos: Nat64 };
    } -> async {
      #Ok : Nat;
      #Err : {
        #GenericError : { message : Text; error_code : Nat };
        #TemporarilyUnavailable : {};
        #BadBurn : { min_burn_amount : Nat };
        #Duplicate : { duplicate_of : Nat };
        #BadFee : { expected_fee : Nat };
        #CreatedInFuture : { ledger_time : Nat64 };
        #TooOld : {};
        #InsufficientFunds : { balance : Nat };
      };
    };
  } = actor("ryjl3-tyaaa-aaaaa-aaaba-cai");  // Official ICP Ledger canister ID

  func sendIcp(to: Principal, amountE8s: Nat) : async Nat {
    let transferResult = await ledgerTransfer.icrc1_transfer({
      from_subaccount = null;
      to = {
        owner = to;
        subaccount = null;
      };
      amount = amountE8s;
      fee = ?{ e8s = 10_000 };
      memo = null;
      created_at_time = ?{ timestamp_nanos = Nat64.fromNat(Int.abs(Time.now())) };
    });

    switch (transferResult) {
      case (#Ok blockIndex) blockIndex;
      case (#Err err) {
        Debug.print("Transfer failed: " # debug_show(err));
        throw Error.reject("ICP transfer failed.");
      };
    };
  };

  func partition(l: List.List<GameData>, score: Nat32) : (List.List<GameData>, List.List<GameData>) {
    switch l {
      case null { (null, null) };
      case (?(h, t)) 
      {
        if (h.score >= score) 
        {
          // call f in-order
          let (l, r) = partition(t, score);
          (?(h, l), r)
        } 
        else 
        {
          let (l, r) = partition(t, score);
          (l, ?(h, r))
        }
      }
    }
  };

  func toNat16(n: Nat32) : ?Int16 
  {
    if (n <= 32_767) 
    {  // Ensure the value is within the range of Int16
      return Option.make(Int16.fromNat16(Nat32.toNat16(n)));  // Convert Nat to Int16
    } 
    else 
    {
      return null;  // Return null if the value is out of range
    }
  };

  func toPRank(rank : ?GameData) : PRank
  {
    switch (rank) 
    {
      case (?rank) return {name = rank.name; isMale = rank.isMale; rank = rank.rank; score = rank.score; playerAddress = rank.playerAddress};
      case (null) return EMPTY_RANK;
    };
  };

  public shared func ping() : async () {
  // No-op: used to check canister availability
  };

  func min(a: Nat, b: Nat) : Nat = if (a < b) a else b;
  func max(a: Int16, b: Int16) : Int16 = if (a > b) a else b;
};