namespace StartPagePlus.UI.ViewModels
{
    using System.Windows.Input;

    public class CommandViewModel : ViewModelBase
    {
        private bool isVisible = true;

        private bool isEnabled = true;

        public string Name { get; set; }

        public ICommand Command { get; set; }

        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }
    }
}