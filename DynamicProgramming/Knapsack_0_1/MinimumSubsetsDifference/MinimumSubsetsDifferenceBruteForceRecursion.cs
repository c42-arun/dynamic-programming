using System;

namespace DynamicProgramming.Knapsack_0_1.MinimumSubsetsDifference
{
    public class MinimumSubsetsDifferenceBruteForceRecursion
    {
        private int _steps = 0;

        public int GetMinimumDifferenceFromTwoSubsets(int[] nums)
        {
            if (nums.Length < 2) return -1;

            var diff = FindMinimumDifference(nums, 0, 0, 0);

            Console.WriteLine($"No of recursive calls: {_steps}");

            return diff;
        }

        private int FindMinimumDifference(int[] nums, int s1, int s2, int currentIndex)
        {
            if (currentIndex == nums.Length)
            {
                return Math.Abs(s1 - s2);
            }

            // path 1 - include current number in S1
            int s1Sum = FindMinimumDifference(nums,s1 + nums[currentIndex], s2, currentIndex + 1);

            // path 2 - include current number in S2
            int s2Sum = FindMinimumDifference(nums, s1, s2 + nums[currentIndex], currentIndex + 1);

            _steps++;
            return Math.Min(s1Sum, s2Sum);
        }
    }
}
