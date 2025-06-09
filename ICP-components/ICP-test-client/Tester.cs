
using System.Threading.Tasks;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;

public class Tester
{
    private ClimateWalletApiClient climateClient;
    private PRank currentRank;

    public Tester(ClimateWalletApiClient climateClient)
    {
        this.climateClient = climateClient;
    }

    public async Task UpdateCurrentRank()
    {
        currentRank = await climateClient.GetCurrentRanking();
    }

    public async Task SetScoreAsync(uint score)
    {
        Console.WriteLine(string.Format("Set score to {0} for rank {1}", score, currentRank.Rank));
        await climateClient.Set(score);
        await UpdateCurrentRank();
    }

    public async Task printRanking(uint before, uint after)
    {
        if (currentRank != null)
        {
            Console.WriteLine($"Current ranking for {currentRank.Name}: #{currentRank.Rank} {currentRank.Score}");
        }
        else
        {
            Console.WriteLine("No rank");
        }

        RankingResult result = await climateClient.GetRanking(before, after, currentRank.Rank);
        for (int i = 0; i < result.Ranking.Count; i++)
        {
            PRank pRank = result.Ranking[i];
            if (pRank.Name.Equals(currentRank.Name))
            {
                currentRank = pRank;
            }
            Console.WriteLine(string.Format("#{0} {1} ({2})", pRank.Rank.ToString(), pRank.Name, pRank.Score.ToString()));
        }
    }
}

public class ByteListToStringConversion //only for testing, convertion of byte[] to string
{
    private List<byte> data;

    public ByteListToStringConversion(List<byte> inData)
    {
        this.data = inData;
    }


    public string GetString()
    {
        // return System.Text.Encoding.UTF8.GetString(data.ToArray());
        return Convert.ToBase64String(data.ToArray());
    }
}

public class ByteArrayToStringConversion //only for testing, convertion of byte[] to string
{
    private byte[] data;

    public ByteArrayToStringConversion(byte[] inData)
    {
        this.data = inData;
    }


    public string ToString()
    {
        // return System.Text.Encoding.UTF8.GetString(data.ToArray());
        return Convert.ToBase64String(data.ToArray());
    }
}