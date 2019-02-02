using System;

namespace Konvenience
{
    /// <summary>
    /// Class containting convenience extension methods.
    /// </summary>
    /// 
    /// These are based on the extension methods found in Kotlin's
    /// standard library.
    public static class Core
    {
        /// <summary>
        /// Executes the specified action in the input object.
        /// </summary>
        /// 
        /// <example>
        /// One case where this is useful is for example complicated initializations
        /// that require methods other van properties.
        /// 
        /// <code>
        /// var myObject = new MyClass().also(obj =>
        /// {
        ///     obj.MyProperty = 32;
        ///     obj.Setup();
        ///     obj.Configure();
        /// });
        /// </code>
        /// </example>
        /// 
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// 
        /// <param name="obj">The input object.</param>
        /// <param name="action">The action to be executed.</param>
        /// 
        /// <returns>The input object.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="action"/> is null.</exception>
        public static T Also<T>(this T obj, Action<T> action)
        {
            AssertArgumentNotNull(action, "action");

            action(obj);

            return obj;
        }

        /// <summary>
        /// Returns the result of executing the function with the input action.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// <typeparam name="TResult">The type of the object to be returned.</typeparam>
        /// 
        /// <param name="obj">The input object.</param>
        /// <param name="function">The function to be executed.</param>
        /// 
        /// <returns>The result of executing the function with the input object.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="function"/> is null.</exception>
        public static TResult Let<T, TResult>(this T obj, Func<T, TResult> function)
        {
            AssertArgumentNotNull(function, "function");

            return function(obj);
        }

        /// <summary>
        /// Returns the input object if the predicate is true for that object, null otherwise.
        /// </summary>
        /// 
        /// <example>
        /// One case where this is useful is if you want a default value:
        /// 
        /// void MyMethod(String argument)
        /// {
        ///     argument = argument?.TakeReferenceIf(arg => arg.Length == 0) ?? "Default Value";
        ///     // Argument will never be null or empty...
        /// }
        /// </example>
        /// 
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// 
        /// <param name="obj">The input object.</param>
        /// <param name="predicate">The predicate to be execute.</param>
        /// 
        /// <returns>The input object if the predicate is true for it, null otherwise.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="predicate"/> is null.</exception>
        public static T TakeReferenceIf<T>(this T obj, Predicate<T> predicate) where T : class
        {
            AssertArgumentNotNull(predicate, "predicate");

            if (!predicate(obj))
            {
                return null;
            }

            return obj;
        }

        /// <summary>
        /// Returns the input object if the predicate is false for that object, null otherwise.
        /// </summary>
        /// 
        /// This is an inverse version of <see cref="TakeReferenceIf"/>.
        /// 
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// 
        /// <param name="obj">The input object.</param>
        /// <param name="predicate">The predicate to be execute.</param>
        /// 
        /// <returns>The input object if the predicate is false for it, null otherwise.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="predicate"/> is null.</exception>
        public static T TakeReferenceUnless<T>(this T obj, Predicate<T> predicate) where T : class
        {
            AssertArgumentNotNull(predicate, "predicate");

            if (predicate(obj))
            {
                return null;
            }

            return obj;
        }

        /// <summary>
        /// Returns the input object if the predicate is true for that object, null otherwise.
        /// </summary>
        /// 
        /// This is the <see cref="TakeReferenceIf"/> for struct types.
        /// 
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// 
        /// <param name="obj">The input object.</param>
        /// <param name="predicate">The predicate to be execute.</param>
        /// 
        /// <returns>The input object if the predicate is true for it, null otherwise.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="predicate"/> is null.</exception>
        public static T? TakeValueIf<T>(this T obj, Predicate<T> predicate) where T : struct
        {
            AssertArgumentNotNull(predicate, "predicate");

            if (!predicate(obj))
            {
                return null;
            }

            return obj;
        }

        /// <summary>
        /// Returns the input object if the predicate is false for that object, null otherwise.
        /// </summary>
        /// 
        /// This is an inverse version of <see cref="TakeValueIf"/>.
        /// 
        /// <typeparam name="T">The type of the input object.</typeparam>
        /// 
        /// <param name="obj">The input object.</param>
        /// <param name="predicate">The predicate to be execute.</param>
        /// 
        /// <returns>The input object if the predicate is false for it, null otherwise.</returns>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="predicate"/> is null.</exception>
        public static T? TakeValueUnless<T>(this T obj, Predicate<T> predicate) where T : struct
        {
            AssertArgumentNotNull(predicate, "predicate");

            if (predicate(obj))
            {
                return null;
            }

            return obj;
        }

        private static void AssertArgumentNotNull(object argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
