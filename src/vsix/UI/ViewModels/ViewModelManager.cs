using System;

using CommunityToolkit.Mvvm.ComponentModel;

namespace StartPagePlus.UI.ViewModels
{
    using DI;

    using NewsItems;

    using RecentItems;

    using StartItems;

    internal class ViewModelManager
    {
        private static StartPagePlusContainer _container;

        //---

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

        public static void RegisterViewModels(StartPagePlusContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

            _container.AddSingleton<MainViewModel>();
            _container.AddSingleton<StartViewModel>();

            //---

            _container.AddSingleton<RecentItemsViewModel>();
            _container.AddSingleton<RecentItemViewModel>();

            //---

            _container.AddSingleton<StartItemsViewModel>();
            _container.AddSingleton<CloneRepositoryViewModel>();
            _container.AddSingleton<CreateProjectViewModel>();
            _container.AddSingleton<OpenFolderViewModel>();
            _container.AddSingleton<OpenProjectViewModel>();
            _container.AddSingleton<RestartElevatedViewModel>();
            _container.AddSingleton<RestartNormalViewModel>();

            //---

            _container.AddSingleton<NewsItemsViewModel>();
        }

        //---

        private static T GetViewModel<T>()
            where T : ObservableObject
        {
            var viewModel = _container.GetInstance<T>();

            return viewModel;
        }
    }
}