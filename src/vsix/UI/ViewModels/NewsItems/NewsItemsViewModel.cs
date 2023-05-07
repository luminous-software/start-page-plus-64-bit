using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;

using CommunityToolkit.Mvvm.Messaging;

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

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemCommandService commandService, INewsItemActionService actionService, IVisualStudioService visualStudioService)
        {
            DataService = dataService;
            CommandService = commandService;
            ActionService = actionService;
            _visualStudioService = visualStudioService;

            Heading = HEADING;
            IsVisible = NewsItemsOptions.Instance.DisplayNewsItems;

            GetCommands();
            Refresh();

            Messenger.Register<NewsItemSelected>(this, OnItemSelected);
        }

        private void OnItemSelected(object recipient, NewsItemSelected message)
        {
            var openInVS = NewsItemsOptions.Instance.OpenLinksInVS;

            ActionService.DoAction(message.Value, openInVS);
        }

        public INewsItemDataService DataService { get; }

        public INewsItemCommandService CommandService { get; }

        public INewsItemActionService ActionService { get; }

        public List<NewsItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public void Refresh()
        {
            if (NewsItemsOptions.Instance.ClearListBeforeRefresh)
                Items.Clear();

            var itemsToDisplay = NewsItemsOptions.Instance.NewsItemsToDisplay;
            var url = NewsItemsOptions.Instance.NewsItemsFeedUrl;

            ThreadHelper.JoinableTaskFactory.Run(
                async () => Items = await DataService.GetItemsAsync(url, itemsToDisplay)
                );
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        private void OpenSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.NewsItems>();
    }
}