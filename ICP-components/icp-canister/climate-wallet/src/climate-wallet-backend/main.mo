import Nat32 "mo:base/Nat32";
import List "mo:base/List";
import RBTree "mo:base/RBTree";
import Debug "mo:base/Debug";
import Bool "mo:base/Bool";
import Option "mo:base/Option";
import Text "mo:base/Text";
import Int16 "mo:base/Int16";
import Array "mo:base/Array";
import Iter "mo:base/Iter";
import Nat16 "mo:base/Nat16";
import Nat64 "mo:base/Nat64";
import Types "./types";

actor LoyaltyGame {
  type RankingResult = Types.RankingResult;
  type PlayerRank = Types.PlayerRank;
  type PRank = Types.PRank;
  type Rank = Types.Rank;
  type PlayerName = Types.PlayerName;

  stable var players = List.nil<PlayerRank>();
  var ranking = RBTree.RBTree <Int16, PlayerRank>(Int16.compare);
  var count : Nat32 = 0;
  var currentPlayerRank : PlayerRank = {name = "No one"; var score = 0; var rank = -1;};
  let EMPTY_RANK :PRank = {name=""; rank=0; score=0;};

  func fullRanking() : List.List<PlayerRank> {
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
    list := List.push(casper, list);
    let ugyenrinzin:PlayerRank = { name = "Ugyen Rinzin"; var score = 125; var rank = 9};
    list := List.push(ugyenrinzin, list);
    let tezay:PlayerRank = { name = "Tezay"; var score = 89; var rank = 10};
    list := List.push(tezay, list);

    list;
  };

  func min(a: Nat, b: Nat) : Nat {
    if (a < b) {
      a
    } else {
      b
    }
  };

  func max(a: Int16, b: Int16) : Int16 {
    if (a > b) {
      a
    } else {
      b
    }
  };

  func partition(l: List.List<PlayerRank>, score: Nat32) : (List.List<PlayerRank>, List.List<PlayerRank>) {
    switch l {
      case null { (null, null) };
      case (?(h, t)) {
        if (h.score >= score) {
          // call f in-order
          let (l, r) = partition(t, score);
          (?(h, l), r)
        } else {
          let (l, r) = partition(t, score);
          (l, ?(h, r))
        }
      }
    }
  };

  func toNat16(n: Nat32) : ?Int16 {
    if (n <= 32_767) {  // Ensure the value is within the range of Int16
        return Option.make(Int16.fromNat16(Nat32.toNat16(n)));  // Convert Nat to Int16
    } else {
        return null;  // Return null if the value is out of range
    }
  };

  func toPRank(rank : ?PlayerRank) : PRank {
    switch (rank) {
      case (?rank) return {name = rank.name; rank = rank.rank; score = rank.score};
      case (null) return EMPTY_RANK;
    };
    
  };

  public shared func getRanking(before: Nat32, after: Nat32, rank: Int16) : async RankingResult {
    if (List.size(players) == 0) {
      players := fullRanking();
      for(item in List.toIter(players)) {
        ranking.put(item.rank, item);        
      };
    };

    var list = List.nil<PRank>();
    let currentRank = ranking.get(rank);
    let value = toNat16(before);
    let bInt = switch (value) {
      case (?value) value;
      case (null) Int16.fromNat16(0);
    };

    if (rank > 1) {
      var start = max(1, rank - bInt);
      while (start < rank) {
        let pr = toPRank(ranking.get(start));
        if (pr != EMPTY_RANK) {
          list := List.append(list, List.push(pr, List.nil<PRank>()));
        };
        start := start + 1;
      };
    };

    let pr = toPRank(currentRank);
    if (pr != EMPTY_RANK) {
      list := List.append(list, List.push(pr, List.nil<PRank>()));
    };

    var start = rank + 1;
    let value2 = toNat16(after);
    let bInt2 = switch (value2) {
      case (?value2) value2;
      case (null) Int16.fromNat16(0);
    };
    var end = rank + bInt2;
    while (start <= end) {
      let pr = toPRank(ranking.get(start));
      if (pr != EMPTY_RANK) {
        list := List.append(list, List.push(pr, List.nil<PRank>()));
      };
      start := start + 1;
    };

    let result: RankingResult = {ranking = List.toArray(list)};
    result
  };
  
  public shared func inc() : async () { count += 1 };

  public shared func read() : async Nat32 { count };

  public shared func bump() : async Nat32 {
    count += 1;
    count;
  };

  func updateRanking(pRank: PlayerRank) : async ()
  {
      // var index:Nat = 0;
      // var found : Bool = false;
      // let _ = List.iterate(ranking, func(rank : PlayerRank) {
      //   if (rank.name == name) {
      //     rank.score := score;
      //     found := true;
      //   };
      //   if (not(found)) {
      //     index := index + 1;
      //   };
      // });

      // if (found) {
      //   let currentRank = List.get<PlayerRank>(ranking, index);
      //   switch (currentRank) {
      //     case (?currentRank) moveUp(currentRank, index);
      //     case (null) ();
      //   };        
      // };
      moveUp(pRank);
  };

  func moveUp(pRank: PlayerRank) {
      var rankNumber: Int16 = pRank.rank-1;
      if (rankNumber > 0) {
        let upperRank = ranking.get(rankNumber);
        switch (upperRank) {
          case (?upperRank)
            if (upperRank.score < pRank.score) {
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

  public shared func set(value : Nat32) : async Nat32 {
    count := value;
    currentPlayerRank.score := count;
    let _ = updateRanking(currentPlayerRank);
    count;
  };
};

