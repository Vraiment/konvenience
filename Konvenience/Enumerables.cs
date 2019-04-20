using System;
using System.Collections.Generic;

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

        #region IEnumerable<T> ForEach
        /// <summary>
        /// Executes <paramref name="action"/> in each element of <paramref name="enumerable"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the objects enumerated by <paramref name="enumerable"/>.</typeparam>
        /// 
        /// <param name="enumerable">The objects that will be iterated over.</param>
        /// <param name="action">The action that will be executed for each object.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Validate.ArgumentNotNull(action, nameof(action));

            if (enumerable is null)
            {
                return;
            }

            foreach (var value in enumerable)
            {
                action(value);
            }
        }

        /// <summary>
        /// Executes <paramref name="action"/> in each element of <paramref name="enumerable"/>
        /// along with its corresponding index.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the objects enumerated by <paramref name="enumerable"/>.</typeparam>
        /// 
        /// <param name="enumerable">The objects that will be iterated over.</param>
        /// <param name="action">The action that will be executed for each object.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            Validate.ArgumentNotNull(action, nameof(action));

            if (enumerable is null)
            {
                return;
            }

            int index = 0;
            foreach (var value in enumerable)
            {
                action(value, index++);
            }
        }
        #endregion

        #region Dictionaries' ForEach
        /// <summary>
        /// Executes <paramref name="action"/> in each entry of <paramref name="dictionary"/>.
        /// </summary>
        /// 
        /// <typeparam name="TKey">The type of the keys for the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values for the dictionary.</typeparam>
        /// 
        /// <param name="dictionary">The objects that will be iterated over.</param>
        /// <param name="action">The action that will be executed for each object.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            Validate.ArgumentNotNull(action, nameof(action));

            if (dictionary is null)
            {
                return;
            }

            foreach (var entry in dictionary)
            {
                action(entry.Key, entry.Value);
            }
        }

        /// <summary>
        /// Executes <paramref name="action"/> in each entry of <paramref name="dictionary"/>.
        /// </summary>
        /// 
        /// <typeparam name="TKey">The type of the keys for the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values for the dictionary.</typeparam>
        /// 
        /// <param name="dictionary">The objects that will be iterated over.</param>
        /// <param name="action">The action that will be executed for each object.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static void ForEach<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            Validate.ArgumentNotNull(action, nameof(action));

            if (dictionary is null)
            {
                return;
            }

            foreach (var entry in dictionary)
            {
                action(entry.Key, entry.Value);
            }
        }
        #endregion
    }
}
