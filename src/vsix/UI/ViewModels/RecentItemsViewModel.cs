namespace StartPagePlus.UI.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    using Community.VisualStudio.Toolkit;

    using Microsoft.VisualStudio.Shell;

    using StartPagePlus.Options.Pages;
    using StartPagePlus.UI.Interfaces;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string HEADING = "Open a Recent Item";

        private ObservableCollection<RecentItemViewModel> items = new();
        private RecentItemViewModel selectedItem;
        private bool refreshed;

        public RecentItemsViewModel(
            //IRecentItemCommandService commandService,
            //IRecentItemActionService actionService,
            IRecentItemDataService dataService
            //IDialogService dialogService,
            //IVisualStudioService visualStudioService
            ) : base()
        {
            DataService = dataService;
            //ActionService = actionService;
            //CommandService = commandService;
            //DialogService = dialogService;
            //VisualStudioService = visualStudioService;

            Heading = HEADING;
            IsVisible = RecentItemsOptions.Instance.DisplayRecentItems;

            //GetCommands();
            Refresh();

            //LìstenFor<RecentItemsRefresh>(this, RefreshRequested);
            //LìstenFor<RecentItemSelected>(this, SelectItem);
            //LìstenFor<RecentItemTogglePinned>(this, TogglePinned);
            //LìstenFor<RecentItemRemove>(this, RemoveItem);
            //LìstenFor<RecentItemCopyPath>(this, CopyItemPath);
            //LìstenFor<RecentItemEditPath>(this, EditItemPath);
            //LìstenFor<RecentItemOpenInVS>(this, OpenInVS);
        }

        //public IRecentItemActionService ActionService { get; }

        public IRecentItemDataService DataService { get; }

        //public IRecentItemCommandService CommandService { get; }

        //public IDialogService DialogService { get; }

        //public IVisualStudioService VisualStudioService { get; }

        public ObservableCollection<RecentItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public RecentItemViewModel SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public bool Refreshed
        {
            get => refreshed;
            set
            {
                if (SetProperty(ref refreshed, value) && (value == true))
                {
                    //SendMessage(new RecentItemsRefresh());
                }
            }
        }

        public void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (SelectedItem == null)
            {
                e.Handled = true; //suppress empty menu
            }

            //GetContextCommands();
        }

        public void OnContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            // don't set SelectedItem = null in this method, doing so causes the context menu to be empty
        }

        protected override void RaiseCanExecuteChanged()
        {
            base.RaiseCanExecuteChanged();

            //foreach (var command in ContextCommands)
            //{
            //    var name = command.Name;
            //    var relayCommand = (RelayCommand)command.Command;

            //    switch (name) //YD: eliminate this switch?
            //    {
            //        case nameof(PinItem):
            //        case nameof(UnpinItem):
            //        case nameof(RemoveItem):
            //        case nameof(CopyItemPath):
            //        case nameof(EditItemPath):
            //        case nameof(OpenInVS):
            //            relayCommand.RaiseCanExecuteChanged();
            //            break;

            //        default:
            //            break;
            //    }
            //}
        }

        //private void GetCommands()
        //    => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        //private void GetContextCommands()
        //    => ContextCommands = CommandService.GetContextCommands(
        //        CanPinItem, PinItem,
        //        CanUnpinItem, UnpinItem,
        //        CanRemoveItem, RemoveItem,
        //        CanCopyItemPath, CopyItemPath,
        //        CanEditItemPath, EditItemPath,
        //        CanOpenInVS, OpenInVS
        //        );

        //private void SelectItem(RecentItemSelected message)
        //    => ActionService.ExecuteAction(message.Content);

        //private void DeselectItem()
        //    => SelectedItem = null;

        ////---

        //private void TogglePinned(RecentItemTogglePinned message)
        //{
        //    var item = message.Content;

        //    switch (item.Pinned)
        //    {
        //        case true:
        //            UnpinItem(item);
        //            break;

        //        case false:
        //            PinItem(item);
        //            break;
        //    }
        //}

        ////---

        //private bool CanPinItem
        //    => (SelectedItem?.Pinned == false);

        //private void PinItem()
        //    => PinItem(SelectedItem);

        //private void PinItem(RecentItemViewModel viewModel)
        //{
        //    try
        //    {
        //        ThreadHelper.JoinableTaskFactory.Run(async () =>
        //        {
        //            if (await DataService.PinItemAsync(viewModel))
        //            {
        //                Refresh();
        //            }
        //            else
        //            {
        //                DialogService.ShowError($"Unable to pin '{viewModel.Name}'");
        //            }
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        DialogService.ShowException(ex);
        //    }
        //}

        //---

        private bool CanUnpinItem
            => (SelectedItem?.Pinned == true);

        private void UnpinItem()
            => UnpinItem(SelectedItem);

        private void UnpinItem(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    //if (await DataService.UnpinItemAsync(viewModel))
                    //{
                    //    Refresh();
                    //}
                    //else
                    //{
                    //    DialogService.ShowError($"Unable to unpin '{viewModel.Name}'");
                    //}
                });

            }
            catch (Exception ex)
            {
                //DialogService.ShowException(ex);
            }
        }

        //---

        private bool CanRemoveItem
            => (SelectedItem != null);

        private void RemoveItem()
            => RemoveItem(SelectedItem);

        private void RemoveItem(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    //if (await DataService.RemoveItemAsync(viewModel))
                    //{
                    //    Refresh();
                    //}
                    //else
                    //{
                    //    DialogService.ShowError($"Unable to remove '{viewModel.Name}'");
                    //}
                });
            }
            catch (Exception ex)
            {
                //DialogService.ShowException(ex);
            }
            finally
            {
                //DeselectItem();
            }
        }

        //private void RemoveItem(RecentItemRemove message)
        //    => RemoveItem(message.Content);

        //---

        private bool CanCopyItemPath
            => (SelectedItem != null);

        private void CopyItemPath()
            => CopyItemPath(SelectedItem);

        private void CopyItemPath(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    //if (await DataService.CopyItemPathAsync(viewModel))
                    //{
                    //    Refresh();
                    //}
                    //else
                    //{
                    //    DialogService.ShowError($"Unable to copy '{viewModel.Path}' to clipboard");
                    //}
                });
            }
            catch (Exception ex)
            {
                //DialogService.ShowException(ex);
            }
            finally
            {
                //DeselectItem();
            }
        }

        //private void CopyItemPath(RecentItemCopyPath message)
        //    => CopyItemPath(message.Content);


        //---

        private bool CanEditItemPath
                => (SelectedItem != null);

        private void EditItemPath()
            => EditItemPath(SelectedItem);

        private void EditItemPath(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    //var result = await DataService.EditItemPathAsync(viewModel);

                    //switch (result)
                    //{
                    //    case null:
                    //        return;

                    //    case false:
                    //        DialogService.ShowError($"Unable to edit '{viewModel.Name}'");
                    //        break;

                    //    default:
                    //        Refresh();
                    //        break;
                    //}
                });
            }
            catch (Exception ex)
            {
                //DialogService.ShowException(ex);
            }
            finally
            {
                //DeselectItem();
            }
        }

        //private void EditItemPath(RecentItemEditPath message)
        //    => EditItemPath(message.Content);

        //---

        private bool CanOpenInVS
            => (SelectedItem != null);

        private void OpenInVS()
            => OpenInVS(SelectedItem);

        private void OpenInVS(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    //if (await DataService.OpenInVsAsync(viewModel))
                    //{
                    //    Refresh();
                    //}
                    //else
                    //{
                    //    DialogService.ShowError($"Unable to open '{viewModel.Name}' in a new instance of Visual Studio");
                    //}
                });
            }
            catch (Exception ex)
            {
                //DialogService.ShowException(ex);
            }
            finally
            {
                //DeselectItem();
            }
        }

        //private void OpenInVS(RecentItemOpenInVS message)
        //    => OpenInVS(message.Content);

        //---

        private void Refresh()
        {
            Refreshed = false;

            var options = RecentItemsOptions.Instance;
            var itemsToDisplay = options.ItemsToDisplay;
            var showExtensions = options.ShowFileExtensions;

            //YD: replace all of these with RunMethod calls
            ThreadHelper.JoinableTaskFactory.Run(async () =>
            {
                var items = await DataService.GetItemsAsync(itemsToDisplay, showExtensions);

                // Note: setting `Items = items` directly causes the view to lose its grouping/sorting/filter

                Items.Clear();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            });

            Refreshed = true;
        }

        //private void RefreshRequested(RecentItemsRefresh message)
        //    => Refresh();

        private void OpenSettings()
            => VS.Settings.OpenAsync<OptionsProvider.RecentItems>();
    }
}