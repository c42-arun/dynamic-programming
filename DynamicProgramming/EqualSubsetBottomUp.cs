using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class EqualSubsetBottomUp
    {
        public bool CanPartition(int[] nums)
        {
            if (nums.Length == 0) return true; // two empty sets would be equals :)

            if (nums.Sum() % 2 != 0) return false; // an odd sum cannot be divided equally

            bool?[,] dp = new bool?[nums.Length, (nums.Sum()/2) + 1];

            // fill up for first column i.e for zero sum
            // this would always be True as it is always possible to achieve a zero sum with first i items 
            // i.e simply not add any items to the set - i.e '0' sum can always be found through an empty set
            for (int i=0; i<nums.Length; i++)
            {
                dp[i, 0] = true;
            }

            // fill up for first row i.e for the first item in the list (except at 0, 0 that is already filled)
            // the cell would be True if and only if the item value equal to the sum column
            for (int colSum = 1; colSum <= nums.Sum()/2; colSum++)
            {
                dp[0, colSum] = nums[0] == colSum;
            }

            // fill rest of the cells
            // a given sum for the first i-th items can be formed if 
            //  - when the number at i is excluded: then the sum should have been already possible with (i-1) item i.e if dp[i-1, sum] was true
            //  - when the number at i is included: then the (sum - itemValue) should have been already possible with (i-1) item i.e if dp[i-1, sum - itemValue] was true
            //                                      because if we then add (sum - itemValue) + itemValue then we have the sum
            for (int index = 1; index < nums.Length; index++)
            {
                for (int colSum = 1; colSum <= nums.Sum()/2; colSum++)
                {
                    dp[index, colSum] = dp[index - 1, colSum].Value ||
                                            (nums[index] <= colSum ? dp[index - 1, colSum - nums[index]].Value : false);
                }
            }

            // as we fill out cells the value of the last cell would tell us if sum/2 can be formed from i elements 

            return dp[nums.Length - 1, nums.Sum() / 2].Value;
        }
    }
}
