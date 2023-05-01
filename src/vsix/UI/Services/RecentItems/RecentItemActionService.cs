using System;

using Microsoft;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;
    using UI.Enums;
    using Interfaces;
    using Interfaces.RecentItems;
    using ViewModels.RecentItems;
    using StartPagePlus.UI.Messages;
    using CommunityToolkit.Mvvm.Messaging;

    internal class RecentItemActionService : ServiceBase, IRecentItemActionService
    {
        public RecentItemActionService(
            IRecentItemDataService dataService,
            IVisualStudioService vsService,
            IDialogService dialogService
            /*IDateTimeService dateTimeService*/
            ) : base()
        {
            DataService = dataService;
            VsService = vsService;
            DialogService = dialogService;
            //DateTimeService = dateTimeService;
        }

        public IRecentItemDataService DataService { get; }

        public IVisualStudioService VsService { get; }

        private IDialogService DialogService { get; }

        //private IDateTimeService DateTimeService { get; }

        public void ExecuteAction(RecentItemViewModel viewModel)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                Assumes.Present(VsService);

                var path = viewModel.Path;
                var itemType = viewModel.ItemType;

                switch (itemType)
                {
                    case RecentItemType.Folder:
                        if (VsService.OpenFolder(path))
                        {
                            // SetLastAccessedAsync(path); //YD: this can be moved into VsService.OpenXXX
                            SendRefreshMessage();
                        };
                        break;

                    case RecentItemType.Solution:
                    case RecentItemType.CSharpProject:
                    case RecentItemType.VisualBasicProject:
                        if (VsService.OpenProject(path))
                        {
                            //SetLastAccessedAsync(path); //YD: this can be moved into VsService.OpenXXX
                            SendRefreshMessage();
                        }
                        break;

                    default:
                        DialogService.ShowWarning($"Unhandled item type:'{itemType}'");
                        break;
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
        }

        //private async Task SetLastAccessedAsync(string path)
        //    => await DataService.SetLastAccessedAsync(path, DateTimeService.Today.Date);

        private void SendRefreshMessage()
            => Messenger.Send(new RecentItemsRefresh());
    }
}