using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class GetAllPalindromicPartitions
    {
        /// <summary>
        /// Given a string, print all possible palindromic partitions
        /// Given a string, find all possible palindromic partitions of given string.
        /// </summary>
        /// <returns>The all palindromic partitions.</returns>
        /// <param name="s">S.</param>
        public static List<string> Solution(string s)
        {
            List<string> permutations = new List<string>();
            List<string> results = new List<string>();

            permutations.Add("");

            foreach (char c in s)
            {
                int count = permutations.Count;

                for (int i = 0; i < count; i++)
                {
                    permutations.Add(permutations[i] + c);
                }
            }

            foreach (var str in permutations)
            {
                if (str != "" && IsPalindrome(str))
                {
                    results.Add(str);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks if string is a palindrome. Runtime O(n)
        /// </summary>
        /// <returns><c>true</c>, if palindrome was ised, <c>false</c> otherwise.</returns>
        /// <param name="s">S.</param>
        private static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}
