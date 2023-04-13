using System.Collections.Generic;

namespace StartPagePlus.UI.ViewModels.StartItems
{

    using Interfaces;
    using Interfaces.StartItems;

    using Options.Pages;

    public class StartItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";
        private const string WEBSITE_URL = "https://luminous-software.solutions/start-page-plus";
        private const string CHANGELOG_URL = WEBSITE_URL + "/changelog";
        private List<StartItemViewModel> items = new();

        public StartItemsViewModel(IStartItemDataService dataService, IStartItemCommandService commandService, IVisualStudioService vsService) : base()
        {
            DataService = dataService;
            CommandService = commandService;
            VisualStudioService = vsService;
            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();
        }

        internal IStartItemDataService DataService { get; }

        internal IStartItemCommandService CommandService { get; }

        public IVisualStudioService VisualStudioService { get; }

        public List<StartItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(OpenChangelog, OpenWebsite, OpenOptions);

        private void OpenChangelog()
            => VisualStudioService.OpenWebPage(CHANGELOG_URL, true);

        private void OpenWebsite()
            => VisualStudioService.OpenWebPage(WEBSITE_URL, true);

        private void OpenOptions()
            => VisualStudioService.ShowOptions<OptionsProvider.General>();

        private void Refresh()
        {
            Items.Clear();
            Items = DataService.GetItems();
        }
    }
}