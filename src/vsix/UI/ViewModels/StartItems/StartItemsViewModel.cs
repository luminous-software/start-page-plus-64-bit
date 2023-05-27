using System.Collections.Generic;

namespace StartPagePlus.UI.ViewModels.StartItems
{

    using Interfaces;
    using Interfaces.StartItems;

    using Options.Pages;

    public class StartItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";
        private const string WEBSITE_URL = "https://luminous-software.solutions/start-page-plus-64-bit";
        private const string CHANGELOG_URL = WEBSITE_URL + "/changelog";

        private List<StartItemViewModel> items = new();

        private readonly IStartItemDataService _dataService;
        private readonly IStartItemCommandService _commandService;
        private readonly IVisualStudioService _visualStudioService;

        public StartItemsViewModel(IStartItemDataService dataService, IStartItemCommandService commandService, IVisualStudioService vsService) : base()
        {
            _dataService = dataService;
            _commandService = commandService;
            _visualStudioService = vsService;
            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();
        }

        public List<StartItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private void GetCommands()
            => Commands = _commandService.GetCommands(OpenChangelog, OpenWebsite, OpenSettings);

        private void OpenChangelog()
            => _visualStudioService.OpenWebPage(CHANGELOG_URL, true);

        private void OpenWebsite()
            => _visualStudioService.OpenWebPage(WEBSITE_URL, true);

        private void OpenSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.StartItems>();

        private void Refresh()
        {
            Items.Clear();
            Items = _dataService.GetItems();
        }
    }
}