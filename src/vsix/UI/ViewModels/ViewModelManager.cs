namespace StartPagePlus.UI.ViewModels
{
    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Toolkit.Mvvm.ComponentModel;

    using StartPagePlus.UI.ViewModels.NewsItems;
    using StartPagePlus.UI.ViewModels.RecentItems;
    using StartPagePlus.UI.ViewModels.StartItems;

    public static class ViewModelManager
    {
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

        internal static void RegisterViewModels(IServiceCollection viewModels)
        {
            viewModels.AddSingleton<MainViewModel>();
            viewModels.AddSingleton<StartViewModel>();

            //---

            viewModels.AddSingleton<RecentItemsViewModel>();
            viewModels.AddSingleton<RecentItemViewModel>();

            //---

            viewModels.AddSingleton<StartItemsViewModel>();
            viewModels.AddSingleton<CloneRepositoryViewModel>();
            viewModels.AddSingleton<CreateProjectViewModel>();
            viewModels.AddSingleton<OpenFolderViewModel>();
            viewModels.AddSingleton<OpenProjectViewModel>();
            viewModels.AddSingleton<RestartElevatedViewModel>();
            viewModels.AddSingleton<RestartNormalViewModel>();

            //---

            viewModels.AddSingleton<NewsItemsViewModel>();
        }

        public static T GetViewModel<T>()
            where T : ObservableObject
        {
            var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            var viewModel = serviceProvider.GetRequiredService<T>();

            return viewModel;
        }
    }
}