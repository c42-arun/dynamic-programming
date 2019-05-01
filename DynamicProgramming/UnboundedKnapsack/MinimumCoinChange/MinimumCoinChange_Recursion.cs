using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.UnboundedKnapsack.MinimumCoinChange
{
    public class MinimumCoinChange_Recursion
    {
        public int CoinChange(int[] denominations, int total)
        {
            return this.CoinChangeRecursive(denominations, total, 0, 0);
        }

        private int CoinChangeRecursive(int[] denominations, int remainingTotal, int currentIndex, int coinCount)
        {
            // base conditions
            if (remainingTotal == 0) return coinCount;

            // if we have move past all the items and we still haven't got the total then return 0
            if (denominations.Length == 0 || currentIndex >= denominations.Length || remainingTotal < 0)
                return -1;

            // path A: include this denomination
            int pathACoinCount = 0;
            if (remainingTotal >= denominations[currentIndex])
            {
                // we have an unlimited supply of coins for every denomination (unbounded knapsack) so we not increment the 
                // index to move on to the next denomination
                pathACoinCount = CoinChangeRecursive(denominations, remainingTotal - denominations[currentIndex],
                    currentIndex, coinCount + 1);
            }

            // path B: exclude this denomination
            int pathBCoinCount = CoinChangeRecursive(denominations, remainingTotal, currentIndex + 1, coinCount);

            // add up the number of ways
            return Math.Min(pathACoinCount <= 0 ? int.MaxValue : pathACoinCount, 
                pathBCoinCount <= 0 ? int.MaxValue : pathBCoinCount);
        }
    }
}
