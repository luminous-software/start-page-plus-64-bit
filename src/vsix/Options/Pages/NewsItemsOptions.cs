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
        public const string Category = @"News Items";

        //--- appearance

        [Category(H1 + PageConstants.Appearance)]
        [DisplayName(NewsItemsFeedUrlDisplayName)]
        [Description(NewsItemsFeedUrlDescription)]
        public string NewsItemsFeedUrl { get; set; } = NewsItemsFeedUrlDefault;

        [Category(H1 + PageConstants.Appearance)]
        [DisplayName(NewsItemsToDisplayDisplayName)]
        [Description(NewsItemsToDisplayDescription)]
        public int NewsItemsToDisplay { get; set; } = NewsItemsToDisplayDefault;

        //[Category(H1 + PageConstants.Appearance)]
        //[DisplayName(DisplayNewsItemsName)]
        //[Description(DisplayNewsItemsDescription)]
        //public bool DisplayNewsItems { get; set; } = DisplayNewsItemsDefault;

        //--- behavior

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(ClearListBeforeRefreshDisplayName)]
        [Description(ClearListBeforeRefreshDescription)]
        public bool ClearListBeforeRefresh { get; set; } = ClearListBeforeRefreshDefault;

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(OpenLinksInVsDisplayName)]
        [Description(OpenLinksInVsDescription)]
        public bool OpenLinksInVS { get; set; } = OpenLinksInVsDefault;

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(ShowNewsItemTooltipDisplayName)]
        [Description(ShowNewsItemTooltipDescription)]
        public bool ShowNewsItemTooltip { get; set; } = ShowNewsItemTooltipDefault;

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(NewsItemTooltipDelayDisplayName)]
        [Description(NewsItemTooltipDelayDescription)]
        public int NewsItemTooltipDelay { get; set; } = NewsItemTooltipDelayDefault;
    }
}