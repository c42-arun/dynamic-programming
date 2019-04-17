using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            GetSelections(dp, prices, lengths);

            return dp[lengths.Length - 1, n];
        }

        public void GetSelections(int[,] dp, int[] prices, int[] lengths)
        {
            int itemIndex = dp.GetLength(0) - 1;
            int lengthIndex = dp.GetLength(1) - 1;

            int targetPrice = dp[itemIndex, lengthIndex];

            Console.WriteLine(targetPrice);

            List<int> selecedItems = new List<int>();

            while (targetPrice > 0)
            {
                // if current cell's value is same as top cell then it means a previous item contributed to that value
                // so move to that cell
                if (itemIndex >= 1 && targetPrice == dp[itemIndex - 1, lengthIndex])
                {
                    itemIndex--;
                }
                // if current cell's value is different then it means the current item did contribute
                // so add the item to selected list, take away this item's length and price off 
                // taking the length off would move length index (i.e column index) by current item's length
                else
                {
                    selecedItems.Add(lengths[itemIndex]);
                    lengthIndex -= lengths[itemIndex];
                    targetPrice -= prices[itemIndex];
                }
            }

            Console.Write("{ ");
            foreach (int item in selecedItems)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("} ");
        }
    }
}
