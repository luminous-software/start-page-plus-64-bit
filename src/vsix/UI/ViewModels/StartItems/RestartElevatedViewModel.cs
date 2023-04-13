using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Interfaces;

    public class RestartElevatedViewModel : StartItemViewModel
    {
        public RestartElevatedViewModel(IStartItemActionService actionService) : base(actionService)
        {
            Moniker = KnownMonikers.User;
            Name = "Restart Visual Studio (elevated)";
            Description = "Restart Visual Studio as administrator with one click";
            ImageSize = 42;
            Margin = "9,5,0,0";
        }

        protected override void OnClick()
            => ActionService.RestartVisualStudio(confirm: true, elevated: false);
    }
}