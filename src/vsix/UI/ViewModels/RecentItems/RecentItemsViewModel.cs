using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

using Microsoft.VisualStudio.Shell;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.ViewModels.RecentItems
{
    using Core.Interfaces;

    using Interfaces;
    using Interfaces.RecentItems;

    using Messages;

    using Options.Pages;

    public class RecentItemsViewModel : ColumnViewModel
    {
        private const string _heading = "Open Recent Item";

        private ObservableCollection<RecentItemViewModel> items = new();
        private IVisualStudioService _visualStudioService;

        private RecentItemViewModel selectedItem;
        private bool refreshed;

        public RecentItemsViewModel(
            IRecentItemCommandService commandService,
            IRecentItemActionService actionService,
            IRecentItemDataService dataService,
            IDialogService dialogService,
            IVisualStudioService visualStudioService
            ) : base()
        {
            DataService = dataService;
            ActionService = actionService;
            CommandService = commandService;
            DialogService = dialogService;
            _visualStudioService = visualStudioService;

            Heading = _heading;
            IsVisible = RecentItemsOptions.Instance.DisplayRecentItems;

            GetCommands();
            Refresh();

            Messenger.Register<RecentItemsRefresh>(this, RefreshRequested);
            Messenger.Register<RecentItemSelected>(this, SelectItem);
            Messenger.Register<RecentItemTogglePinned>(this, TogglePinned);
            Messenger.Register<RecentItemRemove>(this, RemoveItem);
            Messenger.Register<RecentItemCopyPath>(this, CopyItemPath);
            Messenger.Register<RecentItemEditPath>(this, EditItemPath);
            Messenger.Register<RecentItemOpenInVS>(this, OpenInVS);
        }

        public IRecentItemActionService ActionService { get; }

        public IRecentItemDataService DataService { get; }

        public IRecentItemCommandService CommandService { get; }

        public IDialogService DialogService { get; }

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
                    Messenger.Send(new RecentItemsRefreshed());
                }
            }
        }

        public void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (SelectedItem == null)
            {
                e.Handled = true; //suppress empty menu
            }

            GetContextCommands();
        }

        public void OnContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            // don't set SelectedItem = null in this method, doing so causes the context menu to be empty
        }

        //protected override void RaiseCanExecuteChanged()
        //{
        //    base.RaiseCanExecuteChanged();

        //    //foreach (var command in ContextCommands)
        //    //{
        //    //    var name = command.Name;
        //    //    var relayCommand = (RelayCommand)command.Command;

        //    //    switch (name) //YD: eliminate this switch?
        //    //    {
        //    //        case nameof(PinItem):
        //    //        case nameof(UnpinItem):
        //    //        case nameof(RemoveItem):
        //    //        case nameof(CopyItemPath):
        //    //        case nameof(EditItemPath):
        //    //        case nameof(OpenInVS):
        //    //            relayCommand.RaiseCanExecuteChanged();
        //    //            break;

        //    //        default:
        //    //            break;
        //    //    }
        //    //}
        //}

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        private void GetContextCommands()
            => ContextCommands = CommandService.GetContextCommands(
                CanPinItem, PinItem,
                CanUnpinItem, UnpinItem,
                CanRemoveItem, RemoveItem,
                CanCopyItemPath, CopyItemPath,
                CanEditItemPath, EditItemPath,
                CanOpenInVS, OpenInVS
                );

        private void SelectItem(object recipient, RecentItemSelected message)
            => ActionService.ExecuteAction(message.Value);

        private void DeselectItem()
            => SelectedItem = null;

        ////---

        private void TogglePinned(object recipient, RecentItemTogglePinned message)
        {
            var item = message.Value;

            switch (item.Pinned)
            {
                case true:
                    UnpinItem(item);
                    break;

                case false:
                    PinItem(item);
                    break;
            }
        }

        ////---

        private Func<bool> CanPinItem
            => () => (SelectedItem?.Pinned == false);

        private void PinItem()
            => PinItem(SelectedItem);

        private void PinItem(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    if (await DataService.PinItemAsync(viewModel))
                    {
                        Refresh();
                    }
                    else
                    {
                        DialogService.ShowError($"Unable to pin '{viewModel.Name}'");
                    }
                });

            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
        }

        //---

        private Func<bool> CanUnpinItem
            => () => (SelectedItem?.Pinned == true);

        private void UnpinItem()
            => UnpinItem(SelectedItem);

        private void UnpinItem(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    if (await DataService.UnpinItemAsync(viewModel))
                    {
                        Refresh();
                    }
                    else
                    {
                        DialogService.ShowError($"Unable to unpin '{viewModel.Name}'");
                    }
                });

            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
        }

        //---

        private Func<bool> CanRemoveItem
            => () => (SelectedItem is not null);

        private void RemoveItem()
            => RemoveItem(SelectedItem);

        private void RemoveItem(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    if (await DataService.RemoveItemAsync(viewModel))
                    {
                        Refresh();
                    }
                    else
                    {
                        DialogService.ShowError($"Unable to remove '{viewModel.Name}'");
                    }
                });
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
            finally
            {
                DeselectItem();
            }
        }

        private void RemoveItem(object recipient, RecentItemRemove message)
            => RemoveItem(message.Value);

        //---

        private Func<bool> CanCopyItemPath
            => () => (SelectedItem is not null);

        private void CopyItemPath()
            => CopyItemPath(SelectedItem);

        private void CopyItemPath(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    if (await DataService.CopyItemPathAsync(viewModel))
                    {
                        Refresh();
                    }
                    else
                    {
                        DialogService.ShowError($"Unable to copy '{viewModel.Path}' to clipboard");
                    }
                });
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
            finally
            {
                DeselectItem();
            }
        }

        private void CopyItemPath(object recipient, RecentItemCopyPath message)
            => CopyItemPath(message.Value);

        //---

        private Func<bool> CanEditItemPath
            => () => (SelectedItem is not null);

        private void EditItemPath()
            => EditItemPath(SelectedItem);

        private void EditItemPath(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    var result = await DataService.EditItemPathAsync(viewModel);

                    switch (result)
                    {
                        case null:
                            return;

                        case false:
                            DialogService.ShowError($"Unable to edit '{viewModel.Name}'");
                            break;

                        default:
                            Refresh();
                            break;
                    }
                });
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
            finally
            {
                DeselectItem();
            }
        }

        private void EditItemPath(object Recipient, RecentItemEditPath message)
            => EditItemPath(message.Value);

        //---

        private Func<bool> CanOpenInVS
            => () => (SelectedItem is not null);

        private void OpenInVS()
            => OpenInVS(SelectedItem);

        private void OpenInVS(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    if (await DataService.OpenInVsAsync(viewModel))
                    {
                        Refresh();
                    }
                    else
                    {
                        DialogService.ShowError($"Unable to open '{viewModel.Name}' in a new instance of Visual Studio");
                    }
                });
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
            finally
            {
                //DeselectItem();
            }
        }

        private void OpenInVS(object recipient, RecentItemOpenInVS message)
            => OpenInVS(message.Value);

        //---

        private void Refresh()
        {
            Refreshed = false;

            try
            {
                var options = RecentItemsOptions.Instance;
                var itemsToDisplay = options.ItemsToDisplay;
                var showExtensions = options.ShowFileExtensions;
                var showPaths = options.ShowFilePaths;

                //YD: replace all of these with RunMethod calls
                ThreadHelper.JoinableTaskFactory.Run(async () =>
                {
                    var items = await DataService.GetItemsAsync(itemsToDisplay, showExtensions, showPaths);

                    // Note: setting `Items = items` directly causes the view to lose its grouping/sorting/filter
                    // YD: what if 'items' was declared outside JTF.Run?

                    Items.Clear();

                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
                });

                Refreshed = true;
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
        }

        private void RefreshRequested(object Recipient, RecentItemsRefresh message)
            => Refresh();

        private void OpenSettings()
            => _visualStudioService.ShowOptions<OptionsProvider.RecentItems>();
    }
}