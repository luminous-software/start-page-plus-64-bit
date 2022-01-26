namespace StartPagePlus.Options.Pages
{
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Community.VisualStudio.Toolkit;

    using static StartPagePlus.Options.Pages.PageConstants;

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class RecentItems : BaseOptionPage<RecentItemsOptions> { }
    }

    public class RecentItemsOptions : BaseOptionModel<RecentItemsOptions>
    {
        public const string Category = "Recent Items";

        [Category(PageConstants.Settings)]
        [DisplayName(RecentItemsToDisplayDisplayName)]
        [Description(RecentItemsToDisplayDescription)]
        public int ItemsToDisplay { get; set; } = RecentItemsToDisplayDefault;

        [Category(PageConstants.Settings)]
        [DisplayName(ShowFileExtensionsDisplayName)]
        [Description(ShowFileExtensionsDescription)]
        public bool ShowFileExtensions { get; set; } = ShowFileExtensionsDefault;

        [Category(PageConstants.Settings)]
        [DisplayName(ShowFilePathsDisplayName)]
        [Description(ShowFilePathsDescription)]
        public bool ShowFilePaths { get; set; } = ShowFilePathsDefault;

        [Category(PageConstants.Settings)]
        [DisplayName(DisplayRecentItemsName)]
        [Description(DisplayRecentItemsDescription)]
        public bool DisplayRecentItems { get; set; } = DisplayRecentItemsDefault;
    }
}