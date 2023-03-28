namespace
    StartPagePlus
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Microsoft;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.Shell;

    using StartPagePlus.Options.Pages;
    using StartPagePlus.UI.Services;
    using StartPagePlus.UI.ToolWindows;
    using StartPagePlus.UI.ViewModels;

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
    public sealed class StartPagePlusPackage : MicrosoftDIToolkitPackage<StartPagePlusPackage>
    {
        //YD: move XAML styles in situ where possible to help debugging experience, or does that work already?

        protected override void InitializeServices(IServiceCollection services)
        {
            ViewModelManager.RegisterViewModels(services);
            ServiceManager.RegisterServices(services);
        }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            await this.RegisterCommandsAsync();
            //await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            this.RegisterToolWindows();
        }
    }
}