using System;

namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (see README.md for detailed instructions).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                if (iterations[i] == 0)
                {
                    continue;
                }

                int direction = i % 2;
                for (int n = iterations[i]; n != 0; n--)
                {
                    int temp = source[(source.Length - direction) % source.Length];
                    Array.Copy(source, 1 - direction, source, direction, source.Length - 1);
                    source[(source.Length + direction - 1) % source.Length] = temp;
                }
            }

            return source;
        }
    }
}
