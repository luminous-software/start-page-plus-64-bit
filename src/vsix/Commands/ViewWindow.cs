namespace StartPagePlus.Commands
{
    using Community.VisualStudio.Toolkit;

    using Microsoft.VisualStudio.Shell;

    using StartPagePlus.UI.ToolWindows;

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
            try
            {
                //await VS.MessageBox.ShowAsync("Start Page+");
                await MainWindow.ShowAsync();
            }
            catch (System.Exception ex)
            {
                await VS.MessageBox.ShowErrorAsync(ex.Message);
            }
        }
    }
}