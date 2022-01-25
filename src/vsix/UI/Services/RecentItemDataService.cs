﻿namespace StartPagePlus.UI.Services
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Luminous.Code.Interfaces;

    using StartPagePlus.Extensions.RecentItems;
    using StartPagePlus.UI.Interfaces;
    using StartPagePlus.UI.ViewModels;

    public class RecentItemDataService : ServiceBase, IRecentItemDataService
    {
        public RecentItemDataService(
            IMruService mruService,
            IDateTimeService dateTimeService
            //IClipboardService clipboardService,
            //IRecentItemDialogService recentItemDialogService,
            //IVisualStudioService visualStudioService
            )
        {
            MruService = mruService;
            DateTimeService = dateTimeService;
            //ClipboardService = clipboardService;
            //RecentItemDialogService = recentItemDialogService;
            //VisualStudioService = visualStudioService;
        }

        private IMruService MruService { get; }

        private IDateTimeService DateTimeService { get; }

        //public IClipboardService ClipboardService { get; }

        //public IRecentItemDialogService RecentItemDialogService { get; }

        //public IVisualStudioService VisualStudioService { get; }

        public async Task<ObservableCollection<RecentItemViewModel>> GetItemsAsync(int itemsToDisplay, bool showExtensions)
        {
            var items = new ObservableCollection<RecentItemViewModel>();
            var today = DateTimeService.Today.Date;
            var recentItems = await MruService.GetItemsAsync();

            recentItems
                //    .OrderByDescending(x => x.Value.LastAccessed)
                .Take(itemsToDisplay)
                .ToList()
                .ForEach((recentItem)
                    => items.Add(recentItem.ToViewModel(today, showExtensions)));

            return items;
        }

        public async Task<bool> RemoveItemAsync(RecentItemViewModel viewModel)
            => await MruService.RemoveItemAsync(viewModel.Path);

        public async Task<bool> PinItemAsync(RecentItemViewModel viewModel)
            => await MruService.PinItemAsync(viewModel.Path);

        public async Task<bool> UnpinItemAsync(RecentItemViewModel viewModel)
            => await MruService.UnpinItemAsync(viewModel.Path);

        public async Task<bool> UpdateItemPathAsync(RecentItemViewModel viewModel, string value)
            => await MruService.UpdatePathAsync(viewModel.Path, value);

        public async Task<bool> UpdateItemPathAsync(string key, string newValue)
            => await MruService.UpdatePathAsync(key, newValue);

        public async Task<bool> CopyItemPathAsync(RecentItemViewModel item)
        {
            try
            {
                return true; // await ClipboardService.CopyToClipboardAsync(item.Path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool?> EditItemPathAsync(RecentItemViewModel viewModel)
        {
            bool? result = null;

            try
            {
                //var newValue = RecentItemDialogService.GetNewValue(viewModel);

                //result = newValue.IsNullOrEmpty()
                //    ? null
                //    : (bool?)await UpdateItemPathAsync(viewModel, newValue);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> OpenInVsAsync(RecentItemViewModel viewModel)
        {
            try
            {
                var path = viewModel.Path;
                var result = true; //await VisualStudioService.OpenInNewInstanceAsync(path);

                return result
                    ? await UpdateLastAccessedAsync(path)
                    : result;
            }
            catch (Exception)
            {
                throw; //YD: what happens if the async method throws an exception?
            }
        }

        public async Task<bool> UpdateLastAccessedAsync(string path)
        {
            try
            {
                return await MruService.SetLastAccessedAsync(path, DateTimeService.Now);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}