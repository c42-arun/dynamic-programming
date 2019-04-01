using DynamicProgramming.Knapsack;
using DynamicProgramming.SubsetSum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProgramming.EqualSubsets;
using DynamicProgramming.MinimumSubsetsDifference;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nKnapsack 0/1");

            KnapsackBruteForce();
            KnapsackMemoization();
            KnapsackBottomUp();

            Console.WriteLine("\nEqual Subset Sum Partition:");

            EqualSubsetsBruteForce();
            EqualSubsetsMemoization();
            EqualSubsetsBottomUp();

            Console.WriteLine("\nEqual Subsets Sum:");

            EqualSubsetSumBruteForce();
            EqualSubsetSumMemoization();
            EqualSubsetSumBottomupTabulation();

            Console.WriteLine("\nMinimum subsets difference:");

            MinimumSubsetsDifferenceBruteForce();

            Console.ReadLine();
        }

        #region Knapsack

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

            var knapsack = new Knapsack_bottomup_tabulation(profits, weights, 7);

            int maxProfit = knapsack.FindMaxProfit();

            Console.WriteLine($"Maximum profit by bottom up approach is: {maxProfit}");
        }

        #endregion Knapsack

        #region Equal Subsets

        public static void EqualSubsetsBruteForce()
        {
            int[] nums = new[] { 6, 10, 16 };

            var equalSubsets = new EqualSubsets_bruteforce_recursion();

            bool equalSubsetsExist = equalSubsets.CanPartition(nums);

            Console.WriteLine($"Brute Force: Does equal subsets exist?: {(equalSubsetsExist ? "Yes" : "No")}");
        }

        public static void EqualSubsetsMemoization()
        {
            int[] nums = new[] { 6, 10, 16 };

            var equalSubsets = new EqualSubsets_memoization_recursion();

            bool equalSubsetsExist = equalSubsets.CanPartition(nums);

            Console.WriteLine($"Memoization: Does equal subsets exist?: {(equalSubsetsExist ? "Yes" : "No")}");
        }

        public static void EqualSubsetsBottomUp()
        {
            int[] nums = new int[] { 2, 4, 6, 8 };

            EqualSubsets_bottomup es = new EqualSubsets_bottomup();

            bool equalSubsetsExist = es.CanPartition(nums);

            Console.WriteLine($"Brute Force: Does equal subsets exist?: {(equalSubsetsExist ? "Yes" : "No")}");
        }

        #endregion

        #region Equal Subsets Sum

        public static void EqualSubsetSumBruteForce()
        {
            int[] nums = new int[] { 1, 2, 3, 7 };

            SubsetSumBruteForceRecursion ss = new SubsetSumBruteForceRecursion();

            bool canFind = ss.CanFindSubsetToSum(nums, 13);

            Console.WriteLine($"Can find a subset with sum? {(canFind ? "Yes" : "No")}");
        }

        public static void EqualSubsetSumMemoization()
        {
            int[] nums = new int[] { 1, 2, 3, 7 };

            SubsetSumMemoizationRecursion ss = new SubsetSumMemoizationRecursion();

            bool canFind = ss.CanFindSubsetToSum(nums, 13);

            Console.WriteLine($"Can find a subset with sum? {(canFind ? "Yes" : "No")}");
        }

        public static void EqualSubsetSumBottomupTabulation()
        {
            int[] nums = new int[] { 1, 2, 3, 7 };

            SubsetSumBottomupTabulation ss = new SubsetSumBottomupTabulation();

            bool canFind = ss.CanFindSubsetToSum(nums, 13);

            Console.WriteLine($"Can find a subset with sum? {(canFind ? "Yes" : "No")}");
        }

        #endregion

        #region Minimum subsets difference

        public static void MinimumSubsetsDifferenceBruteForce()
        {
            MinimumSubsetsDifferenceBruteForceRecursion m = new MinimumSubsetsDifferenceBruteForceRecursion();

            int[] nums = { 1, 2, 3, 9 };
            int minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Minimum subsets difference is {minDiff}");

            nums = new int[] { 1, 2, 7, 1, 5 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Minimum subsets difference is {minDiff}");
            
            nums = new int[] { 1, 3, 100, 4 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Minimum subsets difference is {minDiff}");
        }


        #endregion
    }
}
