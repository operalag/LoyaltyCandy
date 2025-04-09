import Nat32 "mo:base/Nat32";
import Nat16 "mo:base/Nat16";
import Int16 "mo:base/Int16";

module {

public type Rank = Int16;
public type PlayerName = Text;
public type Score = Nat32;

public type PlayerRank = {
    name: PlayerName;
    var rank: Rank;
    var score: Score;
};

public type PRank = {
    name: PlayerName;
    rank: Rank;
    score: Score;
};

public type RankingResult = {
    ranking: [PRank];
};

}
