import Nat32 "mo:base/Nat32";
import Nat16 "mo:base/Nat16";
import Int16 "mo:base/Int16";

module {

    public type Rank = Int16;
    public type PlayerName = Text;
    public type Score = Nat32;
    public type PlayerAddress = Text;

    public type GameData = {
        name: PlayerName;
        isMale: Bool;
        var rank: Rank;
        var score: Score;
        playerAddress : Text;
        rewarded : Bool;
    };

    public type GameDataShared = {
    name: Text;
    isMale: Bool;
    score: Nat32;
    rank: Int16;
    playerAddress: Text;
    rewarded : Bool;
    };

    public type PRank = {
        name: PlayerName;
        isMale: Bool;
        rank: Rank;
        score: Score;
        playerAddress : Text;
        rewarded : Bool;
    };

    public type RankingResult = {
        ranking: [PRank];
    };
}
