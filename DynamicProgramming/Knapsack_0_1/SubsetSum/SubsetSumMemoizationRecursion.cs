namespace DynamicProgramming.Knapsack_0_1.SubsetSum
{
    public class SubsetSumMemoizationRecursion
    {
        bool?[,] memoCache;

        public bool CanFindSubsetToSum(int[] nums, int sum)
        {
            if (sum == 0) return true; // an empty subset would sum to 0!

            if (nums.Length == 0) return false; // empty set of numbers cannot sum up to a +ve number

            // the cache needs to store results for all combinations of arguments for the recursive function calls
            // so currentIndex between 0..(nums.Length-1) & remainingSum could range between 1..sum 
            //                                            -> sum: 0 won't be used as we would return true before trying to store/access it
            memoCache = new bool?[nums.Length, sum + 1]; // zero index so ranges are 0..(nums.Length - 1) & 0..sum respectively

            return CanFindSubset(nums, sum, 0);
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
        private bool CanFindSubset(int[] nums, int remainingSum, int currentIndex)
        {
            if (remainingSum == 0) return true;

            if (currentIndex >= nums.Length) return false;

            // if we have already encoutered this argument combinations, simply return the cached result
            if (memoCache[currentIndex, remainingSum].HasValue) return memoCache[currentIndex, remainingSum].Value;

            // path 1: include the number (if less than or equal to remaining sum - 
            //                              in fact if equal then next recursion would return true as per line 22 !)
            if (nums[currentIndex] <= remainingSum)
            {
                // no need to store this value to the cache as if it
                // - returns true then no more recursions would occur
                // - returns false then we would call into path 2 anyway so simply store path 2's result
                if (CanFindSubset(nums, remainingSum - nums[currentIndex], currentIndex + 1))
                    return true;
            }

            // path 2: exclude the number - in which case the remaining sum remains unchanged and we recurse to the next number
            memoCache[currentIndex, remainingSum] = CanFindSubset(nums, remainingSum, currentIndex + 1);
            return memoCache[currentIndex, remainingSum].Value;
        }
    }
}
