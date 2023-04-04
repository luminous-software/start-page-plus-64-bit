namespace StartPagePlus.UI.ViewModels.StartItems
{
    using System.Windows.Input;

    using CommunityToolkit.Mvvm.Input;
    using Microsoft.VisualStudio.Imaging.Interop;

    public abstract class StartItemViewModel : ViewModelBase
    {
        public StartItemViewModel() //IStartItemActionService actionService)
        {
            //ActionService = clickService;
            ClickCommand = new RelayCommand(OnClick);
            ImageSize = 40;
            Margin = "5,5,0,0";
            IsEnabled = true;
        }

        public ImageMoniker Moniker { get; set; }

        public int ImageSize { get; set; }

        public string Margin { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEnabled { get; set; }

        public ICommand ClickCommand { get; set; }

        // public IStartItemActionService ActionService { get; }

        protected virtual void OnClick()
        { }
    }
}