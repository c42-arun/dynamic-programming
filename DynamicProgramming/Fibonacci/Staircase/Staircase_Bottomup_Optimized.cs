using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Fibonacci.Staircase
{
    // BottomUp approach makes Fib series most obvious
    public class Staircase_Bottomup_Optimized
    {
        public int CountWays(int n)
        {
            if (n < 2) return 1;
            if (n == 2) return 2;

            int a = 2;
            int b = 1;
            int c = 1;

            int ret = 0;


            for (int i = 3; i <= n; i++)
            {
                ret = a + b + c;
                c = b;
                b = a;
                a = ret;
            }

            return ret;
        }
    }
}
