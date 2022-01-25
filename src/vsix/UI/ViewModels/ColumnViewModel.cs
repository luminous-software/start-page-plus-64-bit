namespace StartPagePlus.UI.ViewModels
{
    public class ColumnViewModel : ViewModelRecipient
    {
        private bool isVisible = true;
        //private ObservableContextCommandList contextCommands;

        public string Heading { get; set; }

        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        //public ObservableCommandList Commands { get; set; }

        //public ObservableContextCommandList ContextCommands
        //{
        //    get => contextCommands;
        //    set
        //    {
        //        if (Set(ref contextCommands, value, nameof(ContextCommands)))
        //        {
        //            RaiseCanExecuteChanged();
        //        };
        //    }
        //}

        protected virtual void RaiseCanExecuteChanged()
        { }
    }
}