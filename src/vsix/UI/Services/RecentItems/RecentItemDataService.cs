﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StartPagePlus.UI.Services.RecentItems
{
    using System.Collections.Generic;
    using System.IO;

    using CommunityToolkit.Mvvm.Messaging;

    using Core.Interfaces;

    using StartPagePlus.Core;
    using StartPagePlus.UI.Interfaces.RecentItems;
    using StartPagePlus.UI.ViewModels.RecentItems;

    internal class RecentItemDataService : ServiceBase, IRecentItemDataService
    {
        public RecentItemDataService(
            IMruService mruService,
            IDateTimeService dateTimeService,
            //IClipboardService clipboardService,
            //IRecentItemDialogService recentItemDialogService,
            //IVisualStudioService visualStudioService
            IAsyncMethodService methodService,
            IMessenger messenger
            ) : base(methodService, messenger)
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

        public async Task<ObservableCollection<RecentItemViewModel>> GetItemsAsync(
            int itemsToDisplay,
            bool showExtensions,
            bool showPaths,
            bool includeCsProjFiles
            )
        {
            var viewModels = new List<RecentItemViewModel>();
            var today = DateTimeService.Today.Date;
            var recentItems = await MruService.GetItemsAsync();

            //YD: is there a simpler or more per4formant way of doing this?

            // convert List<RecentItems> to List<RecentItemViewModel>
            recentItems
                // Note: .OrderByDescending(x => x.Value.LastAccessed) not needed because of grouping/sorting
                //.ToList()
                .ForEach((recentItem)
                    => viewModels.Add(recentItem.CreateViewModel(today, showExtensions, showPaths)));

            var recentItemViewModels = (
                from vm in viewModels
                where (includeCsProjFiles == true) || (Path.GetExtension(vm.Path) != ".csproj") //YD: move to a testable Include(path, includeCsProjFiles) property?
                select vm
            ).Take(itemsToDisplay).ToList();

            return new ObservableCollection<RecentItemViewModel>(recentItemViewModels);
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
                var result = true; //YD: await VisualStudioService.OpenInNewInstanceAsync(path);

                return result
                    ? await UpdateLastAccessedAsync(path)
                    : result;
            }
            catch (Exception)
            {
                throw; //YD: what happens if the async method throws an exception? //YD: DIalogService.ShowException
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