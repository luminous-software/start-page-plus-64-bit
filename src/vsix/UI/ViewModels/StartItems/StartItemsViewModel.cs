namespace StartPagePlus.UI.ViewModels.StartItems
{
    using System.Collections.Generic;

    using Community.VisualStudio.Toolkit;

    using StartPagePlus.Options.Pages;
    using StartPagePlus.UI.Interfaces.StartItems;

    public class StartItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";
        private const string WEBSITE_URL = "https://luminous-software.solutions/start-page-plus-64-bit";
        private const string CHANGELOG_URL = WEBSITE_URL + "/changelog";
        private List<StartItemViewModel> items = new List<StartItemViewModel>();

        public StartItemsViewModel(IStartItemDataService dataService, IStartItemCommandService commandService) : base() //, IVisualStudioService vsService)
        {
            DataService = dataService;
            CommandService = commandService;
            //VisualStudioService = vsService;
            Heading = HEADING;
            IsVisible = true;
            GetCommands();
            Refresh();
        }

        public IStartItemDataService DataService { get; }

        public IStartItemCommandService CommandService { get; }

        //public IVisualStudioService VisualStudioService { get; }

        public List<StartItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(OpenChangelog, OpenWebsite, OpenOptions);

        private bool OpenLinksInVS
            => true; // NewsItemsOptions.Instance.OpenLinksInVS;

        private void OpenChangelog()
        { }
        //=> VisualStudioService.OpenWebPage(CHANGELOG_URL, OpenLinksInVS);

        private void OpenWebsite()
        { }
        //=> VisualStudioService.OpenWebPage(WEBSITE_URL, OpenLinksInVS);

        private void OpenOptions()
            => VS.Settings.OpenAsync<OptionsProvider.General>();

        private void Refresh()
        {
            Items.Clear();
            Items = DataService.GetItems();
        }
    }
}