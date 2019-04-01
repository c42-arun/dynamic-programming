using DynamicProgramming.Knapsack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProgramming.EqualSubsets;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //KnapsackBruteForce();
            //KnapsackMemoization();
            //KnapsackBottomUp();

            EqualSubsetsBruteForce();
            EqualSubsetsMemoization();

            Console.ReadLine();
        }

        #region Knapsack 1/0

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

        #endregion

        #region Equal Subsets
        public static void EqualSubsetsBruteForce()
        {
            int[] nums = new[] { 8, 10, 16 };

            var equalSubsets = new EqualSubsets_bruteforce_recursion();

            bool exists = equalSubsets.ContainsEqualSubsets(nums);

            Console.WriteLine($"Brute Force: Does equal subsets exist?: {(exists ? "Yes" : "No")}");
        }

        public static void EqualSubsetsMemoization()
        {
            int[] nums = new[] { 6, 10, 16 };

            var equalSubsets = new EqualSubsets_memoization_recursion();

            bool exists = equalSubsets.ContainsEqualSubsets(nums);

            Console.WriteLine($"Memoization: Does equal subsets exist?: {(exists ? "Yes" : "No")}");
        }

        #endregion
    }
}
