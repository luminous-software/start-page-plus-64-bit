namespace StartPagePlus.Commands
{
    using Community.VisualStudio.Toolkit;

    using Microsoft.VisualStudio.Shell;

    //using StartPagePlus.Options.Models;
    //using StartPagePlus.UI.ToolWindows;

    using Task = System.Threading.Tasks.Task;

    [Command(PackageIds.ViewWindow)]
    internal sealed class ViewWindow : BaseCommand<ViewWindow>
    {
        //protected override void BeforeQueryStatus(EventArgs e)
        //    => Command.Enabled = GeneralOptions.Instance.EnableStartPagePlusOptions;

        protected async override Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowAsync("Start Page+");
            //using (await MainWindow.ShowAsync())
            //{ };
        }
    }
}