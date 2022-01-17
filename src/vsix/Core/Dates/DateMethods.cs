namespace StartPagePlus.Core.Dates
{
    using System;
    using System.Globalization;

    public static class DateMethods
    {
        public static string DateToString(DateTime dateValue, string format, CultureInfo culture = null)
            => dateValue.ToString(format, culture ?? CultureInfo.CurrentCulture);
    }
}