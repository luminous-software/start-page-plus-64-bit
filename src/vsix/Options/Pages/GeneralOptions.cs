namespace StartPagePlus.Options.Pages
{
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Community.VisualStudio.Toolkit;

    using static StartPagePlus.Options.Pages.PageConstants;

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class General : BaseOptionPage<GeneralOptions> { }
    }

    public class GeneralOptions : BaseOptionModel<GeneralOptions>
    {
        public const string Category = "General";

        [Category(H1 + PackageName)]
        [DisplayName(EnableStartPagePlusDispayName)]
        [Description(EnableStartPagePlusDescription)]
        public bool EnableStartPagePlus { get; set; } = EnableStartPagePlusDefault;

        [Category(H1 + PackageName)]
        [DisplayName(EnableOptionsMenuItemDispayName)]
        [Description(EnableOptionsMenuItemDescription)]
        public bool EnableStartPagePlusOptions { get; set; } = EnableStartPagePlusOptionsDefault;

        [Category(H1 + PackageName)]
        [DisplayName(PageConstants.PackageVersion)]
        [Description("Installed '" + PackageName + "' version")]
        public string PackageVersion { get; } = Vsix.Version;

        [Category(H2 + PageConstants.Settings)]
        [DisplayName(MaxWidthDisplayName)]
        [Description(MaxWidthDescription)]
        public int MaxWidth { get; set; } = MaxWidthDefault;

        [Category(H2 + PageConstants.Settings)]
        [DisplayName(ShowStartTabTitleDisplayName)]
        [Description(ShowStartTabTitleDescription)]
        public bool ShowStartTabTitle { get; set; } = ShowStartTabTitleDefault;

        [Category(H2 + PageConstants.Settings)]
        [DisplayName(StartTabTitleTextDisplayName)]
        [Description(StartTabTitleTextDescription)]
        public string StartTabTitleText { get; set; } = StartTabTitleDefault;
    }
}