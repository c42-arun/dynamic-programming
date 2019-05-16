using System;
using System.Net.Http.Headers;

namespace DynamicProgramming.Fibonacci.FibonacciSeries
{
    public class Fibonacci_BottomUp
    {
        public int CalculateFibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }

            int n1 = 1;
            int n2 = 0;
            int fib = 0;

            for (int i = 2; i <= n; i++)
            {
                fib = n1 + n2;
                n2 = n1;
                n1 = fib;
            }

            return fib;
        }
    }
}
