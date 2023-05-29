using System.ComponentModel;
using System.Runtime.InteropServices;

using Community.VisualStudio.Toolkit;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.Options.Pages
{
    using static Pages.PageConstants;

    //---

    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class StartItems : BaseOptionPage<StartItemsOptions> { }
    }

    //---

    public class StartItemsOptions : BaseOptionModel<StartItemsOptions>
    {
        public const string Category = "Start Items";

        //---

        public StartItemsOptions() : base()
        {
            Saved += OnSaved;
        }

        //---

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

        //---

        private void OnSaved(StartItemsOptions options)
        {
            VS.StatusBar.ShowMessageAsync("Start Items Settings Saved").FireAndForget();
        }
    }
}