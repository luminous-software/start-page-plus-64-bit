namespace StartPagePlus.UI.ViewModels
{
    using System.Collections.Generic;

    public class ColumnViewModel : ViewModelBase
    {
        private bool isVisible = true;
        private List<ContextCommandViewModel> contextCommands;

        public string Heading { get; set; }

        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        public List<CommandViewModel> Commands { get; set; }

        public List<ContextCommandViewModel> ContextCommands
        {
            get => contextCommands;
            set => SetProperty(ref contextCommands, value);
        }
    }
}