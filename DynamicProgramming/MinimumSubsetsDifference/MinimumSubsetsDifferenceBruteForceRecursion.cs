using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.MinimumSubsetsDifference
{
    public class MinimumSubsetsDifferenceBruteForceRecursion
    {
        public int GetMinimumDifferenceFromTwoSubsets(int[] nums)
        {
            if (nums.Length < 2) return -1;

            return FindMinimumDifference(nums, 0, 0, 0);
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

            return Math.Min(s1Sum, s2Sum);
        }
    }
}
