using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public static class GetTripletsLessThanSumCount
    {
        /// <summary>
        /// Count triplets with sum smaller than a given value
        /// Given an array of distinct integers and a sum value.
        /// Find count of triplets with sum smaller than given sum value. 
        /// Expected Time Complexity is O(n^2).
        /// Gets the triplets less than sum count.
        /// Runtime O(n^3)
        /// </summary>
        /// <returns>The triplets less than sum count.</returns>
        /// <param name="nums">Nums.</param>
        /// <param name="sum">Sum.</param>
        public static int Solution(int[] nums, int sum)
        {
            Dictionary<int, int> complements = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int x = j + 1; x < nums.Length; x++)
                    {
                        if (nums[i] + nums[j] + nums[x] < sum)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Gets the triplets less than sum count.
        /// Runtime O(n^2)
        /// </summary>
        /// <returns>The triplets less than sum count faster.</returns>
        /// <param name="nums">Nums.</param>
        /// <param name="sum">Sum.</param>
        public static int Solution_Faster(int[] nums, int sum)
        {
            Array.Sort(nums);
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] >= sum)
                    {
                        right--;
                    }
                    else
                    {
                        count += right - left;
                        left++;
                    }
                }
            }

            return count;
        }
    }
}
