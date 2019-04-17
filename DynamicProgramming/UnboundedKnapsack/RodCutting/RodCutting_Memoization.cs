using System;

namespace DynamicProgramming.UnboundedKnapsack.RodCutting
{
    public class RodCutting_Memoization
    {
        private int?[,] _memoCache;

        public int SolveRodCutting(int[] lengths, int[] prices, int n)
        {
            _memoCache = new int?[lengths.Length, n + 1]; // array of "index by remaining length"
            return this.SolveRodCuttingRecursive(lengths, prices, n, 0);
        }

        private int SolveRodCuttingRecursive(int[] lengths, int[] prices, int remainingLength, int currentIndex)
        {
            // base conditions and checks
            if (lengths.Length == 0 || lengths.Length != prices.Length
                                    || currentIndex >= lengths.Length) // when we have moved past the last piece
                return 0;

            if (_memoCache[currentIndex, remainingLength].HasValue)
            {
                Console.WriteLine("SolveRodCutting: Cache hit");
                return _memoCache[currentIndex, remainingLength].Value;
            }

            // Branch A: Include rod of this length
            int profitA = 0;
            if (lengths[currentIndex] <= remainingLength) // can include only if current piece is smaller or equal to remaining length
            {
                profitA = prices[currentIndex] + SolveRodCuttingRecursive(lengths, prices,
                              remainingLength - lengths[currentIndex], currentIndex);
            }

            // Branch B: Exclude rod of this length
            int profitB = SolveRodCuttingRecursive(lengths, prices, remainingLength, currentIndex + 1);

            _memoCache[currentIndex, remainingLength] = Math.Max(profitA, profitB);

            return _memoCache[currentIndex, remainingLength].Value;
        }
    }
}
