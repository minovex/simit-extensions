namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class EquityExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static bool CheckForEquality<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> destination)
        {
            if (source.Count() != destination.Count())
            {
                return false;
            }

            foreach (var kvp in source)
            {
                TValue destinationValue;
                if (!destination.TryGetValue(kvp.Key, out destinationValue))
                    return false; // key missing in destination
                if (!Equals(kvp.Value, destinationValue))
                    return false; // value is different
            }
            return true;
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static bool CheckForEquality<T>(this string[] source, string[] destination)
        {
            if (source.Count() != destination.Count())
            {
                return false;
            }

            foreach (var item in source)
            {
                bool exists = Array.Exists<string>
                       (
                       destination,
                       delegate(string s) { return s == item; }
                       );
                if (!exists)
                    return false;
            }
            return true;
        }

        #endregion Public Static Methods
    }
}