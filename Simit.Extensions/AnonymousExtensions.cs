namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class AnonymousExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Anonymouses to dictionary.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static IDictionary<string, object> AnonymousToDictionary(this object obj)
        {
            return TypeDescriptor.GetProperties(obj)
                .OfType<PropertyDescriptor>()
                .ToDictionary(
                    prop => prop.Name,
                    prop => prop.GetValue(obj)
                );
        }

        /// <summary>
        /// Anonymouses to dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="valueSelect">The value select.</param>
        /// <returns></returns>
        public static IDictionary<string, T> AnonymousToDictionary<T>(this object obj, Func<object, T> valueSelect)
        {
            return TypeDescriptor.GetProperties(obj)
                .OfType<PropertyDescriptor>()
                .ToDictionary<PropertyDescriptor, string, T>(
                    prop => prop.Name,
                    prop => valueSelect(prop.GetValue(obj))
                );
        }

        #endregion Public Static Methods
    }
}