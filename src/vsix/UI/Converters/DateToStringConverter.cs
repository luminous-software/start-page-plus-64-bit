namespace StartPagePlus.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using MarkupExtensions;

    using static Core.Dates.DateMethods;

    // usage:
    // xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

    //Text="{Binding Date, Converter={c:DateToStringConverter Format=d}}"

    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateToStringConverter : ValueConverterMarkupExtension
    {
        public string Format { get; set; } = "d";

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is not DateTime dateValue
                ? value
                : DateToString(dateValue, Format);
    }
}