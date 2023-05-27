namespace StartPagePlus.Options.Pages
{
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Community.VisualStudio.Toolkit;

    using static StartPagePlus.Options.Pages.PageConstants;

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class StartItems : BaseOptionPage<StartItemsOptions> { }
    }

    public class StartItemsOptions : BaseOptionModel<StartItemsOptions>
    {
        public const string Category = "Start Items";

        [Category(H1 + PageConstants.Behavior)]
        [DisplayName(CloneRepositoryDelayDisplayName)]
        [Description(CloneRepositoryDelayDescription)]
        public int CloneRepositoryDelay { get; set; } = CloneRepositoryDelayDefault;

        [Category(H1 + PageConstants.Behavior)]
        [DisplayName(OpenFolderDelayDisplayName)]
        [Description(OpenFolderDelayDescription)]
        public int OpenFolderDelay { get; set; } = OpenFolderDelayDefault;

        [Category(H1 + PageConstants.Behavior)]
        [DisplayName(OpenProjectDelayDisplayName)]
        [Description(OpenProjectDelayDescription)]
        public int OpenProjectDelay { get; set; } = OpenProjectDelayDefault;

        [Category(H1 + PageConstants.Behavior)]
        [DisplayName(CreateProjectDelayDisplayName)]
        [Description(CreateProjectDelayDescription)]
        public int CreateProjectDelay { get; set; } = CreateProjectDelayDefault;
    }
}