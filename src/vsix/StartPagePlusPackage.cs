using System;
using System.Runtime.InteropServices;
using System.Threading;

using Microsoft.VisualStudio.Shell;

using Community.VisualStudio.Toolkit;

namespace StartPagePlus
{
    using DI;

    using Options.Pages;

    using UI.Events;
    using UI.Services;
    using UI.ToolWindows;
    using UI.ViewModels;

    using Task = System.Threading.Tasks.Task;

    using static Vsix;

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
    public sealed class StartPagePlusPackage : ToolkitPackage
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
            MessageManager.RegisterMessages(_container);
            EventManager.RegisterEvents(_container);

            this.RegisterToolWindows();
        }

        protected override object GetService(Type serviceType)
        {
            if (_container?.IsRegistered(serviceType) ?? false) // try in the container first
            {
                return _container?.GetInstance(serviceType); // the container gets the requested service
            }

            return base.GetService(serviceType); // otherwise let VS handle getting the requested service
        }
    }

    //private static void LogService<T>(T service, string message)
    //    where T : IReportServiceLifetime =>
    //        Console.WriteLine($"    {typeof(T).Name}: {service.Id} ({message})");
}