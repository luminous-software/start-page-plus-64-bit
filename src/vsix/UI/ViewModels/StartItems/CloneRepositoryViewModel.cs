namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Microsoft.VisualStudio.Imaging;

    public class CloneRepositoryViewModel : StartItemViewModel
    {
        public CloneRepositoryViewModel(/*IStartItemActionService actionService*/) : base(/*actionService*/)
        {
            Moniker = KnownMonikers.DownloadNoColor; // SourceControl
            Name = "Clone a repository";
            Description = "Get code from an online repository like GitHub or Azure DevOps etc";
        }

        protected override void OnClick()
        { }
        //=> actionService.CloneRepository();
    }
}