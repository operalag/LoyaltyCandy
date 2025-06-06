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

actor LoyaltyGame {

  // ========== TYPE ALIASES ==========
  type RankingResult = Types.RankingResult;
  type PlayerRank = Types.PlayerRank;
  type PRank = Types.PRank;
  type Rank = Types.Rank;
  type PlayerName = Types.PlayerName;
  type GameData = Types.GameData;
  
  // ========== CONSTANTS ==========
  let EMPTY_RANK : PRank = {name=""; rank=0; score=0;};
  let INITIAL_CAPACITY = 16;

  // ========== STORAGE ==========
  // Player data storage
  stable var playerDataStable : [(Principal, GameData)] = [];
  var playerData = HashMap.HashMap<Principal, GameData>(INITIAL_CAPACITY, Principal.equal, Principal.hash);

  // Ranking system
  stable var players = List.nil<PlayerRank>();
  var currentPlayerRank : PlayerRank = {name = "No one"; var score = 0; var rank = -1;};
  var initRanks = false;
  var ranking = RBTree.RBTree <Int16, PlayerRank>(Int16.compare);

   // ========== SYSTEM METHODS ==========
  system func preupgrade() 
  {
    playerDataStable := Iter.toArray(playerData.entries());
  };

  system func postupgrade() 
  {
    // Rebuild player data
    playerData := HashMap.fromIter<Principal, GameData>(
      playerDataStable.vals(),
      INITIAL_CAPACITY,
      Principal.equal, 
      Principal.hash
      );
      
      // Rebuild ranking if needed
      if (not initRanks and List.size(players) > 0) 
      {
        for (item in List.toIter(players)) 
        {
          ranking.put(item.rank, item);
        };
        initRanks := true;
      };
    };

    // ========== PLAYER DATA MANAGEMENT ==========
  // Called when the player sets or updates their data
  public shared(msg) func writeGameData(isMale: Bool, gem: Float) : async () 
  {
    if (Principal.isAnonymous(msg.caller))
    {
      throw Error.reject("Anonymous access is not allowed.");
    };

    let user = msg.caller;
    let data : GameData = { isMale = isMale; gem = gem };
    playerData.put(user, data);
    
    // Update stable storage
    playerDataStable := Iter.toArray(playerData.entries());
    Debug.print("Data saved for: " # Principal.toText(user));
  };

   // Called when the game loads — returns the player's data
  public shared(msg) func readGameData() : async ?GameData 
  {
    if (Principal.isAnonymous(msg.caller)) 
    {
      throw Error.reject("Anonymous access is not allowed.");
    };

    let user = msg.caller;
    Debug.print("Fetching data for: " # Principal.toText(user));
    return playerData.get(user);
  };



  func fullRanking() : List.List<PlayerRank> 
  {
    var list: List.List<PlayerRank> = List.nil<PlayerRank>();

    let namgay:PlayerRank = { name = "Namgay"; var score = 10008; var rank = 1};
    list := List.push(namgay, list);

    let tashi:PlayerRank = { name = "Tashi"; var score = 1008; var rank = 2};
    list := List.push(tashi, list);

    let ugyentshewang:PlayerRank = { name = "Ugyen Tshewang"; var score = 954; var rank = 3};
    list := List.push(ugyentshewang, list);

    let yeshi:PlayerRank = { name = "Yeshi"; var score = 856; var rank = 4};
    list := List.push(yeshi, list);

    let pema:PlayerRank = { name = "Pema"; var score = 345; var rank = 5};
    list := List.push(pema, list);

    let passang:PlayerRank = { name = "Passang"; var score = 322; var rank = 6};
    list := List.push(passang, list);

    let nima:PlayerRank = { name = "Nima"; var score = 322; var rank = 7};
    list := List.push(nima, list);

    let casper:PlayerRank = { name = "Casper"; var score = 231; var rank = 8};
    
    currentPlayerRank := casper;
    Debug.print("initialising curent player rank");
    Debug.print(debug_show currentPlayerRank);

    list := List.push(casper, list);
    
    let ugyenrinzin:PlayerRank = { name = "Ugyen Rinzin"; var score = 125; var rank = 9};
    list := List.push(ugyenrinzin, list);

    let tezay:PlayerRank = { name = "Tezay"; var score = 89; var rank = 10};
    list := List.push(tezay, list);

    list;
  };

  func min(a: Nat, b: Nat) : Nat 
  {
    if (a < b)
    {
      a
    } 
    else 
    {
      b
    }
  };

  func max(a: Int16, b: Int16) : Int16 {
    if (a > b) 
    {
      a
    } 
    else 
    {
      b
    }
  };

  func partition(l: List.List<PlayerRank>, score: Nat32) : (List.List<PlayerRank>, List.List<PlayerRank>) {
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

  func toPRank(rank : ?PlayerRank) : PRank
  {
    switch (rank) 
    {
      case (?rank) return {name = rank.name; rank = rank.rank; score = rank.score};
      case (null) return EMPTY_RANK;
    };
    
  };

  func checkRanks() 
  {
    if (List.size(players) == 0) 
    {
      Debug.print("Initializing players");
      players := fullRanking();
    };

    if (not initRanks) 
    {
      Debug.print("Initializing ranking");
      for(item in List.toIter(players)) 
      {
        ranking.put(item.rank, item);        
      };
      initRanks := true;
    };
  };

  public shared func getRanking(before: Nat32, after: Nat32, rank: Int16) : async RankingResult 
  {
    checkRanks();

    var list = List.nil<PRank>();
    let value = toNat16(before);
    let bInt = switch (value) 
    {
      case (?value) value;
      case (null) Int16.fromNat16(0);
    };

    if (rank > 1) 
    {
      var start = max(1, rank - bInt);
      while (start < rank) 
      {
        let pr = toPRank(ranking.get(start));
        if (pr != EMPTY_RANK) 
        {
          list := List.append(list, List.push(pr, List.nil<PRank>()));
        };
        start := start + 1;
      };
    };

    let currentRank = ranking.get(rank);
    let pr = toPRank(currentRank);

    if (pr != EMPTY_RANK) 
    {
      list := List.append(list, List.push(pr, List.nil<PRank>()));
    };

    var start = rank + 1;
    let value2 = toNat16(after);

    let bInt2 = switch (value2) 
    {
      case (?value2) value2;
      case (null) Int16.fromNat16(0);
    };

    var end = rank + bInt2;

    while (start <= end) 
    {
      let pr = toPRank(ranking.get(start));

      if (pr != EMPTY_RANK)
      {
        list := List.append(list, List.push(pr, List.nil<PRank>()));
      };
      start := start + 1;
    };

    let result: RankingResult = {ranking = List.toArray(list)};
    result
  };
  
  public shared func inc() : async () 
  { 
    let _ = await set(currentPlayerRank.score + 1);
  };

  public shared func read() : async Nat32 { currentPlayerRank.score };

  public shared func bump() : async Nat32 
  {
    await set(currentPlayerRank.score + 1);
  };

  func updateRanking(pRank: PlayerRank, value: Nat32) 
  {
      // let rank = ranking.get(pRank.rank);
      // switch (rank) {
      //   case (?rank) {
      //     let up = rank.score < pRank.score;
      //     Debug.print("going up");
      //     Debug.print(debug_show up);
      //     Debug.print(debug_show rank.score);
      //     Debug.print(debug_show pRank.score);
      //     rank.score := pRank.score;
      //     if (up) {
      //       moveUp(rank);
      //     } else {
      //       moveDown(rank);
      //     };
      //   };
      //   case (null) ();
      // };
    let up = pRank.score < value;
    Debug.print("going up");
    Debug.print(debug_show up);
    Debug.print(debug_show value);
    Debug.print(debug_show pRank.score);
    pRank.score := value;
    if (up) 
    {
      moveUp(pRank);
    } else 
    {
      moveDown(pRank);
    };

  };

  func moveUp(pRank: PlayerRank) 
  {
      var rankNumber: Int16 = pRank.rank-1;
      if (rankNumber > 0) 
      {
        let upperRank = ranking.get(rankNumber);
        switch (upperRank) 
        {
          case (?upperRank)
            if (upperRank.score < pRank.score) 
            {
              ranking.delete(pRank.rank);
              ranking.delete(rankNumber);
              
              let tmp = pRank.rank;
              pRank.rank := upperRank.rank;
              upperRank.rank := tmp;

              ranking.put(pRank.rank, pRank);
              ranking.put(upperRank.rank, upperRank);

              moveUp(pRank);
            };
          case (null) ();
        };
      };
  };

  func moveDown(pRank: PlayerRank)
  {
      var rankNumber: Int16 = pRank.rank+1;
      let lowerRank = ranking.get(rankNumber);
      switch (lowerRank) 
      {
        case (?lowerRank)
          if (lowerRank.score > pRank.score) 
          {
            ranking.delete(pRank.rank);
            ranking.delete(rankNumber);
            
            let tmp = pRank.rank;
            pRank.rank := lowerRank.rank;
            lowerRank.rank := tmp;

            ranking.put(pRank.rank, pRank);
            ranking.put(lowerRank.rank, lowerRank);

            moveDown(pRank);
          };
        case (null) 
        {
          // reached bottom
          // ranking.delete(pRank.rank);
          // // add to the bottom
          // pRank.rank := rankNumber;
          // ranking.put(pRank.rank, pRank);
        };
      };
  };

  public shared func set(value : Nat32) : async Nat32 
  {
    let _ = updateRanking(currentPlayerRank, value);
    currentPlayerRank.score
  };

  // using direct ref to Type so the client generation code doesn't generate an additional class
  public shared func getCurrentRanking() : async Types.PRank 
  {
    if (currentPlayerRank.rank < 1) 
    {
      if (List.size(players) == 0) 
      {
        checkRanks();
      } 
      else 
      {
        let _ = fullRanking();        
      };
    };

    let current = {name = currentPlayerRank.name; rank = currentPlayerRank.rank; score = currentPlayerRank.score;};
    current
  };
};

