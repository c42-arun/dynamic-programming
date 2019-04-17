namespace DynamicProgramming.Knapsack_0_1.SubsetSum
{
    public class SubsetSumBottomupTabulation
    {
        bool?[,] dp;

        public bool CanFindSubsetToSum(int[] nums, int sum)
        {
            if (sum == 0) return true; // an empty subset would sum to 0!

            if (nums.Length == 0) return false; // empty set of numbers cannot sum up to a +ve number

            // the cache needs to store results for all combinations of arguments for the recursive function calls
            // so currentIndex between 0..(nums.Length-1) & remainingSum could range between 1..sum 
            //                                            -> sum: 0 won't be used as we would return true before trying to store/access it
            dp = new bool?[nums.Length, sum + 1]; // zero index so ranges are 0..(nums.Length - 1) & 0..sum respectively

            return CanFindSubset(nums, sum);
        }

        /// <summary>
        ///  The idea being processing (i.e whether this input combination returns a true or false) for this particular set of inputs to be cached 
        ///  so the next time this is encountered we could return it from cache.
        ///  Consider this scenario: lets say we have nums as {2, 2, 10, 20} (sum is 34). We could have these two paths 
        ///  1. excluding index 0 but including index 1 before arriving at 2 - the function input would be (nums, remainingSum: 32, currentIndex: 2)
        ///  2. including index 0 but excluding index 1 before arriving at 2 - input would be (nums, remainingSum: 32, currentIndex: 2)
        ///  Clearly the second case is a repeat of 1 - i.e the processing would then call 
        ///     (nums, remainingSum: 22, currentIndex: 3) & (nums, remainingSum: 32, currentIndex: 3)
        ///  This can be easily visualized by drawing out the recursive tree
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="remainingSum"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private bool CanFindSubset(int[] nums, int requiredSum)
        {
            // to start with we fill first column and first row to bootstrap our table

            // first column: sum to calculate is 0 - can be achieved by an empty subset, so true :)
            for (int index = 0; index < nums.Length; index++)
            {
                dp[index, 0] = true;
            }

            // first row: would be true if the num at index matches the required sum for that column
            for (int colSum = 1; colSum <= requiredSum; colSum++)
            {
                dp[0, colSum] = nums[0] == colSum ? true : false;
            }

            // rest of the cells:
            // true if either -
            //  dp[index - 1, sum] is true: i.e if already true with the current number excluded
            //  dp[index -1, sum - nums[index]] is true: i.e there's a set without this number that would equal (sum - currentNum) so that
            //                  by adding the currentNum we would get the sum
            // in effect the value for current cell = dp[index - 1, sum] || dp[index -1, sum - nums[index]]
            for(int index = 1; index < nums.Length; index++)
            {
                for(int colSum = 1; colSum <= requiredSum; colSum++)
                {
                    dp[index, colSum] = dp[index - 1, colSum].Value ||
                                            (nums[index] <= colSum ? dp[index - 1, colSum - nums[index]].Value : false);
                }
            }

            // now the value of the cell at bottom right corner would tell us whether the sum is achievable or not
            return dp[nums.Length - 1, requiredSum].Value;
        }
    }
}
