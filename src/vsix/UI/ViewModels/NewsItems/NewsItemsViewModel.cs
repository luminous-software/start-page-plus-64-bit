using System.Collections.Generic;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using Core.Interfaces;

    using Interfaces;
    using Interfaces.NewsItems;

    using Messages;

    using Options.Pages;

    //YD: for future development
    //#region Assembly System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    //namespace System.ServiceModel.Syndication
    //public class SyndicationFeed

    public class NewsItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Read News Item";

        private List<NewsItemViewModel> items = new();
        private readonly IVisualStudioService _visualStudioService;
        private readonly NewsItemsOptions _options = NewsItemsOptions.Instance;

        //---

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemCommandService commandService, INewsItemActionService actionService, IVisualStudioService visualStudioService)
        {
            DataService = dataService;
            CommandService = commandService;
            ActionService = actionService;
            _visualStudioService = visualStudioService;

            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            ListenFor<NewsItemSelected>(this, OnItemSelected);
        }

        //---

        public INewsItemDataService DataService { get; }

        public INewsItemCommandService CommandService { get; }

        public INewsItemActionService ActionService { get; }

        public List<NewsItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        //---

        public void Refresh()
        {
            if (_options.ClearListBeforeRefresh)
                Items.Clear();

            var itemsToDisplay = _options.NewsItemsToDisplay;
            var url = _options.NewsItemsFeedUrl;

            Run(
                async () => Items = await DataService.GetItemsAsync(url, itemsToDisplay)
                );
        }

        //---

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        private void OpenSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.NewsItems>();

        private void OnItemSelected(object recipient, NewsItemSelected message)
        {
            var openInVS = NewsItemsOptions.Instance.OpenLinksInVS;

            ActionService.DoAction(message.Value, openInVS);
        }
    }
}