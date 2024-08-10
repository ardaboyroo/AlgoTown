using System;

namespace AlgoTown.Core.Utils
{
    public class Utils
    {
        private static Random random = new Random();

        /// <summary>
        /// Gets a random value between the specified min (inclusive) and max (exclusive).
        /// If you want to receive a float value, use two floats as parameters to this function.
        /// </summary>
        /// <param name='min'>
        /// Inclusive minimum value: lowest possible random value.
        /// </param>
        /// <param name='max'>
        /// Exclusive maximum value: the returned value will be smaller than this value.
        /// </param>
        public static int Random(int min, int max)
        {
            return random.Next(min, max);
        }

        /// <summary>
        /// Gets a random value between the specified min (inclusive) and max (exclusive).
        /// If you want to receive an integer value, use two integers as parameters to this function.
        /// </summary>
        /// <param name='min'>
        /// Inclusive minimum value: lowest possible random value.
        /// </param>
        /// <param name='max'>
        /// Exclusive maximum value: the returned value will be smaller than this value.
        /// </param>
        public static float Random(float min, float max)
        {
            return (float)(random.NextDouble() * (max - min) + min);
        }
    }
}
