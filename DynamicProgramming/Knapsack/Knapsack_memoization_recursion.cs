using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Knapsack
{
    public class Knapsack_memoization_recursion
    {
        private readonly int[] profits;
        private readonly int[] weights;
        private readonly int capacity;

        private int?[,] memos;

        public Knapsack_memoization_recursion(int[] profits, int[] weights, int capacity)
        {
            if (profits.Length != weights.Length) throw new Exception("Number of profit items should match weights");

            this.profits = profits;
            this.weights = weights;
            this.capacity = capacity;

            this.memos = new int?[profits.Length, capacity + 1];
        }

        public int FindMaxProfit()
        {
            return SolveKnapsack(0, capacity);
        }

        private int SolveKnapsack(int currentItemIndex, int remainingCapacity)
        {
            // base conditions
            if (currentItemIndex >= profits.Length) return 0;

            if (this.memos[currentItemIndex, remainingCapacity] != null)
                return this.memos[currentItemIndex, remainingCapacity].Value;

                // for each iteration as we progress through each item we could either decide to pack the item or not
                // and we get the profit we achieve for each route we take

                // route 1 - we decide to pack this current item
                int profit1 = 0;
            if (weights[currentItemIndex] <= remainingCapacity)
            {
                profit1 = profits[currentItemIndex] + SolveKnapsack(currentItemIndex + 1, remainingCapacity - weights[currentItemIndex]);
            }

            // route 2 - we decide NOT to pack the current item
            int profit2 = SolveKnapsack(currentItemIndex + 1, remainingCapacity);

            // return the maximum of the two
            this.memos[currentItemIndex, remainingCapacity] = Math.Max(profit1, profit2);

            return this.memos[currentItemIndex, remainingCapacity].Value;
        }
    }
}
