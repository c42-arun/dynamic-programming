using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Fibonacci.Staircase
{
    public class Staircase_Memoization
    {
        public int CountWays(int n)
        {
            int?[] cache = new int?[n+1];

            return CountWaysRecursive(n, cache);
        }

        private int CountWaysRecursive(int n, int?[] cache)
        {
            if (cache[n].HasValue)
            {
                Console.WriteLine($"Cache hit for {n}");
                return cache[n].Value;
            }

            if (n == 0)
                return 1;   // we don't need to take any step, so there is only one way

            // n till < 3 would produce a -ve parameter for calls take1Step & take2Step, so
            // they need to be added as base conditions
            if (n == 1)
                return 1; // we can take one step to reach the end, and that is the only way

            if (n == 2)
                return 2; // we can take one step twice or jump two steps to reach at the top

            int take1Step = CountWaysRecursive(n - 1, cache);
            int take2Step = CountWaysRecursive(n - 2, cache);
            int take3Step = CountWaysRecursive(n - 3, cache);

            cache[n] = take1Step + take2Step + take3Step;

            return cache[n].Value;
        }
    }
}
