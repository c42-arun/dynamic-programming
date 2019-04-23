using System;

namespace DynamicProgramming.UnboundedKnapsack.CoinChange
{
    public class CoinChange_Tabulation
    {
        public int CountChange(int[] denominations, int total)
        {
            // total is +1 as otherwise we would get an out-of-range exception when try to
            // cache against total itself in a "0 to n-1" indexed array
            int[,] dp = new int[denominations.Length, total + 1];

            // Step 1: fill up first column i.e target total of 0 - we can find an empty set so we set it to 1
            for (int i = 0; i < denominations.Length; i++)
            {
                dp[i, 0] = 1;
            }

            // Step 2: fill the first row
            // So for every possible total ‘t’ (0 <= t <= Total) and for every possible coin index(0 <= index < denominations.length), we have two options:
            //      Exclude the coin.Count all the coin combinations without the given coin up to the total ‘t’ => dp[index - 1][t]
            //      Include the coin if its value is not more than ‘t’. In this case, we will count all the coin combinations to get the remaining total: dp[index][t - denominations[index]]
            for (int i = 0; i < denominations.Length; i++)
            {
                for (int t = 1; t <= total; t++)
                {
                    // exclude: the number of sets will be got from the cell above
                    int coinExcludedNumWays = i > 0 ? dp[i - 1, t] : 0;

                    // include: idea is to add this coin to each of the sets that can sum upto (t - denomination_of_this_coin)
                    //          so get the sets that sum to (t - denomination_of_this_coin)
                    int coinIncludedNumWays = t >= denominations[i] ? dp[i, t - denominations[i]] : 0;

                    dp[i, t] = coinExcludedNumWays + coinIncludedNumWays;
                }
            }
            return dp[denominations.Length -1, total];
        }
    }
}
