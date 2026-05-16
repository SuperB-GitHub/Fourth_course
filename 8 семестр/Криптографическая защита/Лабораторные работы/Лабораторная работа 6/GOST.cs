using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static MyLibrary.MathUtils;
using static Лабораторная_работа_6.RSA;

namespace Лабораторная_работа_6
{
    public static class GOST
    {
        private static BigInteger GenEven(int bitLength)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[(bitLength + 7) / 8];
            rng.GetBytes(bytes);
            bytes[0] &= 0xFE;
            return new BigInteger(bytes, true, true);
        }
        public static (BigInteger p, BigInteger q) GenGOSTParam(int bitLength = 1024, int qBitLength = 256)
        {
            while (true)
            {
                BigInteger q = GenPrime(qBitLength);

                BigInteger minP = BigInteger.One << (bitLength - 1);
                BigInteger maxP = (BigInteger.One << bitLength) - 1;

                BigInteger t = GenEven(bitLength - qBitLength);
                BigInteger p = q * t + 1;

                int attempts = 0;
                while (p < minP || p > maxP || !IsPrime(p, 10))
                {
                    t += 2;
                    p = q * t + 1;
                    attempts++;
                    if (attempts > 10000) break; 
                }

                if (p >= minP && p <= maxP && IsPrime(p, 10))
                {
                    return (p, q);
                }
            }
        }
        public static BigInteger FindA(BigInteger p, BigInteger q)
        {
            for (BigInteger h = 2; h < p - 1; h++)
            {
                BigInteger a = BigInteger.ModPow(h, (p - 1) / q, p);

                if (a != 1 && BigInteger.ModPow(a, q, p) == 1)
                {
                    return a;
                }
            }

            throw new Exception("Не удалось найти образующий элемент a");
        }
        public static(BigInteger x, BigInteger y) GenKeys(BigInteger a, BigInteger p, BigInteger q)
        {
            BigInteger x = 0;
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[q.GetByteCount()];
            do
            {
                rng.GetBytes(bytes);
                x = new BigInteger(bytes, true);
            } while (x <= 0 || x >= q);

            BigInteger y = BigInteger.ModPow(a, x, p);

            return (x, y);
        }
        public static byte[] Gost94Hash(string input)
        {

            IDigest digest = new Gost3411Digest();

            byte[] byteInp = Encoding.UTF8.GetBytes(input);
            digest.BlockUpdate(byteInp, 0, byteInp.Length);
            byte[] result = new byte[digest.GetDigestSize()];
            digest.DoFinal(result, 0);
            return result;
        }

        public static(BigInteger r, BigInteger s) Sign(BigInteger hash, BigInteger x, BigInteger q, BigInteger p, BigInteger a)
        {
            if (hash == 0) hash = 1;

            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[q.GetByteCount()];
            BigInteger k = 0, r = 0, s = 0;

            do
            {
                do
                {
                    rng.GetBytes(bytes);
                    k = new BigInteger(bytes, true);
                } while (k <= 0 || k >= q);

                r = BigInteger.ModPow(a, k, p) % q;
            } while (r == 0);

            s = (x * r + k * hash) % q;
            if (s == 0) s = 1; 

            return (r, s);
        }
        public static bool Verify(BigInteger hash, BigInteger r, BigInteger s, BigInteger y, BigInteger q, BigInteger p, BigInteger a)
        {
            if (hash % q == 0) hash = 1;

            if (r <= 0 || r >= q || s <= 0 || s >= q)
                return false;

            BigInteger v = BigInteger.ModPow(hash, q - 2, q);
            BigInteger z1 = (s * v) % q;
            BigInteger z2 = ((q - r) * v) % q;

            BigInteger u = (BigInteger.ModPow(a, z1, p) * BigInteger.ModPow(y, z2, p)) % p;
            u = u % q;

            return u == r;
        }
    }
}
