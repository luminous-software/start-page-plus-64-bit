namespace StartPagePlus.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using MarkupExtensions;

    //usage:
    //<Button Content="Cancel" Visibility="{Binding IsCancelVisible, Converter={c:BooleanToVisibilityConverter True="" False="" Reverse=false}">

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToStringConverter : ValueConverterMarkupExtension
    {
        public string True { get; set; } = "True";

        public string False { get; set; } = "False";

        public bool Reverse { get; set; } = false;

        //---

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolValue)
                return value;

            if (Reverse)
            {
                boolValue = !boolValue;
            }

            return boolValue
                ? True
                : False;
        }
    }
}