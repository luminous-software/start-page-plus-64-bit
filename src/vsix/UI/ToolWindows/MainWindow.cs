namespace StartPagePlus.UI.ToolWindows
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    using Community.VisualStudio.Toolkit;

    using Microsoft.VisualStudio.Imaging;

    using Microsoft.VisualStudio.Shell;

    using StartPagePlus.UI.Views;

    public class MainWindow : BaseToolWindow<MainWindow>
    {
        public override string GetTitle(int toolWindowId)
            => Vsix.InternalName;

        public override Type PaneType
            => typeof(Pane);

        public override Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
            => Task.FromResult<FrameworkElement>(new MainView(Package));

        //---

        [Guid(PackageGuids.StartPagePlusWindowString)]
        public class Pane : ToolWindowPane
        {
            public Pane()
            {
                Caption = Vsix.InternalName;
                BitmapImageMoniker = KnownMonikers.Home;
            }
        }
    }
}