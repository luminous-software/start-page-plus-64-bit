using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Interfaces;

    public class OpenProjectViewModel : StartItemViewModel
    {
        public OpenProjectViewModel(IStartItemActionService actionService) : base(actionService)
        {
            Moniker = KnownMonikers.OpenTopic;  // OpenDocumentGroup missing from KnownMonikers in SDK v15.9.3
            Name = "Open a project or solution";
            Description = "Open a local Visual Studio project or a '.sln' file";
        }

        protected override void OnClick()
            => ActionService.OpenProject();
    }
}