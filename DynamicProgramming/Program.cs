using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProgramming.Knapsack_0_1.EqualSubsets;
using DynamicProgramming.Knapsack_0_1.Knapsack;
using DynamicProgramming.Knapsack_0_1.MinimumSubsetsDifference;
using DynamicProgramming.Knapsack_0_1.SubsetsCount;
using DynamicProgramming.Knapsack_0_1.SubsetSum;
using DynamicProgramming.Knapsack_0_1.TargetSum;
using DynamicProgramming.UnboundedKnapsack;
using DynamicProgramming.UnboundedKnapsack.CoinChange;
using DynamicProgramming.UnboundedKnapsack.Knapsack;
using DynamicProgramming.UnboundedKnapsack.MinimumCoinChange;
using DynamicProgramming.UnboundedKnapsack.RodCutting;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\nKnapsack 0/1 => Knapsack");
            //KnapsackBruteForce();
            //KnapsackMemoization();
            //KnapsackBottomUp();

            //Console.WriteLine("\nKnapsack 0/1 => Equal Subset Sum Partition:");
            //EqualSubsetsBruteForce();
            //EqualSubsetsMemoization();
            //EqualSubsetsBottomUp();

            //Console.WriteLine("\nKnapsack 0/1 => Equal Subsets Sum:");
            //EqualSubsetSumBruteForce();
            //EqualSubsetSumMemoization();
            //EqualSubsetSumBottomupTabulation();

            //Console.WriteLine("\nKnapsack 0/1 => Minimum subsets difference:");
            //MinimumSubsetsDifferenceBruteForce();
            //MinimumSubsetsDifferenceMemoization();
            //MinimumSubsetsDifferenceBottomupTabulation();

            //Console.WriteLine("\nKnapsack 0/1 => Subsets count:");
            //SubsetsCountBruteForce();
            //SubsetsCountMemoization();
            //SubsetsCountTabulation();

            //Console.WriteLine("\nKnapsack 0/1 => Target Sum:");
            //TargetSum();

            //Console.WriteLine("\nUnbounded Knapsack: Knapsack");
            //UnboundedKnapsackBruteForce();
            //UnboundedKnapsackMemoization();
            //UnboundedKnapsackTabulation();

            //Console.WriteLine("\nUnbounded Knapsack: Rod Cutting");
            //RodCuttingBruteForce();
            //RodCuttingMemoization();
            //RodCuttingTabulation();

            //Console.WriteLine("\nUnbounded Knapsack: Coin Change");
            //CoinChangeBruteForce();
            //CoinChangeMemoization();
            //CoinChangeTabulation();

            Console.WriteLine("\nUnbounded Knapsack: Minimum Coin Change");
            MinimumCoinChangeBruteForce();
            MinimumCoinChangeMemoization();
            MinimumCoinChangeTabulation();

            Console.ReadLine();
        }

        #region Knapsack 0/1 pattern

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
            var m = new MinimumSubsetsDifferenceBruteForceRecursion();

            int[] nums = { 1, 2, 3, 9 };
            int minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 1: Minimum subsets difference is {minDiff}\n");

            nums = new int[] { 1, 2, 7, 1, 5 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 2: Minimum subsets difference is {minDiff}\n");
            
            nums = new int[] { 1, 3, 100, 4 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 3: Minimum subsets difference is {minDiff}\n");
        }

        public static void MinimumSubsetsDifferenceMemoization()
        {
            var m = new MinimumSubsetsDifferenceMemoizationRecursion();

            int[] nums = { 1, 2, 3, 9 };
            int minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 1: Minimum subsets difference is {minDiff}\n");

            nums = new int[] { 1, 2, 7, 1, 5 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 2: Minimum subsets difference is {minDiff}\n");

            nums = new int[] { 1, 3, 100, 4 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 3: Minimum subsets difference is {minDiff}\n");
        }

        public static void MinimumSubsetsDifferenceBottomupTabulation()
        {
            var m = new MinimumSubsetsDifferenceBottomupTabulation();

            int[] nums = { 1, 2, 3, 9 };
            int minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 1: Minimum subsets difference is {minDiff}\n");

            nums = new int[] { 1, 2, 7, 1, 5 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 2: Minimum subsets difference is {minDiff}\n");

            nums = new int[] { 1, 3, 100, 4 };
            minDiff = m.GetMinimumDifferenceFromTwoSubsets(nums);
            Console.WriteLine($"Set 3: Minimum subsets difference is {minDiff}\n");
        }

        #endregion

        #region Subsets Count
        public static void SubsetsCountBruteForce()
        {
            var m = new SubsetsCountBruteForceRecursion();

            int[] nums = { 1, 1, 2, 3 };
            int count = m.CountOfSubsetsThatCouldSum(nums, 4);
            Console.WriteLine($"Set 1: Subsets that add up to the sum are {count}\n");

            nums = new int[]{ 1, 2, 7, 1, 5 };
            count = m.CountOfSubsetsThatCouldSum(nums, 8);
            Console.WriteLine($"Set 2: Subsets that add up to the sum are {count}\n");
        }
        public static void SubsetsCountMemoization()
        {
            var m = new SubsetsCountMemoizationRecursion();

            int[] nums = { 1, 1, 2, 3 };
            int count = m.CountOfSubsetsThatCouldSum(nums, 4);
            Console.WriteLine($"Set 1: Subsets that add up to the sum are {count}\n");

            nums = new int[] { 1, 2, 7, 1, 5 };
            count = m.CountOfSubsetsThatCouldSum(nums, 8);
            Console.WriteLine($"Set 2: Subsets that add up to the sum are {count}\n");
        }

        public static void SubsetsCountTabulation()
        {
            var m = new SubsetsCountTabulation();

            int[] nums = { 1, 1, 2, 3 };
            int count = m.CountOfSubsetsThatCouldSum(nums, 4);
            Console.WriteLine($"Set 1: Subsets that add up to the sum are {count}\n");

            nums = new int[] { 1, 2, 7, 1, 5 };
            count = m.CountOfSubsetsThatCouldSum(nums, 8);
            Console.WriteLine($"Set 2: Subsets that add up to the sum are {count}\n");
        }

        #endregion

        #region Target Sum 

        public static void TargetSum()
        {
            var m = new TargetSum();

            int[] nums = { 1, 2, 7, 1 };
            int count = m.FindTargetSubsets(nums, 9);
            Console.WriteLine($"Set 1: Subsets that add up to the sum are {count}\n");

            nums = new[] {1, 1, 2, 3};
            count = m.FindTargetSubsets(nums, 1);
            Console.WriteLine($"Set 2: Subsets that add up to the sum are {count}\n");

        }
        #endregion

        #endregion Knapsack 0/1 pattern

        #region Unbounded Knapsack pattern

        #region Unbounded Knapsack

        public static void UnboundedKnapsackBruteForce()
        {
            int[] profits = new[] { 15, 50, 60, 90 };
            int[] weights = new[] { 1, 3, 4, 5 };
            int capacity = 8;

            var unboundedKnapsack = new UnboundedKnapsack_Recursion();

            int maxProfit = unboundedKnapsack.SolveKnapsack(profits, weights, capacity);

            Console.WriteLine($"Unbounded Knapsack: Maximum profit by brute force is:  {maxProfit}");
        }

        public static void UnboundedKnapsackMemoization()
        {
            int[] profits = new[] { 15, 50, 60, 90 };
            int[] weights = new[] { 1, 3, 4, 5 };
            int capacity = 8;

            var unboundedKnapsack = new UnboundedKnapsack_Memoization();

            int maxProfit = unboundedKnapsack.SolveKnapsack(profits, weights, capacity);

            Console.WriteLine($"Unbounded Knapsack: Maximum profit by memoization is:  {maxProfit}");
        }

        public static void UnboundedKnapsackTabulation()
        {
            int[] profits = new[] { 15, 50, 60, 90 };
            int[] weights = new[] { 1, 3, 4, 5 };
            int capacity = 8;

            var unboundedKnapsack = new UnboundedKnapsack_Tabulation();

            int maxProfit = unboundedKnapsack.SolveKnapsack(profits, weights, capacity);

            Console.WriteLine($"Unbounded Knapsack: Maximum profit by bottom up tabulation is:  {maxProfit}");
        }

        #endregion

        #region Rod Cutting
        private static void RodCuttingBruteForce()
        {
            RodCutting_Recursion rc = new RodCutting_Recursion();
            int[] lengths = { 1, 2, 3, 4, 5 };
            int[] prices = { 2, 6, 7, 10, 13 };
            int maxProfit = rc.SolveRodCutting(lengths, prices, 5);

            Console.WriteLine($"Rod cutting: Maximum profit by brute force is:  {maxProfit}");
        }

        private static void RodCuttingMemoization()
        {
            RodCutting_Memoization rc = new RodCutting_Memoization();
            int[] lengths = { 1, 2, 3, 4, 5 };
            int[] prices = { 2, 6, 7, 10, 13 };
            int maxProfit = rc.SolveRodCutting(lengths, prices, 5);

            Console.WriteLine($"Rod cutting: Maximum profit by memoization is:  {maxProfit}");
        }

        private static void RodCuttingTabulation()
        {
            RodCutting_Tabulation rc = new RodCutting_Tabulation();
            int[] lengths = { 1, 2, 3, 4, 5 };
            int[] prices = { 2, 6, 7, 10, 13 };
            int maxProfit = rc.SolveRodCutting(lengths, prices, 5);

            Console.WriteLine($"Rod cutting: Maximum profit by tabulation is:  {maxProfit}");
        }

        #endregion

        #region Coin Change
        private static void CoinChangeBruteForce()
        {
            CoinChange_Recursion ch = new CoinChange_Recursion();
            int[] denominations = { 1, 2, 3 };

            int numOfWays = ch.CountChange(denominations, 5);

            Console.WriteLine($"Coin Change: Num of ways by brute force is:  {numOfWays}");
        }

        private static void CoinChangeMemoization()
        {
            CoinChange_Recursion ch = new CoinChange_Recursion();
            int[] denominations = { 5, 10, 20, 50 };

            int numOfWays = ch.CountChange(denominations, 1050);

            Console.WriteLine($"Coin Change: Num of ways by memoization is:  {numOfWays}");
        }

        private static void CoinChangeTabulation()
        {
            CoinChange_Tabulation ch = new CoinChange_Tabulation();
            int[] denominations = { 5, 10, 20, 50 };

            int numOfWays = ch.CountChange(denominations, 1050);

            Console.WriteLine($"Coin Change: Num of ways by tabulation is:  {numOfWays}");
        }

        #endregion

        #region Minimum Coin Change

        #endregion
        private static void MinimumCoinChangeBruteForce()
        {
            MinimumCoinChange_Recursion ch = new MinimumCoinChange_Recursion();
            int[] denominations = { 1, 2, 3 };

            int minCoinChange = ch.CoinChange(denominations, 11);

            Console.WriteLine($"Minimum Coin Change: Num of ways by brute force is:  {minCoinChange}");
        }

        private static void MinimumCoinChangeMemoization()
        {
            var ch = new MinimumCoinChange_Memoization();
            int[] denominations = { 1, 2, 3 };

            int minCoinChange = ch.CoinChange(denominations, 11);

            Console.WriteLine($"Minimum Coin Change: Num of ways by memoization is:  {minCoinChange}");
        }

        private static void MinimumCoinChangeTabulation()
        {
            var ch = new MinimumCoinChange_Tabulation();
            int[] denominations = { 1, 2, 3 };

            int minCoinChange = ch.CoinChange(denominations, 11);

            Console.WriteLine($"Minimum Coin Change: Num of ways by tabulation is:  {minCoinChange}");
        }

        #endregion
    }
}
