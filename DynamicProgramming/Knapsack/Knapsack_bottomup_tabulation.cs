using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Knapsack
{
    public class Knapsack_bottomup_tabulation
    {
        private readonly int[] profits;
        private readonly int[] weights;
        private readonly int capacity;

        private int[,] _profitMatrix;

        public Knapsack_bottomup_tabulation(int[] profits, int[] weights, int capacity)
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
            return SolveKnapsack();
        }

        private int SolveKnapsack()
        {
            // create a matrix of 1..n-items by 0..c
            _profitMatrix = new int[profits.Length, capacity + 1];

            // Step 1: fill the column for 0 capacity with 0 profits (column 1 - all items for 0 capacity)
            for (int n = 0; n < profits.Length; n++)
            {
                _profitMatrix[n, 0] = 0;
            }

            // Step 2: fill the row for first item (row 1 - all capacities for item 1)
            // if item 1's capacity is less than or equal to the capacity we are processing then take item 1's profit
            for (int c = 1; c <= capacity; c++)
            {
                // weight of first item is less than the capacity
                if (weights[0] <= capacity)
                {
                    _profitMatrix[0, c] = profits[0];
                }
            }

            // Step 3: process rest of the cells starting from [1,1] through [n-1, c]
            for (int n = 1; n < profits.Length; n++)
            {
                for (int c = 1; c <= capacity; c++)
                {
                    int includeProfit = 0, excludeProfit = 0;

                    // if current item is less than equal to capacity
                    // try adding it
                    if (weights[n] <= c)
                    {
                        // this item's profit + max profit when capacity was (c - this item's weight)
                        includeProfit = profits[n] + _profitMatrix[n - 1, c - weights[n]];
                    }

                    // max profit if this item is excluded
                    // is equal to max profit made till the previous item's processing
                    excludeProfit = _profitMatrix[n - 1, c];

                    int maxProfit = Math.Max(includeProfit, excludeProfit);

                    _profitMatrix[n, c] = maxProfit;
                }
            }

            PrintSelectedItems();

            return _profitMatrix[profits.Length - 1, capacity];
        }

        private void PrintSelectedItems()
        {
            // take the max profit at bottom right corner
            int currentProfit = _profitMatrix[profits.Length - 1, capacity];
            int currentCapacity = capacity;
            List<int> selectedItemWeights = new List<int>();

            for(int n = profits.Length - 1; n > 0; n--)
            {
                if (_profitMatrix[n-1, currentCapacity] != currentProfit)
                {
                    // this means the current item contributed to this profit
                    // so add this item to the list of contributors 
                    selectedItemWeights.Add(weights[n]);

                    // compute remaining capacity and profit to account for
                    currentProfit = _profitMatrix[n, currentCapacity] - profits[n];
                    currentCapacity = currentCapacity - weights[n];
                }
            }

            // if we still have profit left it should have come from the first item
            // coz we only loop down till the second item in previous for loop as the check in line 94
            // compares with previous item weight that would fail if we indexed for the first item
            if (currentProfit > 0)
            {
                selectedItemWeights.Add(weights[0]);
            }

            Console.WriteLine("Selected weights are: ");
            foreach(int weight in selectedItemWeights)
            {
                Console.WriteLine(weight);
            }
        }
    }
}
