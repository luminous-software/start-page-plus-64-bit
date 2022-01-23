namespace StartPagePlus.Options.Pages
{
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Community.VisualStudio.Toolkit;

    using static StartPagePlus.Options.Pages.Constants;

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
        public bool EnableStartPagePlus { get; set; } = true;

        [Category(H1 + PackageName)]
        [DisplayName(EnableOptionsMenuItemDispayName)]
        [Description(EnableOptionsMenuItemDescription)]
        public bool EnableStartPagePlusOptions { get; set; } = true;

        [Category(H1 + PackageName)]
        [DisplayName(Constants.PackageVersion)]
        [Description("Installed '" + PackageName + "' version")]
        public string PackageVersion { get; } = Vsix.Version;

        [Category(H2 + Constants.Settings)]
        [DisplayName(MaxWidthDisplayName)]
        [Description(MaxWidthDescription)]
        public int MaxWidth { get; set; } = 1280;

        [Category(H2 + Constants.Settings)]
        [DisplayName(ShowStartTabTitleDisplayName)]
        [Description(ShowStartTabTitleDescription)]
        public bool ShowStartTabTitle { get; set; } = true;

        [Category(H2 + Constants.Settings)]
        [DisplayName(StartTabTitleTextDisplayName)]
        [Description(StartTabTitleTextDescription)]
        public string StartTabTitleText { get; set; } = "What would you like to do today?";
    }
}