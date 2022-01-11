namespace StartPagePlus
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    using Community.VisualStudio.Toolkit;

    using Microsoft.VisualStudio.Shell;

    using StartPagePlus.Commands;

    using Task = System.Threading.Tasks.Task;

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [ProvideMenuResource("Menus.ctmenu", 1)]

    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [Guid(PackageGuids.StartPagePlusString)]
    public sealed class StartPagePlusPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            //await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            await ViewWindow.InitializeAsync(this);
        }
    }
}