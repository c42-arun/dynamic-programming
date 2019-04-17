namespace DynamicProgramming.Knapsack_0_1.SubsetsCount
{
    public class SubsetsCountBruteForceRecursion
    {
        public int CountOfSubsetsThatCouldSum(int[] nums, int sum)
        {
            if (sum == 0) return 1; // an empty subset would sum to 0!

            if (nums.Length == 0) return 0; // empty set of numbers cannot sum up to a +ve number

            return CountSubsets(nums, sum, 0);
        }

        private int CountSubsets(int[] nums, int remainingSum, int currentIndex)
        {
            if (remainingSum == 0) return 1;

            if (currentIndex >= nums.Length) return 0;

            int sum1 = 0;
            // path 1: include the number (if less than or equal to remaining sum - 
            //                              in fact if equal then next recursion would return true as per line 22 !)
            if (nums[currentIndex] <= remainingSum)
            {
                sum1 = CountSubsets(nums, remainingSum - nums[currentIndex], currentIndex + 1);
            }

            // path 2: exclude the number - in which case the remaining sum remains unchanged and we recurse to the next number
            int sum2 = CountSubsets(nums, remainingSum, currentIndex + 1);

            return sum1 + sum2;
        }
    }
}
