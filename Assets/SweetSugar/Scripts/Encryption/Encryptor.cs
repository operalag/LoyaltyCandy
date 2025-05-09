using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GemEncryption
{
    public static class Encryptor
    {
        private static readonly string part1Key = "MySuper"; //obfuscating
        private static readonly string part2Key = "SecretKey";
        private static readonly string part3Key = "123!";

        private static readonly string part0IV = "ThisIsA";
        private static readonly string part1IV = "16ByteIV!";

        private static readonly byte[] Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(part1Key + part2Key + part3Key));
        private static readonly byte[] IV = Encoding.UTF8.GetBytes(part0IV + part1IV);

        public static byte[] Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using var encryptor = aes.CreateEncryptor(aes.Key,aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);
            sw.Flush();
            cs.FlushFinalBlock();
            return ms.ToArray();
        }

        public static string Decrypt(byte[] ciperText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(ciperText);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        public static void SaveCoins(int coinAmount, bool useEncryption = true)
        {
            byte[] data;
            byte header = useEncryption ? (byte)1 : (byte)0;

            if(useEncryption)
            {
                data = Encrypt(coinAmount.ToString());
            }
            else
            {
                data = Encoding.UTF8.GetBytes(coinAmount.ToString());
            }

            byte[] dataWithHeader = new byte[data.Length + 1];

            dataWithHeader[0] = header;
            Buffer.BlockCopy(data, 0, dataWithHeader, 1, data.Length);

            //string path = Application.persistentDataPath + "/coins.dat";
            string path = @"C:\Users\Scientist\Documents\Project\Personal\Encryption_cs\EncriptedFile\custom_coins.dat"; 
            File.WriteAllBytes(path, dataWithHeader);
        }

        public static int LoadCoins()
        {
            //string path = Application.persistentDataPath + "/coins.dat";
            string path = @"C:\Users\Scientist\Documents\Project\Personal\Encryption_cs\EncriptedFile\custom_coins.dat";
            if (!File.Exists(path)) return 0;

            byte[] fileBytes = File.ReadAllBytes(path);
            if(fileBytes.Length < 2) return 0;

            byte header = fileBytes[0];
            byte[] data = new byte[fileBytes.Length - 1];
            Buffer.BlockCopy(fileBytes, 1, data, 0, data.Length);

            string result = header switch
            {
                1 => Decrypt(data),
                0 => Encoding.UTF8.GetString(data),
                _ => throw new InvalidDataException("Unknown encrytion header.")
            };

            return int.TryParse(result, out int coins) ? coins : 0;
        }
    }
}