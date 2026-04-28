using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static MyLibrary.MathUtils;

namespace Лабораторная_работа_6
{
    public static class RSA
    {
        public static BigInteger GenPrime(int bits)
        {
            BigInteger candidate;
            do
            {
                byte[] bytes = new byte[bits / 8 + 1];
                Random.Shared.NextBytes(bytes);
                bytes[bytes.Length - 1] |= 0x80;
                bytes[0] |= 0x01;
                candidate = new BigInteger(bytes);
                if (candidate < 0) candidate = -candidate;
            } while (!IsPrime(candidate, 10));
            return candidate;
        }
        public static byte[] SHA256Hash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                return sha256.ComputeHash(inputBytes);
            }
        }
        public static BigInteger BytesToBigInteger(byte[] bytes)
        {
            byte[] padded = new byte[bytes.Length + 1];
            Array.Copy(bytes, 0, padded, 0, bytes.Length);
            padded[bytes.Length] = 0;
            return new BigInteger(padded);
        }
        public static BigInteger SignHash(byte[] hash, BigInteger d, BigInteger n)
        {
            BigInteger hashInt = BytesToBigInteger(hash);
            return BigInteger.ModPow(hashInt, d, n);
        }
        public static bool VerifySignature(byte[] hash, BigInteger signature, BigInteger e, BigInteger n)
        {
            BigInteger hashInt = BytesToBigInteger(hash);
            BigInteger decryptedHash = BigInteger.ModPow(signature, e, n);

            byte[] decryptedBytes = decryptedHash.ToByteArray();

            int minLength = Math.Min(hash.Length, decryptedBytes.Length);
            for (int i = 0; i < minLength && i < 32; i++)
            {
                if (hash[i] != decryptedBytes[i])
                    return false;
            }
            return true;
        }
    }
}
