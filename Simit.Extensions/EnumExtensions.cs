namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion Using Directives

    /// <summary>
    /// http://hugoware.net/blog/enums-flags-and-csharp
    /// </summary>
    public static class EnumExtensions
    {
        #region Publc Static Methods

        //checks if the value contains the provided type
        /// <summary>
        /// Determines whether [has] [the specified type].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool Has<T>(this System.Enum type, T value)
        {
            try
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
            catch
            {
                return false;
            }
        }

        //checks if the value is only the provided type
        /// <summary>
        /// Determines whether [is] [the specified type].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool Is<T>(this System.Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        //appends a value
        /// <summary>
        /// Adds the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static T Add<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type | (int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        //completely removes the value
        /// <summary>
        /// Removes the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static T Remove<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type & ~(int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        /// <summary>
        /// Enums to dictionary.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDictionary<TEnum>(this TEnum enumeration) where TEnum : struct
        {
            Type type = typeof(TEnum);
            return Enum.GetValues(type).Cast<int>().ToDictionary(e => e, e => Enum.GetName(type, e));
        }

        /// <summary>
        /// Enums to dictionary.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.InvalidCastException">object is not an Enumeration</exception>
        public static Dictionary<int, string> EnumToDictionary(this Type type)
        {
            if (type == null) throw new NullReferenceException();
            if (!type.IsEnum) throw new InvalidCastException("object is not an Enumeration");

            return Enum.GetValues(type).Cast<int>().ToDictionary(e => e, e => Enum.GetName(type, e));
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns></returns>
        public static int ToInt(this Enum enumValue)
        {
            return (int)((object)enumValue);
        }

        #endregion Publc Static Methods
    }
}