using System;
namespace CodingProblems
{
    public static class IsPrime
    {
        /// <summary>
        /// Checks if a number is a prime. Uses sieve of eratosthenes to do so
        /// Runtime O(n^2)
        /// </summary>
        /// <returns><c>true</c>, if prime was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        public static bool Solution(int n)
        {
            if (n < 2)
                return false;

            //walk through all numbers from 2 (first prime) to n
            //cross out all numbers that are divisible by the smaller numbers
            //sieve of eratosthenes
            for (int i = 2; i < n; i++)
            {
                int index = i;
                while (index <= n)
                {
                    if (index == n)
                        return false;

                    index += i;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if a number is prime. Divides n by numbers less than itself
        /// if any divides without a remainder returns false, else number is
        /// prime.
        /// Runtime O(n)
        /// </summary>
        /// <returns><c>true</c>, if prime2 was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        public static bool Solution2(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if nsqrt n)
        /// </summary>
        /// <returns><c>true</c>, if prime3 was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        public static bool Solution3(int n)
        {
            if (n <= 1)
                return false;

            if (n <= 3)
                return true;

            //skip middle 5 numbers
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i = i + 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// if n is a prime this will always return true, if n is a composite
        /// then this returns false with high probability the higher the value of k is
        /// 
        /// Note that this method may fail even if we increase number of iterations 
        /// (higher k). There exist sum composite numbers with the property that for every 
        /// a less than n, an-1 ≡ 1 (mod n). Such numbers are called Carmichael numbers. 
        /// Fermat’s primality test is often used if a rapid method is needed for filtering, 
        /// for example in key generation phase of the RSA public key cryptographic algorithm.
        /// 
        /// Runtime O(k log n)
        /// </summary>
        /// <returns><c>true</c>, if prime with high probability was ised, <c>false</c> otherwise.</returns>
        /// <param name="n">N.</param>
        /// <param name="k">K.</param>
        public static bool SolutionWithHighProbability(int n, int k)
        {
            if (n < 2 || n == 4)
                return false;

            if (n <= 3)
                return true;

            Random rand = new Random();
            //try k times
            while (k > 0)
            {
                //pick a random number above 2 to n-2
                //where n > 4
                int a = 2 + (int)(rand.Next(2, n - 2) % (n - 4));

                //Fermat's little theorem
                if (ModularExponentiation.SolutionWithBits(a, n - 1, n) != 1)
                {
                    return false;
                }

                k--;
            }

            return true;
        }
    }
}
