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

        /// <summary>
        /// Validates that <paramref name="argument"/> is greater
        /// than or equal to <paramref name="min"/> and less than
        /// or equal to <paramref name="max"/> and if it isn't
        /// throws a <see cref="ArgumentOutOfRangeException"/> with
        /// the given <paramref name="argumentName"/> as message.
        /// </summary>
        /// 
        /// <param name="argument">The argument to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="min">The minimum valid value for the argument (inclusive).</param>
        /// <param name="max">The maximum valid value for the argument (inclusive).</param>
        /// 
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="argument"/> is out of range.</exception>
        public static void ArgumentInRange(int argument, string argumentName, int min, int max)
        {
            if (!(min <= argument && argument <= max))
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }
    }
}
