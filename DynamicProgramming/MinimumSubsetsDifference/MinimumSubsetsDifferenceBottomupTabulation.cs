using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.MinimumSubsetsDifference
{
    public class MinimumSubsetsDifferenceBottomupTabulation
    {
        private int _steps = 0;

        public int GetMinimumDifferenceFromTwoSubsets(int[] nums)
        {
            if (nums.Length < 2) return -1;

            int halfTheSum = nums.Sum() / 2; // integer division

            bool?[,] dp = new bool?[nums.Length, halfTheSum + 1] ;

            // step 1: Fill up first column i,e for sum = 0
            // we can always find an empty set for sum = 0 so "true" for all cells
            for (int index = 0; index < nums.Length; index++)
            {
                dp[index, 0] = true;
            }

            // Step 2: Fill up the first row through sums 1 till halfTheSum (0 already calculated from Step 1)
            for (int sum = 1; sum <= halfTheSum; sum++)
            {
                dp[0, sum] = nums[0] == sum;
            }

            // Step 3: Fill up rest of the cells
            for (int index = 1; index < nums.Length; index++)
            {
                for (int sum = 1; sum <= halfTheSum; sum++)
                {
                    if (nums[index] > sum) // if number greater than the sum reqd
                    {
                        dp[index, sum] = dp[index - 1, sum]; // exclude the number
                    }
                    else
                    {
                        dp[index, sum] = dp[index - 1, sum].Value || dp[index - 1, sum - nums[index]].Value; // check by either excluding or including the number
                    }
                }
            }

            //if (dp[nums.Length - 1, halfTheSum].Value == true)
            //{
            //    return 0;
            //}

            //for (int sumS1 = halfTheSum; sumS1 > 0; sumS1--)
            //{

            //    if (dp[nums.Length - 1, sumS1].Value)
            //    {
            //        int sumS2 = nums.Sum() - sumS1;
            //        return Math.Abs(sumS1 - sumS2);
            //    }
            //}

            //return -1;

            int sum1 = 0;

            // check where the cell is first true  starting from bottom right hand corner
            // bottom right most corner would mean the least difference, increasing by 1 as we move left
            for (int sum = halfTheSum; sum > 0; sum--)
            {
                if (dp[nums.Length - 1, sum].Value)
                {
                    sum1 = sum;
                    break;
                }
            }

            int sum2 = nums.Sum() - sum1;

            return Math.Abs(sum1 - sum2);
        }
    }
}
