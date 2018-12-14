using System;
namespace Algorithms
{
    public static class ConvertToZigZag
    {
        /// <summary>
        /// Converts to zig zag.
        /// Convert array into Zig-Zag fashion
        /// Given an array of DISTINCT elements, rearrange the elements of 
        /// array in zig-zag fashion in O(n) time.The converted array should 
        /// be in form 
        /// a less than b greater than c less than d greater than e less than f
        /// Runtime O(n log n)
        /// </summary>
        /// <param name="nums">Nums.</param>
        public static void Solution(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 1; i < nums.Length - 1; i += 2)
            {
                var temp = nums[i];
                nums[i] = nums[i + 1];
                nums[i + 1] = temp;
            }
        }

        /// <summary>
        /// Converts to zig zag faster.
        /// Runtime O(n)
        /// </summary>
        /// <param name="nums">Nums.</param>
        public static void Solution_Faster(int[] nums)
        {
            bool flag = true;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (flag)
                {
                    //if A > B > C if we flip B and C then we get A > B < C
                    if (nums[i] > nums[i + 1])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                else
                {
                    //if A < B < C if we flip B and C we get A < C > B
                    if (nums[i] < nums[i + 1])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                flag = !flag;// flip flag
            }
        }
    }
}
