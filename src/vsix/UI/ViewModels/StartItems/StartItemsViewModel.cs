﻿using System;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Core.Interfaces;

    using Interfaces;
    using Interfaces.StartItems;

    using Options.Pages;

    using UI.Messages;

    public class StartItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Get Started";
        private const string WEBSITE_URL = "https://luminous-software.solutions/start-page-plus-64-bit";
        private const string CHANGELOG_URL = WEBSITE_URL + "/changelog";

        private List<StartItemViewModel> _items = new();
        private StartItemViewModel _selectedItem;
        private readonly IStartItemCommandService _commandService;
        private readonly IStartItemDataService _dataService;
        private readonly IDialogService _dialogService;
        private readonly IVisualStudioService _visualStudioService;
        private bool _refreshed;

        //---

        public StartItemsViewModel(
            IStartItemDataService dataService,
            IStartItemCommandService commandService,
            IDialogService dialogService,
            IVisualStudioService vsService
            ) : base()
        {
            _dataService = dataService;
            _commandService = commandService;
            _dialogService = dialogService;
            _visualStudioService = vsService;

            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            ListenFor<RefreshStartItems>(this, RefreshItems);
        }

        //---

        public List<StartItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public StartItemViewModel SelectedItem
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
                    Messenger.Send(new StartItemsRefreshed());
                }
            }
        }

        //---

        private void GetCommands()
            => Commands = _commandService.GetCommands(OpenChangelog, OpenGeneralSettings, OpenStartItemsSettings);

        private void OpenChangelog()
            => _visualStudioService.OpenWebPage(CHANGELOG_URL, true);

        private void OpenGeneralSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.General>();

        private void OpenStartItemsSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.StartItems>();

        private void Refresh()
        {
            Refreshed = false;

            try
            {
                Items.Clear();
                Items = _dataService.GetItems();

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

        private void RefreshItems(object Recipient, RefreshStartItems message)
           => Refresh();
    }
}