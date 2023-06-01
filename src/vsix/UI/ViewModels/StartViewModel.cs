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
            var options = GeneralOptions.Instance;

            Name = "Start";
            Title = options.StartTabTitleText;

            if (options.DisplayNewsItems)
            {
                Columns = new ObservableCollection<ColumnViewModel>
                {
                    recentItemsViewModel,
                    startItemsViewModel,
                    newsItemsViewModel
                };
            }
            else
            {
                Columns = new ObservableCollection<ColumnViewModel>
                {
                    recentItemsViewModel,
                    startItemsViewModel
                };
            }
        }

        //---

        public ObservableCollection<ColumnViewModel> Columns { get; set; }
    }
}