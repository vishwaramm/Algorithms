using System;
namespace Algorithms
{
    public static class EulersTotient
    {
        /// <summary>
        /// Gets the greatest common divisor by getting the remainder of the division of a and b
        /// until there is no remainder
        /// Runtime O(h) where h is number of digits in smaller number of a and b
        /// </summary>
        /// <returns>The common divisor.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (a == 0)
                return b;

            return GreatestCommonDivisor(b % a, a);
        }

        /// <summary>
        /// Euler’s Totient Function
        /// Euler’s Totient function? (n) for an input n is count of numbers in {1, 2, 3, …, n } 
        /// that are relatively prime to n, i.e., the numbers whose GCD(Greatest Common Divisor) 
        /// with n is 1.
        /// Runtime O(n log n)
        /// </summary>
        /// <returns>The totient.</returns>
        /// <param name="n">N.</param>
        public static int Solution(int n)
        {
            int result = 1;

            for (int i = 2; i < n; i++)
            {
                if (GreatestCommonDivisor(i, n) == 1)
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// The idea is based on Euler’s product formula which states that 
        /// value of totient functions is below product over all prime factors p of n.
        /// The formula basically says that the value of ?(n) is equal to n multiplied by 
        /// product of (1 – 1/p) for all prime factors p of n. 
        /// For example value of ?(6) = 6 * (1-1/2) * (1 – 1/3) = 2.
        /// </summary>
        /// <returns>The totient using eulers product.</returns>
        /// <param name="n">N.</param>
        public static int SolutionUsingEulersProduct(int n)
        {
            float result = n;

            //consider all prime factors of n and
            //for every prime factor p multiply result with (1 - (1/p))
            for (int p = 2; p * p <= n; ++p)
            {
                if (n % p == 0)
                {
                    //check if p is a prime factor

                    while (n % p == 0)
                        n = n / p;

                    result *= (1.0f - (1.0f / (float)p));
                }
            }

            //if n has a prime factor greater than sqrt(n)
            //There can be at most one such prime factor
            if (n > 1)
            {
                result *= (1.0f - (1.0f / (float)n));
            }

            return (int)Math.Ceiling(result);
        }
    }
}
