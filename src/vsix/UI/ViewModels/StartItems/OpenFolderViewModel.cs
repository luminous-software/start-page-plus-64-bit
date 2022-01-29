namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Microsoft.VisualStudio.Imaging;

    public class OpenFolderViewModel : StartItemViewModel
    {
        public OpenFolderViewModel(/*IStartItemActionService actionService*/) : base(/*actionService*/)
        {
            Moniker = KnownMonikers.OpenFolder;
            Name = "Open a local folder";
            Description = "Navigate and edit code within any folder on your machine or network";
        }

        protected override void OnClick()
        { }
        //=> ActionService.CreateNewProject();    }
    }
}