namespace StartPagePlus.UI.ViewModels
{
    using Microsoft.VisualStudio.Imaging.Interop;

    public class ContextCommandViewModel : CommandViewModel
    {
        private ImageMoniker moniker;

        public ImageMoniker Moniker
        {
            get => moniker;
            set => SetProperty(ref moniker, value);
        }
    }
}