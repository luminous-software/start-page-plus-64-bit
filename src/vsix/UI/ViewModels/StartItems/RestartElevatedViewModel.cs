namespace StartPagePlus.UI.ViewModels.StartItems
{
    using Microsoft.VisualStudio.Imaging;

    public class RestartElevatedViewModel : StartItemViewModel
    {
        public RestartElevatedViewModel(/*IStartItemActionService actionService*/) : base(/*actionService*/)
        {
            Moniker = KnownMonikers.Restart;
            Name = "Restart Visual Studio";
            Description = "Restart Visual Studio with one click";
            ImageSize = 34;
            Margin = "11,5,0,0";
        }

        protected override void OnClick()
        { }
        //=> ClickService.RestartVisualStudio(confirm: true, elevated: false);
    }
}