namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion Using Directives

    public static class LinqExtensions
    {
        #region Public Static Methods

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        #endregion Public Static Methods
    }
}