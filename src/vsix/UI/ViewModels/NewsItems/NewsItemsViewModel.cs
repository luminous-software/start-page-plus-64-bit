using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;

using CommunityToolkit.Mvvm.Messaging;

using Community.VisualStudio.Toolkit;

namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using Core.Interfaces;

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

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemCommandService commandService, INewsItemActionService actionService)
        {
            DataService = dataService;
            CommandService = commandService;
            ActionService = actionService;
            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            Messenger.Register<NewsItemClickedMessage>(this, OnItemClicked);
        }

        private void OnItemClicked(object r, NewsItemClickedMessage m)
        {
            var openInVS = NewsItemsOptions.Instance.OpenLinksInVS;

            ActionService.DoAction(m.Value, openInVS);
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
            => VS.Settings.OpenAsync<OptionsProvider.NewsItems>();
    }
}