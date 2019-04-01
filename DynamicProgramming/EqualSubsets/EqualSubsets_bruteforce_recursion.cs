using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.EqualSubsets
{
    public class EqualSubsets_bruteforce_recursion
    {
        public bool CanPartition(int[] nums)
        {
            if (nums.Length == 0) return true;

            if (nums.Sum() % 2 != 0) return false; // cannot divide an odd number into two equal parts

            return RecurseForEqualSubsets(nums, nums.Sum() / 2, 0);
        }

        private bool RecurseForEqualSubsets(int[] nums, int remainingSum, int currentIndex)
        {
            if (remainingSum == 0)
                return true;

            if (currentIndex >= nums.Length) return false;

            // We need to test various combinations of numbers, so at each recursion we call into two paths to include/exclude number at current index
            // this would effectively test for all combinations.
            // At any point the sum becomes 0 then we know that the numbers we have form one side of the equal sum set

            // Path A - include the number at current index if we are indeed able to fit within remaining sum
            if (nums[currentIndex] <= remainingSum)
                if (RecurseForEqualSubsets(nums, remainingSum - nums[currentIndex], currentIndex + 1))
                    return true;

            // Path B - do not include the number at current index
            return RecurseForEqualSubsets(nums, remainingSum, currentIndex + 1);
        }
    }
}
