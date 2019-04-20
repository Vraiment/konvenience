using System;

namespace Konvenience
{
    /// <summary>
    /// Class containting convenience extension for enumerable objects.
    /// </summary>
    public static class Enumerables
    {
        #region Arrays' ForEach
        /// <summary>
        /// Executes <paramref name="action"/> in each element of <paramref name="array"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of elements of <paramref name="array"/>.</typeparam>
        /// 
        /// <param name="array">The arrray to be iterated over.</param>
        /// <param name="action">The action that will be executed for each array element.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            Validate.ArgumentNotNull(action, nameof(action));

            if (array is null)
            {
                return;
            }

            foreach (var value in array)
            {
                action(value);
            }
        }

        /// <summary>
        /// Executes <paramref name="action"/> in each element of <paramref name="array"/>
        /// along with its corresponding index.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of elements of <paramref name="array"/>.</typeparam>
        /// 
        /// <param name="array">The arrray to be iterated over.</param>
        /// <param name="action">The action that will be executed for each array element.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static void ForEach<T>(this T[] array, Action<T, int> action)
        {
            Validate.ArgumentNotNull(action, nameof(action));

            if (array is null)
            {
                return;
            }

            int index = 0;
            foreach (var value in array)
            {
                action(value, index++);
            }
        }
        #endregion
    }
}
