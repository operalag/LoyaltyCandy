using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace GemEncryption
{
    public static class Encryptor 
    {
        public delegate void DataDecryption();
        public static event DataDecryption OnFailDecryption;

        // Split key components for basic obfuscation
        private static readonly string part1Key = "MySuper";
        private static readonly string part2Key = "SecretKey";
        private static readonly string part3Key = "123!";
        private static readonly string part4Key = "Dynamic";

        // Split IV components
        private static readonly string part0IV = "ThisIsA";
        private static readonly string part1IV = "16ByteIV!";

        // Dynamic elements
        private static string DeviceSalt => $"{SystemInfo.deviceUniqueIdentifier}{SystemInfo.deviceName}";

        // Generate dynamic key with device-specific salt
        private static byte[] GetEncryptionKey()
        {
            string combinedKey = $"{part1Key}{part2Key}{part3Key}{part4Key}{DeviceSalt}";
            using SHA256 sha = SHA256.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(combinedKey));
        }

        // Generate dynamic IV with device-specific salt
        private static byte[] GetEncryptionIV()
        {
            string combinedIV = $"{part0IV}{part1IV}{DeviceSalt}";
            byte[] ivBytes = Encoding.UTF8.GetBytes(combinedIV);
            // Ensure IV is exactly 16 bytes
            Array.Resize(ref ivBytes, 16);
            return ivBytes;
        }

        public static byte[] Encrypt<T>(T obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                string payload = $"{DateTime.UtcNow.Ticks}|{json}";

                using Aes aes = Aes.Create();
                aes.Key = GetEncryptionKey();
                aes.IV = GetEncryptionIV();

                using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(payload);
                }

                byte[] encrypted = ms.ToArray();

                // Add HMAC for integrity checking
                using HMACSHA256 hmac = new HMACSHA256(GetEncryptionKey());
                byte[] hmacHash = hmac.ComputeHash(encrypted);

                return hmacHash.Concat(encrypted).ToArray();
            }
            catch
            {
                // OnFailDecryption?.Invoke();
                return Array.Empty<byte>();
            }
        }

        public static T Decrypt<T>(byte[] data)
        {
            try
            {
                // Verify minimum length (HMAC-SHA256 is 32 bytes)
                if (data.Length < 32)
                {
                    OnFailDecryption?.Invoke();
                    return default;
                }

                // Split HMAC and cipher text
                byte[] hmac = data.Take(32).ToArray();
                byte[] cipherText = data.Skip(32).ToArray();

                // Verify HMAC
                using HMACSHA256 hmacChecker = new HMACSHA256(GetEncryptionKey());
                byte[] expected = hmacChecker.ComputeHash(cipherText);

                if (!expected.SequenceEqual(hmac))
                {
                    OnFailDecryption?.Invoke();
                    return default;
                }

                using Aes aes = Aes.Create();
                aes.Key = GetEncryptionKey();
                aes.IV = GetEncryptionIV();

                using var decryptor = aes.CreateDecryptor();
                using var ms = new MemoryStream(cipherText);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);
                string decrypted = sr.ReadToEnd();

                // Split timestamp and actual data
                int separatorIndex = decrypted.IndexOf('|');
                if (separatorIndex < 0) throw new Exception("Missing timestamp");
                
                string timestampStr = decrypted[..separatorIndex];
                string json = decrypted[(separatorIndex + 1)..];

                // Verify timestamp is reasonable
                if (!long.TryParse(timestampStr, out long ticks)) throw new Exception("invelid timestamp");
                if (DateTime.UtcNow - new DateTime(ticks, DateTimeKind.Utc) > TimeSpan.FromDays(30)) // Adjust as needed
                {
                    OnFailDecryption?.Invoke();
                    return default;
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                Debug.LogError($"SaveCoins error: {e.Message}");
                return default;
            }
        }

        public static void SaveCoins<T>(T data, string key = "default")
        {
            try
            {
                byte[] bytes = Encrypt(data);
            
                if (bytes == null || bytes.Length == 0)
                {
                    Debug.LogError("Failed to encrypt coin data");
                    return;
                }
                string path = GetPath(key);
                File.WriteAllBytes(path, bytes);

                    // for player prefabs
                // string base64Data = Convert.ToBase64String(bytes);
                // PlayerPrefs.SetString("Gemss", base64Data);
                // PlayerPrefs.Save();


            }
            catch (Exception e)
            {
                Debug.LogError($"SaveCoins error: {e.Message}");
            }
        }

        public static T LoadCoins<T>(string key = "default")
        {
            try
            {
                string path = GetPath(key);
                if (!File.Exists(path)) return default;
                byte[] fileBytes = File.ReadAllBytes(path);
                return Decrypt<T>(fileBytes) ;

                //for player prefabs
                // if(!PlayerPrefs.HasKey("Gemss")) return default;
                // string base64Data = PlayerPrefs.GetString("Gemss");
                // byte[] encryptedBytes = Convert.FromBase64String(base64Data);
                // return Decrypt<T>(encryptedBytes);
            }
            catch (Exception e)
            {
                Debug.LogError($"LoadCoins error: {e.Message}");
                return default;
            }
        }

        private static string GetPath(string key)
        {
            string saltKey = $"data_{key}_{DeviceSalt}";
            string fileName = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(saltKey)))
                .Replace("/", "_").Replace("+", "-")[..16];
            return Path.Combine(Application.persistentDataPath, $"{fileName}.dat");
        }
    }
}