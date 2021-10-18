using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilites_Random
{
    public static class RandomProvider
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        public static string  GetThreadRandomStringValue(int min , int max)
        {
            return randomWrapper.Value.Next(min, max).ToString("D6");
        }
        public static uint GetThreadRandomUIntValue(int min, int max)
        {
            return (uint)(randomWrapper.Value.Next(min, max));
        }

    }
}
