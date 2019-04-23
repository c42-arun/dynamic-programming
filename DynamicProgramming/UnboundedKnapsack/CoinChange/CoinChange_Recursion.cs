using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.UnboundedKnapsack.CoinChange
{
    public class CoinChange_Recursion
    {
        public int CountChange(int[] denominations, int total)
        {
            return this.CountChangeRecursive(denominations, total, 0);
        }

        private int CountChangeRecursive(int[] denominations, int remainingTotal, int currentIndex)
        {
            // base conditions
            if (remainingTotal == 0) return 1;

            // if we have move past all the items and we still haven't got the total then return 0
            if (denominations.Length == 0 || currentIndex >= denominations.Length || remainingTotal < 0)
                return 0;

            // path A: include this denomination
            int pathACount = 0;
            if (remainingTotal >= denominations[currentIndex])
            {
                // we have an unlimited supply of coins for every denomination (unbounded knapsack) so we not increment the 
                // index to move on to the next denomination
                pathACount = CountChangeRecursive(denominations, remainingTotal - denominations[currentIndex],
                    currentIndex);
            }

            // path B: exclude this denomination
            int pathBCount = CountChangeRecursive(denominations, remainingTotal, currentIndex + 1);

            // add up the number of ways
            return pathACount + pathBCount;
        }
    }
}
