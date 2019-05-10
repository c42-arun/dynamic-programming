using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.UnboundedKnapsack.MinimumCoinChange
{
    public class MinimumCoinChange_Tabulation
    {
        public int CoinChange(int[] denominations, int total)
        {
            int result = this.CoinChangeTabulation(denominations, total);

            return result == int.MaxValue ? -1 : result;
        }

        private int CoinChangeTabulation(int[] denominations, int total)
        {
            int[,] dp = new int[denominations.Length, total + 1];

            // step 0: Initialize all cells with int.MaxValue to indicate coins won't add up
            for (int i = 0; i < denominations.Length; i++)
            {
                for (int t = 0; t <= total; t++)
                {
                    dp[i, t] = int.MaxValue;
                }
            }

            // step 1: fill for the first column where total = 0, we need 0 coins
            for (int i = 0; i < denominations.Length; i++)
            {
                dp[i, 0] = 0;
            }

            // step 2: final step
            // minimum coins at each cell is: 
            // Min of dp[i - 1][t] (if i > 0)
            //          & dp[i][t-denominations[i]]

            for (int i = 0; i < denominations.Length; i++)
            {
                for (int t = 1; t <= total; t++)
                {
                    int topCellValue = i == 0 ? int.MaxValue : dp[i - 1, t];

                    int currentRowValue = t >= denominations[i]
                        ? dp[i, t - denominations[i]] + 1
                        : int.MaxValue;

                    dp[i, t] = Math.Min(topCellValue, currentRowValue);
                }
            }

            return dp[denominations.Length - 1, total];

        }
    }
}
