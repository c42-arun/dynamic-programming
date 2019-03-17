using DynamicProgramming.Knapsack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            KnapsackBruteForce();
            KnapsackMemoization();
            KnapsackBottomUp();

            Console.ReadLine();
        }

        public static void KnapsackBruteForce()
        {
            int[] profits = new[] { 1, 6, 10, 16 };
            int[] weights = new[] { 1, 2, 3, 5 };

            var knapsack = new Knapsack_bruteforce_recursion(profits, weights, 7);

            int maxProfit = knapsack.FindMaxProfit();

            Console.WriteLine($"Maximum profit by brute force is:  {maxProfit}");
        }

        public static void KnapsackMemoization()
        {
            int[] profits = new[] { 1, 6, 10, 16 };
            int[] weights = new[] { 1, 2, 3, 5 };

            var knapsack = new Knapsack_memoization_recursion(profits, weights, 7);

            int maxProfit = knapsack.FindMaxProfit();

            Console.WriteLine($"Maximum profit by memoization is: {maxProfit}");
        }

        public static void KnapsackBottomUp()
        {
            int[] profits = new[] { 1, 6, 10, 16 };
            int[] weights = new[] { 1, 2, 3, 5 };

            var knapsack = new Knapsack_bottomup(profits, weights, 7);

            int maxProfit = knapsack.FindMaxProfit();

            Console.WriteLine($"Maximum profit by bottom up approach is: {maxProfit}");
        }
    }
}
