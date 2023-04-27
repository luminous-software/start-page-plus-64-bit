using Microsoft.VisualStudio.Imaging;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Interfaces;

    public class RestartNormalViewModel : StartItemViewModel
    {
        public RestartNormalViewModel(IStartItemActionService actionService) : base(actionService)
        {
            Moniker = KnownMonikers.Restart;
            Name = "Restart Visual Studio";
            Description = "Restart Visual Studio with one click (if VS is currently running elevated, VS will remain elevated)";
            ImageSize = 40;// 34;
            Margin = "7,5,0,0"; // "11,5,0,0";
        }

        protected override void OnClick()
            => ActionService.RestartVisualStudio(confirm: true, elevated: false);
    }
}