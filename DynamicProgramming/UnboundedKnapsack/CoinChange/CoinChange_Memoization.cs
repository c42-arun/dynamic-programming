using System;

namespace DynamicProgramming.UnboundedKnapsack.CoinChange
{
    public class CoinChange_Memoization
    {
        private int?[,] _memoCache;

        public int CountChange(int[] denominations, int total)
        {
            // total is +1 as otherwise we would get an out-of-range exception when try to
            // cache against total itself in a "0 to n-1" indexed array
            _memoCache = new int?[denominations.Length, total + 1];

            return this.CountChangeRecursive(denominations, total, 0);
        }

        private int CountChangeRecursive(int[] denominations, int remainingTotal, int currentIndex)
        {
            // base conditions
            if (remainingTotal == 0) return 1;

            // if we have move past all the items and we still haven't got the total then return 0
            if (denominations.Length == 0 || currentIndex >= denominations.Length || remainingTotal < 0)
                return 0;

            // check the cache first
            // NEVER SEEMS TO GET A CACHE HIT FOR ANY INPUT COMBINATION...
            if (_memoCache[currentIndex, remainingTotal].HasValue)
            {
                Console.WriteLine("Cache hit");
                return _memoCache[currentIndex, remainingTotal].Value;
            }

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
            _memoCache[currentIndex, remainingTotal] = pathACount + pathBCount;

            return _memoCache[currentIndex, remainingTotal].Value;
        }
    }
}
