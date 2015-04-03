namespace Simit.Extensions
{
    #region Using Directives

    using System;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class DateExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Displays the date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string DisplayDate(this DateTime dateTime)
        {
            if (dateTime.Date == DateTime.Now.Date)
                return String.Format("{0:HH:mm}", dateTime);
            else
                return String.Format("{0:dd.MM.yyyy HH:mm}", dateTime);
        }

        /// <summary>
        /// Displays the date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string DisplayDate(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return DisplayDate(dateTime.Value);

            return string.Empty;
        }

        /// <summary>
        /// Displays the short date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string DisplayShortDate(this DateTime dateTime)
        {
            return String.Format("{0:dd.MM.yyyy}", dateTime);
        }

        /// <summary>
        /// Displays the short date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string DisplayShortDate(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return DisplayShortDate(dateTime.Value);

            return string.Empty;
        }

        #endregion Public Static Methods
    }
}