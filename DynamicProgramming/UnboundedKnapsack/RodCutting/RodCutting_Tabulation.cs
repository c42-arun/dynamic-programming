using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.UnboundedKnapsack.RodCutting
{
    public class RodCutting_Tabulation
    {
        public int SolveRodCutting(int[] lengths, int[] prices, int n)
        {
            int[,] dp = new int[lengths.Length, n + 1];

            // Step 1: Fill in first column for zero required length - would be 0 profit
            for (int index = 0; index < lengths.Length; index++)
            {
                dp[index, 0] = 0;
            }

            // Step 2: Fill in first row
            // We could multiples of item at index 0 as long as they cleanly go into the required length
            int prevLength = 0;
            for (int len = 1; len <= n; len++)
            {
                // if we add current length and still fit within required length
                //  then add the price corresponding to the length with previous cell's price
                //  else simply se
                if (prevLength + lengths[0] <= len)
                {
                    dp[0, len] = dp[0, len - 1] + prices[0];
                    prevLength += lengths[len];
                }
                else
                {
                    dp[0, len] = dp[0, len - 1];
                }
            }

            // Step 3: Fill in rest of cells starting from (1, 1)
            // At each cell: Get the max of -
            //  - include the item:
            //          if item length is larger than required length then profit is 0
            //          else add the item profit + previous profit obtained without this item
            // - exclude the item:
            //          take the price value from the previous cell for same required length
            for (int index = 1; index < lengths.Length; index++)
            {
                for (int len = 1; len <= n; len++)
                {
                    dp[index, len] = Math.Max(
                                        lengths[index] > len ? 0 : prices[index] + dp[index, len - lengths[index]],
                                        dp[index - 1, len]);
                }
            }

            return dp[lengths.Length - 1, n];
        }
    }
}
