using System;
namespace Algorithms
{
    public static class HasPythagoreanTriplet
    {
        /// <summary>
        /// Checks if the given array has a pythagorean triplet a^2 + b^2 = c^2.
        /// Pythagorean Triplet in an array
        /// Given an array of integers, write a function that returns true if there is a 
        /// triplet(a, b, c) that satisfies a^2 + b^2 = c^2.
        /// Runtime O(n^3)
        /// </summary>
        /// <returns><c>true</c>, if pythagorean triplet was hased, <c>false</c> otherwise.</returns>
        /// <param name="nums">Nums.</param>
        public static bool Solution(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int x = j + 1; x < nums.Length; x++)
                    {
                        int a = (int)Math.Pow(nums[i], 2);
                        int b = (int)Math.Pow(nums[j], 2);
                        int c = (int)Math.Pow(nums[x], 2);

                        if (a + b == c || a + c == b || b + c == a)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Hases the pythagorean triplet faster.
        /// Runtime O(n^2)
        /// </summary>
        /// <returns><c>true</c>, if pythagorean triplet faster was hased, <c>false</c> otherwise.</returns>
        /// <param name="nums">Nums.</param>
        public static bool Solution_Faster(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];
            }

            Array.Sort(nums);

            for (int i = nums.Length - 1; i >= 2; i--)
            {
                int left = 0;
                int right = i - 1;

                while (left < right)
                {
                    if (nums[left] + nums[right] == nums[i])
                        return true;

                    if (nums[left] + nums[right] < nums[i])
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return false;
        }
    }
}
