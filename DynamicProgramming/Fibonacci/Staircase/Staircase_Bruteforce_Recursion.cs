using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Fibonacci.Staircase
{
    public class Staircase_Bruteforce_Recursion
    {
        public int CountWays(int n)
        {
            if (n == 0)
                return 1;   // we don't need to take any step, so there is only one way

            // n till < 3 would produce a -ve parameter for calls take1Step & take2Step, so
            // they need to be added as base conditions
            if (n == 1)
                return 1; // we can take one step to reach the end, and that is the only way

            if (n == 2)
                return 2; // we can take one step twice or jump two steps to reach at the top

            int take1Step = CountWays(n - 1);
            int take2Step = CountWays(n - 2);
            int take3Step = CountWays(n - 3);

            return take1Step + take2Step + take3Step;
        }
    }
}
