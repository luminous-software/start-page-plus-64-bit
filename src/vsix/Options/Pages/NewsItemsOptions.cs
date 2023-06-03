using System.ComponentModel;
using System.Runtime.InteropServices;

using Community.VisualStudio.Toolkit;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.Options.Pages
{
    using DI;

    using UI.Messages;

    using static Options.Pages.PageConstants;

    //---

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class NewsItems : BaseOptionPage<NewsItemsOptions> { }
    }

    //---

    public class NewsItemsOptions : BaseOptionModel<NewsItemsOptions>
    {
        public const string Category = @"News Items";

        //---

        public NewsItemsOptions() : base()
        {
            Saved += OnSaved;
        }

        //--- appearance

        [Category(H1 + PageConstants.Appearance)]
        [DisplayName(NewsItemsFeedUrlDisplayName)]
        [Description(NewsItemsFeedUrlDescription)]
        public string NewsItemsFeedUrl { get; set; } = NewsItemsFeedUrlDefault;

        [Category(H1 + PageConstants.Appearance)]
        [DisplayName(NewsItemsToDisplayDisplayName)]
        [Description(NewsItemsToDisplayDescription)]
        public int NewsItemsToDisplay { get; set; } = NewsItemsToDisplayDefault;

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

        //---

        private void OnSaved(NewsItemsOptions options)
        {
            var container = StartPagePlusContainer.Instance;
            var messenger = container.GetInstance<IMessenger>();

            messenger.Send<RefreshNewsItems>();
        }
    }
}