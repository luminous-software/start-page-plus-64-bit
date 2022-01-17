namespace StartPagePlus.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;

    using StartPagePlus.UI.MarkupExtensions;

    public class TextInputToVisibilityConverter : MultiValueConverterMarkupExtension
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool v1 && values[1] is bool v2)
            {
                bool hasText = !(bool)v1;
                bool hasFocus = (bool)v2;

                if (hasFocus || hasText)
                    return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }
    }
}