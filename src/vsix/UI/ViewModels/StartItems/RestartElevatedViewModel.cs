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
            ImageSize = 49; // 47; // 45; // 42;
            Margin = "9,-2,-3,0"; //"9,-2,-4,0"; //"9,-2,0,0"; //"9,0,0,0"; //"11,0,0,0"; //"9,0,0,0"; //"9,5,0,0";
        }

        protected override void OnClick()
            => ActionService.RestartVisualStudio(confirm: true, elevated: true);
    }
}