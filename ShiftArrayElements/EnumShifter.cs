using System;

namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case Direction.Left:
                        {
                            source = source.LeftShift();
                            break;
                        }

                    case Direction.Right:
                        {
                            source = source.RightShift();
                            break;
                        }

                    default:
                        throw new InvalidOperationException($"Incorrect {directions[i]} enum value.");
                }
            }

            return source;
        }

        /// <summary>
        /// Shifts elements array to left.
        /// </summary>
        /// <param name="source">>A source array.</param>
        /// <returns>An array with shifted to left elements.</returns>
        public static int[] LeftShift(this int[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int[] shiftArray = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                if (i < source.Length - 1)
                {
                    shiftArray[i] = source[i + 1];
                }
                else
                {
                    shiftArray[i] = source[0];
                }
            }

            return shiftArray;
        }

        /// <summary>
        /// Shifts elements array to right.
        /// </summary>
        /// <param name="source">>A source array.</param>
        /// <returns>An array with shifted to right elements.</returns>
        public static int[] RightShift(this int[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int[] shiftArray = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                if (i != 0)
                {
                    shiftArray[i] = source[i - 1];
                }
                else
                {
                    shiftArray[i] = source[^1];
                }
            }

            return shiftArray;
        }
    }
}
