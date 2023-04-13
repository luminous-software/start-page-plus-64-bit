using System;

using CommunityToolkit.Mvvm.ComponentModel;

namespace StartPagePlus.UI.ViewModels
{
    using DI;

    using RecentItems;

    using StartItems;

    using NewsItems;

    public static class ViewModelManager
    {
        internal static StartPagePlusContainer Container { get; set; }

        public static MainViewModel MainViewModel
            => GetViewModel<MainViewModel>();

        public static StartViewModel StartViewModel
            => GetViewModel<StartViewModel>();

        //---

        public static RecentItemsViewModel RecentItemsViewModel
            => GetViewModel<RecentItemsViewModel>();

        public static RecentItemViewModel RecentItemViewModel
            => GetViewModel<RecentItemViewModel>();

        //---

        public static NewsItemsViewModel NewsItemsViewModel
            => GetViewModel<NewsItemsViewModel>();

        //---

        internal static void RegisterViewModels(StartPagePlusContainer container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));

            Container.AddSingleton<MainViewModel>();
            Container.AddSingleton<StartViewModel>();

            //---

            Container.AddSingleton<RecentItemsViewModel>();
            Container.AddSingleton<RecentItemViewModel>();

            //---

            Container.AddSingleton<StartItemsViewModel>();
            Container.AddSingleton<CloneRepositoryViewModel>();
            Container.AddSingleton<CreateProjectViewModel>();
            Container.AddSingleton<OpenFolderViewModel>();
            Container.AddSingleton<OpenProjectViewModel>();
            Container.AddSingleton<RestartElevatedViewModel>();
            Container.AddSingleton<RestartNormalViewModel>();

            //---

            Container.AddSingleton<NewsItemsViewModel>();
        }

        private static T GetViewModel<T>()
            where T : ObservableObject
        {
            var viewModel = Container.GetInstance<T>();

            return viewModel;
        }
    }
}