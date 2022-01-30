namespace StartPagePlus.UI.ViewModels
{
    using System.Collections.ObjectModel;

    using StartPagePlus.Options.Pages;

    public class StartViewModel : TabViewModel
    {
        public StartViewModel() : base()
        {

            Name = "Start";
            Title = GeneralOptions.Instance.StartTabTitleText;
            TabVisible = false;
            Columns = new ObservableCollection<ColumnViewModel>
            {
                ViewModelManager.RecentItemsViewModel,
                ViewModelManager.StartItemsViewModel,
                    ViewModelManager.NewsItemsViewModel,
            };
        }

        public ObservableCollection<ColumnViewModel> Columns { get; set; }

        public bool ShowStartTabTitle
            => GeneralOptions.Instance.ShowStartTabTitle;
    }
}