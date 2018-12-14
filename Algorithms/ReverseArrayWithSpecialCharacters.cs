using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class ReverseArrayWithSpecialCharacters
    {
        /// <summary>
        /// Reverse an array without affecting special characters
        /// Given a string, that contains special character together with 
        /// alphabets(‘a’ to ‘z’ and ‘A’ to ‘Z’), reverse the string in a 
        /// way that special characters are not affected.
        /// Runtime O(n) n = number of characters in str
        /// Space O(n) stack stores letters in str
        /// </summary>
        /// <returns>The array with special characters.</returns>
        /// <param name="array">Character Array.</param>
        public static string Solution(char[] array)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in array)
            {
                if (char.IsLetter(c))
                {
                    stack.Push(c);
                }
            }

            foreach (char c in array)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(stack.Pop());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Reverses the array with special characters constant space. 
        /// Runtime O(n)
        /// Space O(1)
        /// </summary>
        /// <returns>The array with special characters constant space.</returns>
        /// <param name="array">Array.</param>
        public static string Solution_ConstantSpace(char[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                if (!char.IsLetter(array[left]))
                {
                    left++;
                }
                else if (!char.IsLetter(array[right]))
                {
                    right--;
                }
                else
                {
                    var temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }
            return String.Join("", array);
        }
    }
}
