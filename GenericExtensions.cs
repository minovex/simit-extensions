	namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class GenericExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Creates the groupped array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="part">The part.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">items must be have any items</exception>
        public static List<List<T>> CreateGrouppedArray<T>(this IList<T> items, int part)
        {
            if (items.Count == 0) throw new InvalidOperationException("items must be have any items");

            List<List<T>> arrays = new List<List<T>>();
            List<T> partList = null;
            int mod = items.Count % part;

            for (int i = 0; i < items.Count; i++)
            {
                if (i == 0 || i % part == 0)
                {
                    partList = new List<T>();
                }

                partList.Add(items[i]);

                if (partList.Count == part || i == items.Count - 1)
                {
                    arrays.Add(partList);
                }
            }
            return arrays;
        }

        /// <summary>
        /// To the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
        {
            var collection = new Collection<T>();
            foreach (T i in enumerable)
                collection.Add(i);
            return collection;
        }

        /// <summary>
        /// To the dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary<T>(this T item) where T : class
        {
            Type type = typeof(T);
            return item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(prop => prop.Name, prop => prop.GetValue(item, null));
        }

        #endregion Public Static Methods
    }
}