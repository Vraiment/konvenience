using System;

namespace Konvenience
{
    /// <summary>
    /// Class to contain common validation methods.
    /// </summary>
    internal static class Validate
    {
        /// <summary>
        /// Validates that <paramref name="argument"/> is not null, and
        /// if it is throws a <see cref="ArgumentNullException"/> with
        /// the given <paramref name="argumentName"/> as message.
        /// </summary>
        /// 
        /// <param name="argument">The argument to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// 
        /// <exception cref="ArgumentNullException">If <paramref name="argument"/> is null.</exception>
        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
