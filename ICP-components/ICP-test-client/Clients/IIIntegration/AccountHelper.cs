using EdjCase.ICP.Candid.Models;
using AccountIdentifier = System.Collections.Generic.List<System.Byte>;
using Force.Crc32;
using System.Security.Cryptography;

public static class AccountHelper
{
    public static AccountIdentifier FromPrincipal(Principal principal, byte[]? subAccount = null)
    {
        subAccount ??= new byte[32]; // Default subaccount (all zeroes)

        byte[] principalBytes = principal.Raw; // CBOR encoding
        using var sha = SHA256.Create();

        // Create the hash input: 0x0A + principalBytes + subAccount
        List<byte> input = new List<byte> { 0x0A };
        input.AddRange(principalBytes);
        input.AddRange(subAccount);

        // Compute the hash (SHA224)
        byte[] hash = sha.ComputeHash(input.ToArray());

        // Compute checksum
        byte[] checksum = BitConverter.GetBytes(Crc32Algorithm.Compute(hash)).Reverse().ToArray();

        // Final result: checksum + hash = 32-byte AccountIdentifier
        byte[] accountIdBytes = checksum.Concat(hash).ToArray();

        return new AccountIdentifier(accountIdBytes);
    }
}
