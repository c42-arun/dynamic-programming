using System;

namespace DynamicProgramming.Knapsack_0_1.Knapsack
{
    public class Knapsack_bruteforce_recursion
    {
        private readonly int[] profits;
        private readonly int[] weights;
        private readonly int capacity;

        public Knapsack_bruteforce_recursion(int[] profits, int[] weights, int capacity)
        {
            if (profits.Length != weights.Length) throw new Exception("Number of profit items should match weights");
            if (capacity <= 0) throw new Exception("Capacity should be more than 0");
            if (profits.Length == 0) throw new Exception("There should be at least 1 item");

            this.profits = profits;
            this.weights = weights;
            this.capacity = capacity;
        }

        public int FindMaxProfit()
        {
            return SolveKnapsack(capacity, 0);
        }

        private int SolveKnapsack(int remainingCapacity, int currentItemIndex)
        {
            // base conditions
            if (currentItemIndex >= profits.Length) return 0;

            // for each iteration as we progress through each item we could either decide to pack the item or not
            // and we get the profit we achieve for each route we take

            // route 1 - we decide to pack this current item
            int profit1 = 0;
            if (weights[currentItemIndex] <= remainingCapacity)
            {
                profit1 = profits[currentItemIndex] + SolveKnapsack(remainingCapacity - weights[currentItemIndex], currentItemIndex + 1);
            }

            // route 2 - we decide NOT to pack the current item
            int profit2 = SolveKnapsack(remainingCapacity, currentItemIndex + 1);

            // return the maximum of the two
            return Math.Max(profit1, profit2);
        }
    }
}
