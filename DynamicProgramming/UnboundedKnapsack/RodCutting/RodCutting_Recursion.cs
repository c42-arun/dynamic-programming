using System;

namespace DynamicProgramming.UnboundedKnapsack.RodCutting
{
    public class RodCutting_Recursion
    {
        public int SolveRodCutting(int[] lengths, int[] prices, int n)
        {
            return this.SolveRodCuttingRecursive(lengths, prices, n, 0);
        }

        private int SolveRodCuttingRecursive(int[] lengths, int[] prices, int remainingLength, int currentIndex)
        {
            // base conditions and checks
            if (lengths.Length == 0 || lengths.Length != prices.Length 
                                    || currentIndex >= lengths.Length) // when we have moved past the last piece
                return 0;

            // Branch A: Include rod of this length
            int profitA = 0;
            if (lengths[currentIndex] <= remainingLength) // can include only if current piece is smaller or equal to remaining length
            {
                profitA = prices[currentIndex] + SolveRodCuttingRecursive(lengths, prices,
                              remainingLength - lengths[currentIndex], currentIndex);
            }

            // Branch B: Exclude rod of this length
            int profitB = SolveRodCuttingRecursive(lengths, prices, remainingLength, currentIndex + 1);

            return Math.Max(profitA, profitB);
        }
    }
}
