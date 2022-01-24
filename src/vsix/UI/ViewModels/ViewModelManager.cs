namespace StartPagePlus.UI.ViewModels
{

    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

    using Microsoft.Extensions.DependencyInjection;

    public static class ViewModelManager
    {
        public static MainViewModel MainViewModel
            => GetViewModel<MainViewModel>();

        public static StartViewModel StartViewModel
            => GetViewModel<StartViewModel>();

        internal static void RegisterViewModels(IServiceCollection viewModels)
        {
            viewModels.AddSingleton<MainViewModel>();
            viewModels.AddSingleton<StartViewModel>();
        }

        public static T GetViewModel<T>()
            where T : ViewModelBase //YD to be revised
        {
            var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            var viewModel = serviceProvider.GetRequiredService<T>();

            //var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            //var viewModel = serviceProvider.GetService<T>();

            return viewModel;
        }
    }
}