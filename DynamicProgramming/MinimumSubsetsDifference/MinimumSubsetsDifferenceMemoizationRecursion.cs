using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.MinimumSubsetsDifference
{
    public class MinimumSubsetsDifferenceMemoizationRecursion
    {
        private int?[,] memoCache;
        private int _steps = 0;

        public int GetMinimumDifferenceFromTwoSubsets(int[] nums)
        {
            if (nums.Length < 2) return -1;

            memoCache = new int?[nums.Length, nums.Sum() + 1];

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

            if (memoCache[currentIndex, s1].HasValue) return memoCache[currentIndex, s1].Value;
            if (memoCache[currentIndex, s2].HasValue) return memoCache[currentIndex, s2].Value;

            // path 1 - include current number in S1
            int s1Sum = FindMinimumDifference(nums,s1 + nums[currentIndex], s2, currentIndex + 1);

            // path 2 - include current number in S2
            int s2Sum = FindMinimumDifference(nums, s1, s2 + nums[currentIndex], currentIndex + 1);

            memoCache[currentIndex, s1] = Math.Min(s1Sum, s2Sum);

            _steps++;
            return memoCache[currentIndex, s1].Value;
        }
    }
}
