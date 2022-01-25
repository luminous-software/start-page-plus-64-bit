namespace StartPagePlus.UI.ViewModels
{

    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Toolkit.Mvvm.ComponentModel;

    public static class ViewModelManager
    {
        public static MainViewModel MainViewModel
            => GetViewModel<MainViewModel>();

        public static StartViewModel StartViewModel
            => GetViewModel<StartViewModel>();

        public static RecentItemsViewModel RecentItemsViewModel
            => GetViewModel<RecentItemsViewModel>();

        public static RecentItemViewModel RecentItemViewModel
            => GetViewModel<RecentItemViewModel>();

        internal static void RegisterViewModels(IServiceCollection viewModels)
        {
            viewModels.AddSingleton<MainViewModel>();
            viewModels.AddSingleton<StartViewModel>();
            viewModels.AddSingleton<RecentItemsViewModel>();
            viewModels.AddSingleton<RecentItemViewModel>();
        }

        public static T GetViewModel<T>()
            where T : ObservableObject
        {
            var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            var viewModel = serviceProvider.GetRequiredService<T>();

            //var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            //var viewModel = serviceProvider.GetService<T>();

            return viewModel;
        }
    }
}