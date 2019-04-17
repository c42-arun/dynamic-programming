using System;

namespace DynamicProgramming.UnboundedKnapsack.Knapsack
{
    public class UnboundedKnapsack_Tabulation
    {
        private int[,] dp;

        // TODO: Print selected items

        public int SolveKnapsack(int[] profits, int[] weights, int capacity)
        {
            dp = new int[profits.Length, capacity + 1];

            // Step 1: Fill up column 0 i.e for capacity == 0
            // Max profit for this case is obviously 0 as this is an empty set with no items
            for(int index = 0; index < profits.Length; index++)
            {
                dp[index, 0] = 0;
            }

            // Step 2: Fill up row 0 i.e we consider the item at index == 0
            // we could include as many number of this items provided the resulting weight is <= capacity
            // we start from as cell (0, 0) is already filled in step 1
            int prevWeight = 0;
            for (int c = 1; c <= capacity; c++)
            {
                if ((prevWeight + weights[0]) <= capacity)
                {
                    dp[0, c] = dp[0, c-1] + profits[0];
                    prevWeight = prevWeight + weights[0]; ;
                }
                else
                {
                    dp[0, c] = dp[0, c - 1]; // this cell's weight would remain same as previous
                }
            }

            // Step 3: Fill remaining cells
            // At each cell determine profits of including/excluding the item and choose the maximum of the two
            // Excluding item: take the profit value from the previous cell for same capacity
            // Including item: if item weight it larger than capacity then profit is 0; 
            //                  else add the item profit + previous profit obtained without this item 
            for (int index = 1; index < profits.Length; index++)
            {
                for (int c = 1; c <= capacity; c++)
                {
                    dp[index, c] = Math.Max(dp[index - 1, c], 
                                        weights[index] <= c ? profits[index] + dp[index, c - weights[index]] : 0);
                }
            }

            return dp[profits.Length - 1, capacity];
        }
    }
}
