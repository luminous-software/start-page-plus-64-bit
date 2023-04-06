using System;

using CommunityToolkit.Mvvm.ComponentModel;

namespace StartPagePlus.UI.ViewModels
{
    using DI;

    using NewsItems;

    using RecentItems;

    using StartItems;

    public static class ViewModelManager
    {
        private static StartPagePlusContainer _container;

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

        public static StartItemsViewModel StartItemsViewModel
            => GetViewModel<StartItemsViewModel>();

        public static CloneRepositoryViewModel CloneRepositoryViewModel
            => GetViewModel<CloneRepositoryViewModel>();

        public static CreateProjectViewModel CreateProjectViewModel
            => GetViewModel<CreateProjectViewModel>();

        public static OpenFolderViewModel OpenFolderViewModel
            => GetViewModel<OpenFolderViewModel>();

        public static OpenProjectViewModel OpenProjectViewModel
            => GetViewModel<OpenProjectViewModel>();

        public static RestartElevatedViewModel RestartElevatedViewModel
            => GetViewModel<RestartElevatedViewModel>();

        public static RestartNormalViewModel RestartNormalViewModel
            => GetViewModel<RestartNormalViewModel>();

        //---

        public static NewsItemsViewModel NewsItemsViewModel
            => GetViewModel<NewsItemsViewModel>();

        //---

        internal static void RegisterViewModels(StartPagePlusContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

            container.AddSingleton<MainViewModel>();
            container.AddSingleton<StartViewModel>();

            //---

            container.AddSingleton<RecentItemsViewModel>();
            container.AddSingleton<RecentItemViewModel>();

            //---

            container.AddSingleton<StartItemsViewModel>();
            container.AddSingleton<CloneRepositoryViewModel>();
            container.AddSingleton<CreateProjectViewModel>();
            container.AddSingleton<OpenFolderViewModel>();
            container.AddSingleton<OpenProjectViewModel>();
            container.AddSingleton<RestartElevatedViewModel>();
            container.AddSingleton<RestartNormalViewModel>();

            //---

            container.AddSingleton<NewsItemsViewModel>();
        }

        private static T GetViewModel<T>()
            where T : ObservableObject
        {
            var viewModel = _container.GetInstance<T>();

            return viewModel;
        }
    }
}