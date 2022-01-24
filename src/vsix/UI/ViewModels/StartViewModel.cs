namespace StartPagePlus.UI.ViewModels
{

    using StartPagePlus.Options.Pages;

    public class StartViewModel : TabViewModel
    {
        public StartViewModel() : base()
        {

            Name = "Start";
            Title = GeneralOptions.Instance.StartTabTitleText;
            IsVisible = false;
            //Columns = new ObservableCollection<ColumnViewModel>
            //{
            //    ViewModelLocator.RecentItemsViewModel,
            //    ViewModelLocator.StartItemsViewModel,
            //    ViewModelLocator.NewsItemsViewModel,
            //};
        }

        //public ObservableCollection<ColumnViewModel> Columns { get; set; }

        public bool ShowStartTabTitle
            => GeneralOptions.Instance.ShowStartTabTitle;
    }
}