using System.Linq;
using DynamicProgramming.Knapsack_0_1.SubsetsCount;

namespace DynamicProgramming.Knapsack_0_1.TargetSum
{
    /*
     https://www.educative.io/collection/page/5668639101419520/5633779737559040/5679413765079040
     * This problem follows the 0/1 Knapsack pattern and can be converted into Count of Subset Sum. Let’s dig into this.

        We are asked to find two subsets of the given numbers whose difference is equal to the given target ‘S’. Take the first example above. As we saw, one solution is {+1-1-2+3}. So, the two subsets we are asked to find are {1, 3} & {1, 2} because,

            (1 + 3) - (1 + 2 ) = 1
        Now, let’s say ‘Sum(s1)’ denotes the total sum of set ‘s1’, and ‘Sum(s2)’ denotes the total sum of set ‘s2’. So the required equation is:

            Sum(s1) - Sum(s2) = S
        This equation can be reduced to the subset sum problem. Let’s assume that ‘Sum(num)’ denotes the total sum of all the numbers, therefore:

            Sum(s1) + Sum(s2) = Sum(num)
        Let’s add the above tow equations:

            => Sum(s1) - Sum(s2) + Sum(s1) + Sum(s2) = S + Sum(num)
            => 2 * Sum(s1) =  S + Sum(num)
            => Sum(s1) = (S + Sum(num)) / 2
        This essentially converts our problem to: “Find count of subsets of the given numbers whose sum is equal to”,

            => (S + Sum(num)) / 2
     */
    public class TargetSum
    {
        public int FindTargetSubsets(int[] nums, int targetSum)
        {
            // By following logic through lines 10-30
            int newSum = (targetSum + nums.Sum()) / 2;

            SubsetsCountTabulation subsetSum = new SubsetsCountTabulation();
            return subsetSum.CountOfSubsetsThatCouldSum(nums, newSum);
        }
    }
}
