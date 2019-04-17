namespace DynamicProgramming.Knapsack_0_1.SubsetSum
{
    public class SubsetSumBruteForceRecursion
    {
        public bool CanFindSubsetToSum(int[] nums, int sum)
        {
            if (sum == 0) return true; // an empty subset would sum to 0!

            if (nums.Length == 0) return false; // empty set of numbers cannot sum up to a +ve number

            return CanFindSubset(nums, sum, 0);
        }

        private bool CanFindSubset(int[] nums, int remainingSum, int currentIndex)
        {
            if (remainingSum == 0) return true;

            if (currentIndex >= nums.Length) return false;

            // path 1: include the number (if less than or equal to remaining sum - 
            //                              in fact if equal then next recursion would return true as per line 22 !)
            if (nums[currentIndex] <= remainingSum)
            {
                if (CanFindSubset(nums, remainingSum - nums[currentIndex], currentIndex + 1))
                    return true;
            }

            // path 2: exclude the number - in which case the remaining sum remains unchanged and we recurse to the next number
            return CanFindSubset(nums, remainingSum, currentIndex + 1);
        }
    }
}
