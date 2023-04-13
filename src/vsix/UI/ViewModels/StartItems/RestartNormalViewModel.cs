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
            Description = "Restart Visual Studio with one click (VS is currently running elevated, VS will remain elevated)";
            ImageSize = 34;
            Margin = "11,5,0,0";
        }

        protected override void OnClick()
            => ActionService.RestartVisualStudio(confirm: true, elevated: true);
    }
}