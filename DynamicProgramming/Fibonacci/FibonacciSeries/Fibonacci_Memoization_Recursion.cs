using System;
using System.Net.Http.Headers;

namespace DynamicProgramming.Fibonacci.FibonacciSeries
{
    public class Fibonacci_Memoization_Recursion
    {
        public int CalculateFibonacci(int n)
        {
            int?[] cache = new int?[n + 1]; // n+1 is to include n itself

            return CalculateFibonacciRecursive(cache, n);
        }

        public int CalculateFibonacciRecursive(int?[] cache, int n)
        {
            if (n < 2)
            {
                return n;
            }

            if (cache[n].HasValue)
            {
                Console.WriteLine("Cache hit");
                return cache[n].Value;
            }

            cache[n] = CalculateFibonacciRecursive(cache, n - 1) + CalculateFibonacciRecursive(cache, n - 2);

            return cache[n].Value;
        }
    }
}
