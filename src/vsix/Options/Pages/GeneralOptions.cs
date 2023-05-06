﻿namespace StartPagePlus.Options.Pages
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

        //--- appearance

        [Category(H2 + PageConstants.Appearance)]
        [DisplayName(MaxWidthDisplayName)]
        [Description(MaxWidthDescription)]
        public int MaxWidth { get; set; } = MaxWidthDefault;

        [Category(H2 + PageConstants.Appearance)]
        [DisplayName(ShowStartTabTitleDisplayName)]
        [Description(ShowStartTabTitleDescription)]
        public bool ShowStartTabTitle { get; set; } = ShowStartTabTitleDefault;

        [Category(H2 + PageConstants.Appearance)]
        [DisplayName(StartTabTitleTextDisplayName)]
        [Description(StartTabTitleTextDescription)]
        public string StartTabTitleText { get; set; } = StartTabTitleDefault;

        //--- behavior

        [Category(H3 + PageConstants.Behavior)]
        [DisplayName(HideOnSolutionOpenDisplayName)]
        [Description(HideOnSolutionOpenDescription)]
        public bool HideOnSolutionOpen { get; set; } = HideOnSolutionOpenDefault;

        [Category(H3 + PageConstants.Behavior)]
        [DisplayName(RestoreOnSolutionCloseDisplayName)]
        [Description(RestoreOnSolutionCloseDescription)]
        public bool RestoreOnSolutionClose { get; set; } = RestoreOnSolutionCloseDefault;
    }
}