using System;
namespace Algorithms
{
    public static class LengthOfLargestSubArrayWithContiguousElements
    {
        /// <summary>
        /// Gets the length of largest sub array with contiguous elements.
        /// Length of the largest subarray with contiguous elements | Set 1
        /// Given an array of distinct integers, find length of the longest 
        /// subarray which contains numbers that can be arranged in a continuous sequence.
        /// Runtime O(n log n)
        /// </summary>
        /// <returns>The length of largest sub array with contiguous elements.</returns>
        /// <param name="nums">Nums.</param>
        public static int Solution(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;
            int max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i + 1 < nums.Length && nums[i + 1] - nums[i] == 1)
                {
                    if (count == 0)
                        count += 2;
                    else
                        count++;
                }
                else
                {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }

            return max;
        }
    }
}
