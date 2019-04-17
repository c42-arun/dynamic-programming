using System;

namespace DynamicProgramming.UnboundedKnapsack.Knapsack
{
    public class UnboundedKnapsack_Memoization
    {
        private int?[,] memo_cache;

        public int SolveKnapsack(int[] profits, int[] weights, int capacity)
        {
            memo_cache = new int?[profits.Length, capacity + 1];

            return this.KnapsackRecursive(profits, weights, capacity, 0);
        }

        private int KnapsackRecursive(int[] profits, int[] weights, int capacity, int currentIndex)
        {
            // base conditions and checks
            if (capacity == 0 || currentIndex >= profits.Length || profits.Length != weights.Length)
                return 0;

            // check if we have already processed this combination of capacity/index
            if (memo_cache[currentIndex, capacity].HasValue)
                return memo_cache[currentIndex, capacity].Value;

            // Branch A: include this item if weight is less than or equal to remaining capacity
            // CAUTION: Unlike 0/1 Knapsack we do not increment the current index (i.e move on to next item) as in this
            // type of problem, the item could be added as many times
            int profitA = 0;
            if (weights[currentIndex] <= capacity)
            {
                profitA = profits[currentIndex] + KnapsackRecursive(profits, weights, capacity - weights[currentIndex], currentIndex);
            }

            // Branch B: exclude this item. In which case we move onto the next item (i.e increment the index) and 
            // capacity remains unchanged
            int profitB = KnapsackRecursive(profits, weights, capacity, currentIndex + 1);

            memo_cache[currentIndex, capacity] = Math.Max(profitA, profitB);

            return memo_cache[currentIndex, capacity].Value;
        }
    }
}
