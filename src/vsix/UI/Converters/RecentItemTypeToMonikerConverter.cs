// usage:
// xmlns:c="clr-namespace:StartPagePlus.UI.Converters"

//<Image Moniker="{Binding RecentItemType, Converter={c:RecentItemTypeToImageMonikerConverter}">

namespace StartPagePlus.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Microsoft.VisualStudio.Imaging.Interop;

    using StartPagePlus.UI.Enums;
    using StartPagePlus.UI.MarkupExtensions;

    [ValueConversion(typeof(RecentItemType), typeof(ImageMoniker))]
    public class RecentItemTypeToImageMonikerConverter : ValueConverterMarkupExtension
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is RecentItemType itemType)
                ? itemType.ToImageMoniker()
                : value;
    };
}