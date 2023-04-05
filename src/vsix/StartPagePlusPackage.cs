using System;
using System.Runtime.InteropServices;
using System.Threading;

using Community.VisualStudio.Toolkit;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus
{
    using DI;

    using Options.Pages;

    using StartPagePlus.UI.Services;
    using StartPagePlus.UI.ViewModels;

    using UI.ToolWindows;

    using static Vsix;

    using Task = System.Threading.Tasks.Task;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Name, Description, Vsix.Version)]
    [Guid(PackageGuids.StartPagePlusString)]

    [ProvideMenuResource("Menus.ctmenu", 1)]

    [ProvideToolWindow(typeof(MainWindow.Pane), Style = VsDockStyle.Tabbed, Window = WindowGuids.DocumentWell, MultiInstances = false)]

    [ProvideOptionPage(typeof(OptionsProvider.General), Name, GeneralOptions.Category, 0, 0, true)]
    [ProvideProfile(typeof(OptionsProvider.General), Name, GeneralOptions.Category, 0, 0, true)]

    [ProvideOptionPage(typeof(OptionsProvider.RecentItems), Name, RecentItemsOptions.Category, 0, 0, true)]
    [ProvideProfile(typeof(OptionsProvider.RecentItems), Name, RecentItemsOptions.Category, 0, 0, true)]

    [ProvideOptionPage(typeof(OptionsProvider.NewsItems), Name, NewsItemsOptions.Category, 0, 0, true)]
    [ProvideProfile(typeof(OptionsProvider.NewsItems), Name, NewsItemsOptions.Category, 0, 0, true)]
    public sealed class StartPagePlusPackage : ToolkitPackage //MicrosoftDIToolkitPackage<StartPagePlusPackage>
    {
        private readonly StartPagePlusContainer _container;

        public StartPagePlusPackage() : base()
            => _container = new StartPagePlusContainer();

        //YD: move XAML styles in situ where possible to help debugging experience, or does that work already?

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await this.RegisterCommandsAsync();

            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            ServiceManager.RegisterServices(_container);
            ViewModelManager.RegisterViewModels(_container);

            this.RegisterToolWindows();
        }

        protected override object GetService(Type serviceType)
        {
            return (_container?.IsRegistered(serviceType) ?? false)
                ? _container.GetInstance(serviceType)
                : base.GetService(serviceType);
        }
    }

    //private static void LogService<T>(T service, string message)
    //    where T : IReportServiceLifetime =>
    //        Console.WriteLine($"    {typeof(T).Name}: {service.Id} ({message})");
}