
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;

public class Tester {
    private ClimateWalletApiClient climateClient;
    private PRank currentRank;

    public Tester(ClimateWalletApiClient climateClient)
    {
        this.climateClient = climateClient;
    }

    public void Init() {
        Task<PRank> task = climateClient.GetCurrentRanking();
        task.Wait();
        currentRank = task.Result;
    }

    public async Task setScoreAsync(uint score) {
        Console.WriteLine(string.Format("Set score to {0} for rank {1}", score, currentRank.Rank));
        await climateClient.Set(score);
    }

    public async void printRanking(uint before, uint after) {
        if (currentRank != null) {
            Console.WriteLine($"Current ranking for {currentRank.Name}: #{currentRank.Rank} {currentRank.Score}");
        } else {
            Console.WriteLine("No rank");
        }

        RankingResult result = await climateClient.GetRanking(before, after, currentRank.Rank);
        for (int i=0; i<result.Ranking.Count; i++) {
            PRank pRank = result.Ranking[i];
            if (pRank.Name.Equals(currentRank.Name)) {
                currentRank = pRank;
            }
            Console.WriteLine(string.Format("#{0} {1} ({2})", pRank.Rank.ToString(), pRank.Name, pRank.Score.ToString()));
            // Console.WriteLine(string.Format("{0}", pRank.Name));
        }
    }
}