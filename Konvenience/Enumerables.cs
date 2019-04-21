using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <exception cref="ArgumentNullException">If <paramref name="array"/> or <paramref name="action"/> are null.</exception>
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            Validate.ArgumentNotNull(array, nameof(array));
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
        /// <exception cref="ArgumentNullException">If <paramref name="array"/> or <paramref name="action"/> are null.</exception>
        public static void ForEach<T>(this T[] array, Action<T, int> action)
        {
            Validate.ArgumentNotNull(array, nameof(array));
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
        /// <exception cref="ArgumentNullException">If <paramref name="enumerable"/> or <paramref name="action"/> are null.</exception>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Validate.ArgumentNotNull(enumerable, nameof(enumerable));
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
        /// <exception cref="ArgumentNullException">If <paramref name="enumerable"/> or <paramref name="action"/> are null.</exception>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            Validate.ArgumentNotNull(enumerable, nameof(enumerable));
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
        /// <exception cref="ArgumentNullException">If <paramref name="dictionary"/> or <paramref name="action"/> are null.</exception>
        public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            Validate.ArgumentNotNull(dictionary, nameof(dictionary));
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
        /// <exception cref="ArgumentNullException">If <paramref name="dictionary"/> or <paramref name="action"/> are null.</exception>
        public static void ForEach<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            Validate.ArgumentNotNull(dictionary, nameof(dictionary));
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

        #region Array's Get
        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="array"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="array"/>.</typeparam>
        /// 
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the element of the array.</param>
        /// 
        /// <returns>The element at position <paramref name="index"/> in <paramref name="array"/>.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="index"/> is not a valid position in <paramref name="array"/>.</exception>
        public static T Get<T>(this T[] array, int index)
        {
            Validate.ArgumentNotNull(array, nameof(array));
            Validate.ArgumentInRange(index, nameof(index), 0, array.Length - 1);

            return array[index];
        }

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="array"/>
        /// or <paramref name="value"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="array"/>.</typeparam>
        /// 
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the element of the array.</param>
        /// <param name="value">The value to return if <paramref name="index"/> is not valid.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or <paramref name="value"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this T[] array, int index, T value)
            => GetOrElse(array, index, () => value);

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="array"/>
        /// or the value generated by <paramref name="function"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="array"/>.</typeparam>
        /// 
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the element of the array.</param>
        /// <param name="function">The function that will generate the value if <paramref name="index"/> is out of bounds.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or the result of <paramref name="function"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this T[] array, int index, Func<T> function)
        {
            if (array != null && 0 <= index && index <= array.Length - 1)
            {
                return array[index];
            }
            else
            {
                return function();
            }
        }
        #endregion

        #region IEnumerable<T> Get
        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="enumerable"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// 
        /// <param name="enumerable">The enumeration of elements.</param>
        /// <param name="index">The index of the element in <paramref name="enumerable"/>.</param>
        /// 
        /// <returns>The element at position <paramref name="index"/> in <paramref name="enumerable"/>.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="enumerable"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="index"/> is not a valid position in <paramref name="enumerable"/>.</exception>
        public static T Get<T>(this IEnumerable<T> enumerable, int index)
        {
            Validate.ArgumentNotNull(enumerable, nameof(enumerable));
            Validate.ArgumentInRange(index, nameof(index), 0, enumerable.Count() - 1);

            return enumerable.ElementAt(index);
        }

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="enumerable"/>
        /// or <paramref name="value"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// 
        /// <param name="enumerable">The enumeration of elements.</param>
        /// <param name="index">The index of the element in <paramref name="enumerable"/>.</param>
        /// <param name="value">The value to return if <paramref name="index"/> is not valid.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or <paramref name="value"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this IEnumerable<T> enumerable, int index, T value)
            => GetOrElse(enumerable, index, () => value);

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="enumerable"/>
        /// or the value generated by <paramref name="function"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// 
        /// <param name="enumerable">The enumeration of elements.</param>
        /// <param name="index">The index of the element in <paramref name="enumerable"/>.</param>
        /// <param name="function">The function that will generate the value if <paramref name="index"/> is out of bounds.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or the result of <paramref name="function"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this IEnumerable<T> enumerable, int index, Func<T> function)
        {
            if (enumerable != null && 0 <= index && index <= enumerable.Count() - 1)
            {
                return enumerable.ElementAt(index);
            }
            else
            {
                return function();
            }
        }
        #endregion

        #region Lists' Get
        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="list"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="list"/>.</typeparam>
        /// 
        /// <param name="list">The enumeration of elements.</param>
        /// <param name="index">The index of the element in <paramref name="list"/>.</param>
        /// 
        /// <returns>The element at position <paramref name="index"/> in <paramref name="list"/>.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="list"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="index"/> is not a valid position in <paramref name="list"/>.</exception>
        public static T Get<T>(this IList<T> list, int index)
        {
            Validate.ArgumentNotNull(list, nameof(list));
            Validate.ArgumentInRange(index, nameof(index), 0, list.Count - 1);

            return list[index];
        }

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="list"/>
        /// or <paramref name="value"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="list"/>.</typeparam>
        /// 
        /// <param name="list">The list of elements.</param>
        /// <param name="index">The index of the element in <paramref name="list"/>.</param>
        /// <param name="value">The value to return if <paramref name="index"/> is not valid.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or <paramref name="value"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this IList<T> list, int index, T value)
            => GetOrElse(list, index, () => value);

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="list"/>
        /// or the value generated by <paramref name="function"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="list"/>.</typeparam>
        /// 
        /// <param name="list">The list of elements.</param>
        /// <param name="index">The index of the element in <paramref name="list"/>.</param>
        /// <param name="function">The function that will generate the value if <paramref name="index"/> is out of bounds.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or the result of <paramref name="function"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this IList<T> list, int index, Func<T> function)
        {
            if (list != null && 0 <= index && index <= list.Count - 1)
            {
                return list[index];
            }
            else
            {
                return function();
            }
        }

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="list"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="list"/>.</typeparam>
        /// 
        /// <param name="list">The enumeration of elements.</param>
        /// <param name="index">The index of the element in <paramref name="list"/>.</param>
        /// 
        /// <returns>The element at position <paramref name="index"/> in <paramref name="list"/>.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="list"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="index"/> is not a valid position in <paramref name="list"/>.</exception>
        public static T Get<T>(this IReadOnlyList<T> list, int index)
        {
            Validate.ArgumentNotNull(list, nameof(list));
            Validate.ArgumentInRange(index, nameof(index), 0, list.Count - 1);

            return list[index];
        }

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="list"/>
        /// or <paramref name="value"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="list"/>.</typeparam>
        /// 
        /// <param name="list">The list of elements.</param>
        /// <param name="index">The index of the element in <paramref name="list"/>.</param>
        /// <param name="value">The value to return if <paramref name="index"/> is not valid.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or <paramref name="value"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this IReadOnlyList<T> list, int index, T value)
            => GetOrElse(list, index, () => value);

        /// <summary>
        /// Gets the element at position <paramref name="index"/> in <paramref name="list"/>
        /// or the value generated by <paramref name="function"/> if the index is out of bounds.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of <paramref name="list"/>.</typeparam>
        /// 
        /// <param name="list">The list of elements.</param>
        /// <param name="index">The index of the element in <paramref name="list"/>.</param>
        /// <param name="function">The function that will generate the value if <paramref name="index"/> is out of bounds.</param>
        /// 
        /// <returns>The value at <paramref name="index"/> or the result of <paramref name="function"/> if the index is not valid.</returns>
        public static T GetOrElse<T>(this IReadOnlyList<T> list, int index, Func<T> function)
        {
            if (list != null && 0 <= index && index <= list.Count - 1)
            {
                return list[index];
            }
            else
            {
                return function();
            }
        }
        #endregion
    }
}
