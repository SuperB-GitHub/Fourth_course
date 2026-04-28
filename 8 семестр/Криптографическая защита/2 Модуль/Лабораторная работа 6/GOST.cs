using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace Лабораторная_работа_6
{
    public static class GOST
    {
        public static byte[] Gost94Hash(string input)
        {

            IDigest digest = new Gost3411Digest();

            byte[] byteInp = Encoding.UTF8.GetBytes(input);
            digest.BlockUpdate(byteInp, 0, byteInp.Length);
            byte[] result = new byte[digest.GetDigestSize()];
            digest.DoFinal(result, 0);
            return result;
        }
        public static string Gost94Hash(string input, int var = 1)
        {

            IDigest digest = new Gost3411Digest();

            byte[] byteInp = Encoding.UTF8.GetBytes(input);
            digest.BlockUpdate(byteInp, 0, byteInp.Length);
            byte[] result = new byte[digest.GetDigestSize()];
            digest.DoFinal(result, 0);
            return Convert.ToHexString(result);
        }
    }
}
