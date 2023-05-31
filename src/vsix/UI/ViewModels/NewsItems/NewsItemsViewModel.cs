using System;
using System.Collections.Generic;

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

        private List<NewsItemViewModel> _items = new();
        private NewsItemViewModel _selectedItem;
        private bool _refreshed;
        private readonly IDialogService _dialogService;
        private readonly IVisualStudioService _visualStudioService;

        //---

        public NewsItemsViewModel(
            INewsItemDataService dataService,
            INewsItemCommandService commandService,
            INewsItemActionService actionService,
            IDialogService dialogService,
            IVisualStudioService visualStudioService
            )
        {
            DataService = dataService;
            CommandService = commandService;
            ActionService = actionService;
            _dialogService = dialogService;
            _visualStudioService = visualStudioService;

            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            ListenFor<RefreshNewsItems>(this, RefreshItems);
            ListenFor<NewsItemSelected>(this, OnItemSelected);
        }

        //---

        public INewsItemDataService DataService { get; }

        public INewsItemCommandService CommandService { get; }

        public INewsItemActionService ActionService { get; }

        public List<NewsItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public NewsItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public bool Refreshed
        {
            get => _refreshed;
            set
            {
                if (SetProperty(ref _refreshed, value) && (value == true))
                {
                    SelectedItem = null;

                    Messenger.Send(new NewsItemsRefreshed());
                }
            }
        }

        //---

        public void Refresh()
        {
            Refreshed = false;

            try
            {
                var _options = NewsItemsOptions.Instance;

                if (_options.ClearListBeforeRefresh)
                    Items.Clear();

                var itemsToDisplay = _options.NewsItemsToDisplay;
                var url = _options.NewsItemsFeedUrl;

                Run(
                    async () => Items = await DataService.GetItemsAsync(url, itemsToDisplay)
                );

                Refreshed = true;
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
            }
            finally
            {
                SelectedItem = null;
            }
        }

        //---

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        private void RefreshItems(object Recipient, RefreshNewsItems message)
            => Refresh();

        private void OpenSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.NewsItems>();

        private void OnItemSelected(object recipient, NewsItemSelected message)
        {
            var openInVS = NewsItemsOptions.Instance.OpenLinksInVS;

            ActionService.DoAction(message.Value, openInVS);
        }
    }
}