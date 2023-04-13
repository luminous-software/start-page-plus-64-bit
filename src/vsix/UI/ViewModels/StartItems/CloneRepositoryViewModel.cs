using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Interfaces;

    public class CloneRepositoryViewModel : StartItemViewModel
    {
        public CloneRepositoryViewModel(IStartItemActionService actionService) : base(actionService)
        {
            Moniker = KnownMonikers.CloneToDesktop; // previously DownloadNoColor or SourceControl
            Name = "Clone a repository";
            Description = "Get code from an online repository like GitHub or Azure DevOps etc";
        }

        protected override void OnClick()
            => ActionService.CloneRepository();
    }
}