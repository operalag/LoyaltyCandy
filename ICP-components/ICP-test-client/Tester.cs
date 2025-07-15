
using System.Threading.Tasks;
using LoyaltyCandy.ClimateWallet;
using LoyaltyCandy.ClimateWallet.Models;

public class Tester
{
    private ClimateWalletApiClient climateClient;
    private GameDataShared currentRank;

    public Tester(ClimateWalletApiClient climateClient)
    {
        this.climateClient = climateClient;
    }

    public async Task UpdateCurrentRank()
    {
        currentRank = await climateClient.GetGameData();
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
                currentRank = gameDataShared(pRank);
            }
            Console.WriteLine(string.Format("#{0} {1} ({2})", pRank.Rank.ToString(), pRank.Name, pRank.Score.ToString()));
        }
    }

    public GameDataShared gameDataShared(PRank pRank)
    {
        return new GameDataShared
        {
            Rank = pRank.Rank,
            Name = pRank.Name,
            Score = pRank.Score,
            IsMale = pRank.IsMale
        };
    }
    
    public static string GenerateRandomName(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
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

