using System.ComponentModel;
using System.Runtime.InteropServices;

using Community.VisualStudio.Toolkit;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.Options.Pages
{
    using DI;

    using UI.Messages;

    using static Pages.PageConstants;

    //---

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class RecentItems : BaseOptionPage<RecentItemsOptions> { }
    }

    //---

    public class RecentItemsOptions : BaseOptionModel<RecentItemsOptions>
    {
        public const string Category = "Recent Items";

        //---

        public RecentItemsOptions() : base()
        {
            Saved += OnSaved;
        }

        //--- appearance

        //[Category(H1 + PageConstants.Appearance)]
        //[DisplayName(DisplayRecentItemsName)]
        //[Description(DisplayRecentItemsDescription)]
        //public bool DisplayRecentItems { get; set; } = DisplayRecentItemsDefault;

        [Category(H1 + PageConstants.Appearance)]
        [DisplayName(RecentItemsToDisplayDisplayName)]
        [Description(RecentItemsToDisplayDescription)]
        public int ItemsToDisplay { get; set; } = RecentItemsToDisplayDefault;

        //--- behavior

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(ShowFileExtensionsDisplayName)]
        [Description(ShowFileExtensionsDescription)]
        public bool ShowFileExtensions { get; set; } = ShowFileExtensionsDefault;

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(ShowFilePathsDisplayName)]
        [Description(ShowFilePathsDescription)]
        public bool ShowFilePaths { get; set; } = ShowFilePathsDefault;

        [Category(H2 + PageConstants.Behavior)]
        [DisplayName(ShowCsProjFilesDisplayName)]
        [Description(ShowCsProjFilesDescription)]
        public bool ShowCsProjFiles { get; set; } = ShowCsProjFilesDefault;

        //---

        private void OnSaved(RecentItemsOptions options)
        {
            var container = StartPagePlusContainer.Instance;
            var messenger = container.GetInstance<IMessenger>();

            messenger.Send<RefreshRecentItems>();
        }
    }
}