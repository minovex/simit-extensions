namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class ReflectionExtensions
    {
        #region Static Methods

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member">The member.</param>
        /// <param name="isRequired">if set to <c>true</c> [is required].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static T GetAttribute<T>(this MemberInfo member, bool isRequired) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));
            }

            return (T)attribute;
        }

        /// <summary>
        /// Gets the display name of the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">No property reference expression was found.;propertyExpression</exception>
        public static string GetPropertyDisplayName<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }

            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
            if (attr == null)
            {
                return memberInfo.Name;
            }

            return attr.DisplayName;
        }

        /// <summary>
        /// Gets the property information.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">propertyExpression </exception>
        public static MemberInfo GetPropertyInformation(Expression propertyExpression)
        {
            if (propertyExpression == null) throw new ArgumentNullException("propertyExpression ");
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member;
            }

            return null;
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="assemblyFile">The assembly file.</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string typeName, string assemblyFile)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            Type type = assembly.GetType(typeName);
            return (T)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Maps the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static T Map<T>(this object item) where T : class
        {
            Type targetType = typeof(T);
            Type itemType = item.GetType();

            T mappedItem = Activator.CreateInstance<T>();

            PropertyInfo[] properties = targetType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                PropertyInfo targetProperty = itemType.GetProperty(property.Name);
                if (targetProperty != null)
                {
                    if (targetProperty.PropertyType != property.PropertyType)
                    {
                        throw new Exception(string.Format("{0}'s type is not equals {1}'s", property.Name, targetProperty.Name));
                    }

                    object value = targetProperty.GetValue(item, null);
                    property.SetValue(mappedItem, value, null);
                }
            }

            return mappedItem;
        }

        #endregion Static Methods
    }
}