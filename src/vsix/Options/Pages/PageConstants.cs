namespace StartPagePlus.Options.Pages
{
    using static Core.Strings.Constants;

    public static class PageConstants
    {
        //YD: change all of these constant declarations to internal

        public const string H1 = "1." + Space;
        public const string H2 = "2." + Space;
        public const string H3 = "3." + Space;
        public const string Feature = "Feature";
        public const string Features = "Features";
        public const string FeatureSet = "Feature Set";
        public const string Enable = "Enable";
        public const string Enabled = "Enabled";
        public const string EnablesDisables = "Enables/disables";
        public const string EnablesDisablesAll = EnablesDisables + Space + "ALL";
        public const string Settings = "Settings";

        // package

        public const string PackageName = Vsix.Name;
        public const string PackageFeatureSet = PackageName + Space + FeatureSet;

        // Start Page+

        public const string EnableStartPagePlusDispayName = "Enable '" + PackageName + "'";
        public const string EnableStartPagePlusDescription = "Allows the whole set of '" + PackageName + "' features to be turned off together";
        internal const bool EnableStartPagePlusDefault = true;

        public const string EnableOptionsMenuItemDispayName = "Enable '" + PackageName + "' Options";
        public const string EnableOptionsMenuItemDescription = "Determines if a menu item to open the options page is added to the Tools | Options menu";
        internal const bool EnableStartPagePlusOptionsDefault = true;

        public const string PackageVersion = "Version Number";

        public const string MaxWidthDisplayName = "Max Width";
        public const string MaxWidthDescription = "Sets the max width of contents of the Start Page+ window";
        internal const int MaxWidthDefault = 1280;

        // Start Tab

        public const string ShowStartTabTitleDisplayName = "Show 'Start' Tab Title";
        public const string ShowStartTabTitleDescription = "Sets the visibility of the title in the 'Start' tab";
        internal const bool ShowStartTabTitleDefault = true;

        public const string StartTabTitleTextDisplayName = "'Start' Tab Title Text";
        public const string StartTabTitleTextDescription = "Sets the text of the 'Start' tab title";
        internal const string StartTabTitleDefault = "What would you like to do today?";

        // Recent Items

        public const string RecentItemsToDisplayDisplayName = "Items To Display";
        public const string RecentItemsToDisplayDescription = "Sets the number of items to display in the 'Recent Items' list";
        internal const int RecentItemsToDisplayDefault = 50;

        public const string ShowFileExtensionsDisplayName = "Show File Extensions";
        public const string ShowFileExtensionsDescription = "Sets the visibility of project/solution extensions in the 'Recent Items' list";
        internal const bool ShowFileExtensionsDefault = false;

        public const string DisplayRecentItemsName = "Display 'Recent Items' list";
        public const string DisplayRecentItemsDescription = "Sets the visibility of the 'Recent Items' list";
        internal const bool DisplayRecentItemsDefault = true;
    }
}