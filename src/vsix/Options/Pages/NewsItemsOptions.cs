namespace StartPagePlus.Options.Pages
{
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Community.VisualStudio.Toolkit;

    using static StartPagePlus.Options.Pages.PageConstants;

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class NewsItems : BaseOptionPage<NewsItemsOptions> { }
    }

    public class NewsItemsOptions : BaseOptionModel<NewsItemsOptions>
    {
        public const string Category = @"Developer News";

        [Category(PageConstants.Settings)]
        [DisplayName(ClearListBeforeRefreshDisplayName)]
        [Description(ClearListBeforeRefreshDescription)]
        public bool ClearListBeforeRefresh { get; set; } = true;

        [Category(PageConstants.Settings)]
        [DisplayName(NewsItemsFeedUrlDisplayName)]
        [Description(NewsItemsFeedUrlDescription)]
        public string NewsItemsFeedUrl { get; set; } = "https://vsstartpage.blob.core.windows.net/news/vs";

        [Category(PageConstants.Settings)]
        [DisplayName(NewsItemsToDisplayDisplayName)]
        [Description(NewsItemsToDisplayDescription)]
        public int NewsItemsToDisplay { get; set; } = 10;

        [Category(PageConstants.Settings)]
        [DisplayName(OpenLinksInVsDisplayName)]
        [Description(OpenLinksInVsDescription)]
        public bool OpenLinksInVS { get; set; } = true;
    }
}