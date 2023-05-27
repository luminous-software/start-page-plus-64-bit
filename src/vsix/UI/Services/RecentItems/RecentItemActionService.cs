using System;

using CommunityToolkit.Mvvm.Messaging;

using Microsoft;
using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Services
{
    using Core;
    using Core.Interfaces;

    using Interfaces;
    using Interfaces.RecentItems;

    using UI.Enums;
    using UI.Messages;

    using ViewModels.RecentItems;

    internal class RecentItemActionService : ServiceBase, IRecentItemActionService
    {
        public RecentItemActionService(
            IRecentItemDataService dataService,
            IVisualStudioService vsService,
            IDialogService dialogService,
            /*IDateTimeService dateTimeService*/
            IAsyncMethodService methodService, IMessenger messenger)
            : base(methodService, messenger)
        {

            DataService = dataService;
            VsService = vsService;
            DialogService = dialogService;
            //DateTimeService = dateTimeService;
        }

        //---

        public IRecentItemDataService DataService { get; }

        public IVisualStudioService VsService { get; }

        private IDialogService DialogService { get; }

        //private IDateTimeService DateTimeService { get; }

        //---

        public void ExecuteAction(RecentItemViewModel viewModel)
        {
            try
            {
                var delay = 0; // currently there is no delay required for recent items

                ThreadHelper.ThrowIfNotOnUIThread();
                Assumes.Present(VsService);

                var path = viewModel.Path;
                var itemType = viewModel.ItemType;

                switch (itemType)
                {
                    case RecentItemType.Folder:
                        if (VsService.OpenFolder(path, delay))
                        {
                            // SetLastAccessedAsync(path); //YD: this can be moved into VsService.OpenXXX
                            SendRefreshMessage();
                        };
                        break;

                    case RecentItemType.Solution:
                    case RecentItemType.CSharpProject:
                    case RecentItemType.VisualBasicProject:
                        if (VsService.OpenProject(path, delay))
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

        //---

        //private async Task SetLastAccessedAsync(string path)
        //    => await DataService.SetLastAccessedAsync(path, DateTimeService.Today.Date);

        private void SendRefreshMessage()
            => Send<RefreshRecentItems>();
    }
}