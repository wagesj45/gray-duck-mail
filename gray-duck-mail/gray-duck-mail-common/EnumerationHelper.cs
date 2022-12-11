using System;
using System.Collections.Generic;
using System.Linq;

namespace GrayDuckMail.Common
{
    /// <summary> A class that contains methods for managing <see cref="Enum"/> objects. </summary>
    public static class EnumerationHelper
    {
        #region Methods

        /// <summary> Gets enumeration value from its integer value. </summary>
        /// <typeparam name="T"> Generic type parameter representing an enumeration. </typeparam>
        /// <param name="value"> The integer value. </param>
        /// <returns> The enumeration value. </returns>
        public static T GetEnumerationValue<T>(int value) where T : struct, Enum
        {
            if (value >= 0)
            {
                return (T)(object)value;
            }

            return default(T);
        }

        /// <summary> Gets enumeration value from a string value. </summary>
        /// <typeparam name="T"> Generic type parameter represending an enumeration. </typeparam>
        /// <param name="value"> The string value. </param>
        /// <returns> The enumeration value. </returns>
        public static T GetEnumerationValue<T>(string value) where T : struct, Enum
        {
            foreach (var t in DeconstructNonDefault<T>())
            {
                var match = string.Equals(t.GetName(), value, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(t.GetPrettyName(), value, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(t.GetName(), value.Replace(" ", ""));

                if (match)
                {
                    return t;
                }
            }

            return default(T);
        }

        /// <summary>
        /// An Enum extension method that deconstructs the given enumeration into a dictionary of its
        /// integer value and its name.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns>
        /// An enumerator that allows foreach to be used to process deconstruct in this collection.
        /// </returns>
        public static IEnumerable<T> Deconstruct<T>() where T : struct, Enum
        {
            var dictionary = new Dictionary<int, string>();
            var enumerationType = typeof(T);

            foreach (var e in Enum.GetValues(enumerationType))
            {
                yield return (T)e;
            }
        }

        /// <summary>
        /// An Enum extension method that deconstructs the given enumeration into a dictionary of its
        /// integer value and its name.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="enumeration"> The enumeration to act on. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process deconstruct in this collection.
        /// </returns>
        public static IEnumerable<T> Deconstruct<T>(this T enumeration) where T : struct, Enum
        {
            return Deconstruct<T>();
        }

        /// <summary> An Enum extension method that deconstruct non default. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns>
        /// An enumerator that allows foreach to be used to process deconstruct non default in this
        /// collection.
        /// </returns>
        public static IEnumerable<T> DeconstructNonDefault<T>() where T : struct, Enum
        {
            return Deconstruct<T>().Where(item => item.GetValue() != 0);
        }

        /// <summary> An Enum extension method that deconstruct non default. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="enumeration"> The enumeration to act on. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process deconstruct non default in this
        /// collection.
        /// </returns>
        public static IEnumerable<T> DeconstructNonDefault<T>(this T enumeration) where T : struct, Enum
        {
            return DeconstructNonDefault<T>();
        }

        #endregion Methods
    }
}