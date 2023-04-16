using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Interfaces;

    public class CreateProjectViewModel : StartItemViewModel
    {
        public CreateProjectViewModel(IStartItemActionService actionService) : base(actionService)
        {
            Moniker = KnownMonikers.AddDocument;  // AddDocumentGroup missing from KnownMonikers in SDK v15.9.3
            Name = "Create a new project";
            Description = "Choose a project template with code scaffolding to get started";
        }

        protected override void OnClick()
            => ActionService.CreateNewProject();
    }
}