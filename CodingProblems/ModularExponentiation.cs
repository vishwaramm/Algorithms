using System;
namespace CodingProblems
{
    public static class ModularExponentiation
    {
        /// <summary>
        /// Modulars the exponentiation.
        /// Modular Exponentiation (Power in Modular Arithmetic)
        /// Given three numbers x, y and p, compute (<paramref name="x"/>^y) % p.
        /// Runtime O(y)
        /// </summary>
        /// <returns>The exponentiation.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="p">P.</param>
        public static int Solution(int x, int y, int p)
        {
            decimal power = Power(x, y);

            int into = (int)power / p;

            return Math.Abs((int)power - (into * p));
        }

        /// <summary>
        /// Power the specified x and y.
        /// Runtime O(y)
        /// </summary>
        /// <returns>The power.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public static decimal Power(int x, int y)
        {
            //power of 
            decimal power = 1;
            bool isNegative = false;

            if (y < 0)
            {
                isNegative = true;
                y = -y;
            }

            for (int i = 0; i < y; i++)
            {
                if (isNegative)
                {
                    power = power / x;
                }
                else
                {
                    power *= x;
                }
            }

            return power;
        }

        /// <summary>
        /// Modulars the exponentiation bits.
        /// Runtime O(Log y)
        /// </summary>
        /// <returns>The exponentiation bits.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="p">P.</param>
        public static int SolutionWithBits(int x, int y, int p)
        {
            int result = 1;

            x = x % p; //update x if it is more than or equal to p

            while (y > 0)
            {
                if ((y & 1) == 1)
                {
                    result = (result * x) % p;
                }

                y = y >> 1;
                x = (x * x) % p;
            }

            return result;
        }
    }
}
