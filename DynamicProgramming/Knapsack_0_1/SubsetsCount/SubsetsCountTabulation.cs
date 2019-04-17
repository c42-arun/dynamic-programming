namespace DynamicProgramming.Knapsack_0_1.SubsetsCount
{
    public class SubsetsCountTabulation
    {
        private int[,] dp;

        public int CountOfSubsetsThatCouldSum(int[] nums, int sum)
        {
            if (sum == 0) return 1; // an empty subset would sum to 0!

            if (nums.Length == 0) return 0; // empty set of numbers cannot sum up to a +ve number

            dp = new int[nums.Length, sum + 1];

            // Step 1: fill up first column i.e count of subsets that add up to 0
            // we can always find one empty subset that adds up to 0
            for (int index = 0; index < nums.Length; index++)
            {
                dp[index, 0] = 1;
            }

            // Step 2: fill first row with count of subsets that add up to that sum
            // the count would be 1 if the number at index 0 is equal to the sum
            for (int colSum = 1; colSum <= sum; colSum++)
            {
                dp[0, colSum] = nums[0] == colSum ? 1 : 0;
            }

            // Step 3: fill rest of the cells
            // Now the count at a given cell would be
            // subsets count with the number excluded **PLUS**  subsets count with the number included
            // (the first part would make intuitive sense i.e if we don't consider this number then take the count that we got for the previous number (that would add to current sum)
            // (the second part needs a bit of thinking - here if we include this number then we need to see how many sets we might have had for a sum that was (current sum - number) - 
            //                  so we can simply add this number to each of those sets to get the current sum
            for (int index = 1; index < nums.Length; index++)
            {
                for (int colSum = 1; colSum <= sum; colSum++)
                {
                    dp[index, colSum] = dp[index - 1, colSum] +
                                        (nums[index] <= colSum
                                            ? dp[index - 1, colSum - nums[index]]
                                            : 0);
                }
            }

            return dp[nums.Length -1, sum];
        }
    }
}
