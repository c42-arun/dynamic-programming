using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.UnboundedKnapsack.MinimumCoinChange
{
    public class MinimumCoinChange_Memoization
    {
        public int CoinChange(int[] denominations, int total)
        {
            int?[,] cache = new int?[denominations.Length, total+1];

            int result = this.CoinChangeRecursive(cache, denominations, total, 0);

            return result == int.MaxValue ? -1 : result;
        }

        private int CoinChangeRecursive(int?[,] cache, int[] denominations, int remainingTotal, int currentIndex)
        {
            // base conditions
            if (remainingTotal == 0) return 0;

            // if we have move past all the items and we still haven't got the total then return 0
            if (denominations.Length == 0 || currentIndex >= denominations.Length || remainingTotal < 0)
                return int.MaxValue;

            if (cache[currentIndex, remainingTotal].HasValue)
            {
                Console.WriteLine("Cache hit");
                return cache[currentIndex, remainingTotal].Value;
            }

            // path A: include this denomination
            int pathACoinCount = int.MaxValue;
            if (remainingTotal >= denominations[currentIndex])
            {
                // we have an unlimited supply of coins for every denomination (unbounded knapsack) so we not increment the 
                // index to move on to the next denomination
                pathACoinCount = CoinChangeRecursive(cache, denominations, remainingTotal - denominations[currentIndex],
                    currentIndex);

                if (pathACoinCount != int.MaxValue)
                    pathACoinCount++; // we increment coin count for every recursive call return - if coin change was satisfied
            }

            // path B: exclude this denomination
            int pathBCoinCount = CoinChangeRecursive(cache, denominations, remainingTotal, currentIndex + 1);

            // return the minimum count of coins out of both the paths
            cache[currentIndex, remainingTotal] = Math.Min(pathACoinCount, pathBCoinCount);

            return cache[currentIndex, remainingTotal].Value;
        }
    }
}
