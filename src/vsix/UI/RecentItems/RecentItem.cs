namespace StartPagePlus.UI.Models
{
    using System;
    using System.IO;

    using StartPagePlus.UI.Enums;
    using StartPagePlus.UI.ViewModels;

    using static StartPagePlus.UI.Enums.PeriodTypes;
    using static StartPagePlus.UI.Enums.RecentItemTypes;

    public class RecentItem
    {
        public RecentItem()
        { }

        public string Key { get; set; }

        public RecentItemValue Value { get; set; }

        public RecentItemViewModel CreateViewModel(DateTime today, bool showExtension, bool showPath)
        {
            var path = Value.LocalProperties.FullPath;
            var date = Value.LastAccessed.Date;
            var name = showExtension
                ? Path.GetFileName(path)
                : Path.GetFileNameWithoutExtension(path);
            var pinned = Value.IsFavorite;
            var folder = showPath
                ? Path.GetDirectoryName(path)
                : "";
            var period = CalculatePeriodType(pinned, today, date);
            var type = path.CalculateRecentItemType();
            var moniker = type.ToImageMoniker();

            return new RecentItemViewModel
            {
                Name = name,
                Description = folder,
                Date = date,
                Path = path,
                Pinned = pinned,
                PeriodType = period,
                ItemType = type,
                Moniker = moniker
            };
        }
    }
}