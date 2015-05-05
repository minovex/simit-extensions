namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    #endregion Using Directives

    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Determines whether the specified value is decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsDecimal(this string value)
        {
            decimal temp;
            CultureInfo culture = CultureInfo.InvariantCulture;

            return decimal.TryParse(value, NumberStyles.Float, culture.NumberFormat, out temp);
        }

        /// <summary>
        /// Determines whether the specified value is decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static bool IsDecimal(this string value, string cultureName)
        {
            decimal num;
            CultureInfo info = new CultureInfo(cultureName);
            return decimal.TryParse(value, NumberStyles.Float, info.NumberFormat, out num);
        }

        /// <summary>
        /// Determines whether [is emtpy or null] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsEmtpyOrNull(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Determines whether the specified value is float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static bool IsFloat(this string value, string cultureName)
        {
            float num;
            CultureInfo info = new CultureInfo(cultureName);
            return float.TryParse(value, NumberStyles.Float, (IFormatProvider)info.NumberFormat, out num);
        }

        /// <summary>
        /// Determines whether the specified value is unique identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsGuid(this string value)
        {
            string pattern = @"\{?[a-fA-F\d]{8}-([a-fA-F\d]{4}-){3}[a-fA-F\d]{12}\}?$";
            return Regex.Match(value, pattern).Success;
        }

        /// <summary>
        /// Determines whether the specified value is int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsInt(this string value)
        {
            int num;
            return int.TryParse(value, out num);
        }

        /// <summary>
        /// Determines whether the specified value is long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsLong(this string value)
        {
            long num;
            return long.TryParse(value, out num);
        }

        /// <summary>
        /// Determines whether the specified s is email.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static bool IsEmail(this string s)
        {
            Regex EmailExpression = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.Compiled | RegexOptions.Singleline);

            return !string.IsNullOrEmpty(s) && EmailExpression.IsMatch(s);
        }

        /// <summary>
        /// Determines whether [is date time] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static bool IsDateTime(this string value, string cultureName)
        {
            DateTime temp;
            CultureInfo culture = new CultureInfo(cultureName);

            return (DateTime.TryParse(value, culture.DateTimeFormat, DateTimeStyles.None, out temp));
        }

        /// <summary>
        /// Determines whether [is email address] [the specified eamil].
        /// </summary>
        /// <param name="eamil">The eamil.</param>
        /// <returns></returns>
        public static bool IsEmailAddress(this string eamil)
        {
            if (string.IsNullOrEmpty(eamil)) return false;

            return Regex.Match(eamil, "^[a-zA-Z0-9]+[a-zA-Z0-9_.-]+[a-zA-Z0-9_-]+@[a-zA-Z0-9]+[a-zA-Z0-9.-]+[a-zA-Z0-9]+.[a-z]{2,4}$").Success;
        }

        /// <summary>
        /// Determines whether the specified value is hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static bool IsHash(this string value, int length)
        {
            return Regex.IsMatch(value, "[0-9a-f]{" + length + "}");
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            decimal temp;
            CultureInfo culture = CultureInfo.InvariantCulture;

            if (decimal.TryParse(value, NumberStyles.Float, culture.NumberFormat, out temp))
                return temp;
            else
                return (decimal)0.0;
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value, string cultureName)
        {
            decimal num;
            CultureInfo info = new CultureInfo(cultureName);
            if (decimal.TryParse(value, NumberStyles.Float, info.NumberFormat, out num))
            {
                return num;
            }
            return 0M;
        }

        /// <summary>
        /// To the float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static float ToFloat(this string value, string cultureName)
        {
            float num;
            CultureInfo info = new CultureInfo(cultureName);
            if (float.TryParse(value, NumberStyles.Float, (IFormatProvider)info.NumberFormat, out num))
            {
                return num;
            }
            return 0f;
        }

        /// <summary>
        /// To the unique identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Guid ToGuid(this string value)
        {
            return new Guid(value);
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        /// To the long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            return long.Parse(value);
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, string cultureName)
        {
            DateTime temp;
            CultureInfo culture = new CultureInfo(cultureName);

            if (DateTime.TryParse(value, culture.DateTimeFormat, DateTimeStyles.None, out temp))
                return temp;
            else
                return DateTime.Now;
        }

        /// <summary>
        /// To the date time nullable.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(this string value, string cultureName)
        {
            DateTime temp;
            CultureInfo culture = new CultureInfo(cultureName);

            if (DateTime.TryParse(value, culture.DateTimeFormat, DateTimeStyles.None, out temp))
                return temp;
            else
                return null;
        }
        /// <summary>
        /// To the seo text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <exception cref="System.ArgumentException">Cleared text cannot be converted SEO text</exception>
        public static string ToSEOText(this string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");

            // bu adresten alindi http://stackoverflow.com/a/4282366

            string slug = value.ToLower();

            slug = slug.Replace("ç", "c");
            slug = slug.Replace("ş", "s");
            slug = slug.Replace("ı", "i");
            slug = slug.Replace("ü", "u");
            slug = slug.Replace("ğ", "g");
            slug = slug.Replace("ö", "o");
            slug = slug.Replace("#", "");

            slug = Regex.Replace(slug, @"[^a-z0-9\-_\./\\ ]+", "");
            slug = Regex.Replace(slug, @"[^a-z0-9]+", "-");

            if (string.IsNullOrEmpty(slug)) throw new ArgumentException("Cleared text cannot be converted SEO text");

            if (slug[slug.Length - 1] == '-')
                slug = slug.Remove(slug.Length - 1, 1);
            return slug;
        }

        /// <summary>
        /// To the name of the e mail friendly.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="addEmailAddressToName">if set to <c>true</c> [add email address to name].</param>
        /// <returns></returns>
        public static string ToEMailFriendlyName(this string email, string name, bool addEmailAddressToName)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string emailAddressName = textInfo.ToTitleCase(email.Substring(0, email.IndexOf("@")));

            return string.Format("{0} <{1}>", !addEmailAddressToName ? name : string.Format("{0} {1}", name, emailAddressName), email);
        }

        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfoName">Name of the culture information.</param>
        /// <returns></returns>
        public static string ToTitleCase(this string value, string cultureInfoName)
        {
            var cultureInfo = new System.Globalization.CultureInfo(cultureInfoName);
            return value.ToTitleCase(cultureInfo);
        }

        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns></returns>
        public static string ToTitleCase(this string value, CultureInfo cultureInfo)
        {
            return cultureInfo.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Separates the by capital character.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="separate">The separate.</param>
        /// <returns></returns>
        public static string SeparateByCapitalChar(this string text, string separate)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in text)
            {
                if (Char.IsUpper(c) && builder.Length > 0) builder.Append(separate);
                builder.Append(c);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Strings the formatter extension.
        /// </summary>
        /// <param name="formattedText">The formatted text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static string StringFormatterExtension(this string formattedText, Dictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Keys.Count > 0)
            {
                string replaceFormat = "%{0}%";
                foreach (string key in parameters.Keys)
                {
                    formattedText = formattedText.Replace(string.Format(replaceFormat, key), parameters[key]);
                }
            }

            return formattedText;
        }

        /// <summary>
        /// Determines whether the specified value has capitals.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool HasCapitals(this string value)
        {
            foreach (char c in value)
            {
                if (char.IsUpper(c)) return true;
            }
            return false;
        }

        /// <summary>
        /// Clears the HTML tags.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public static string ClearHtmlTags(this string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");

            string replacedData = Regex.Replace(value, @"<[^>]*>", "");
            return replacedData;
        }

        #endregion Public Static Methods
    }
}