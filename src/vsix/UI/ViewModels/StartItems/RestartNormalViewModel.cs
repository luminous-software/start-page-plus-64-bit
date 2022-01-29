namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Microsoft.VisualStudio.Imaging;

    public class RestartNormalViewModel : StartItemViewModel
    {
        public RestartNormalViewModel(/*IStartItemActionService actionService*/) : base(/*actionService*/)
        {
            Moniker = KnownMonikers.User;
            Name = "Restart Visual Studio";
            Description = "Restart Visual Studio with one click";
            ImageSize = 42;
            Margin = "9,5,0,0";
        }

        protected override void OnClick()
        { }
        //=> ClickService.RestartVisualStudio(confirm: true, elevated: true);
    }
}