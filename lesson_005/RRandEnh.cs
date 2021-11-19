using System;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

namespace GB_Q2_lesson005
{

    public static class RandomProvider
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        public static string GetThreadRandomStringValue(int min, int max)
        {
            return randomWrapper.Value.Next(min, max).ToString("D6");
        }
        public static uint GetThreadRandomUIntValue(int min, int max)
        {
            return (uint)(randomWrapper.Value.Next(min, max));
        }


    }

    public class KeyGenerator
    {
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        } // end_of_GetUniqueKey(int maxSize)
    
}

} // end_of_UtilitesRandom