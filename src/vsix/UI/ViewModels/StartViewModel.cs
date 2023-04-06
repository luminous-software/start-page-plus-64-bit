using System.Collections.ObjectModel;

namespace StartPagePlus.UI.ViewModels
{
    using Options.Pages;

    using StartPagePlus.UI.ViewModels.NewsItems;
    using StartPagePlus.UI.ViewModels.RecentItems;
    using StartPagePlus.UI.ViewModels.StartItems;

    public class StartViewModel : TabViewModel
    {
        public StartViewModel(RecentItemsViewModel recentItemsViewModel, StartItemsViewModel startItemsViewModel, NewsItemsViewModel newsItemsViewModel) : base()
        {
            Name = "Start";
            Title = GeneralOptions.Instance.StartTabTitleText;
            TabVisible = false;
            Columns = new ObservableCollection<ColumnViewModel>
            {
                recentItemsViewModel,
                startItemsViewModel,
                newsItemsViewModel
            };
        }

        public ObservableCollection<ColumnViewModel> Columns { get; set; }

        public bool ShowStartTabTitle
            => GeneralOptions.Instance.ShowStartTabTitle;
    }
}