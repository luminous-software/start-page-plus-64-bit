namespace StartPagePlus.UI.ViewModels
{
    using System.Collections.ObjectModel;

    using Community.VisualStudio.Toolkit;

    using StartPagePlus.Options.Pages;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Company = "Luminous Software Solutions";
            TabVisible = false;
            Tabs = new ObservableCollection<TabViewModel>
            {
                ViewModelManager.StartViewModel//,

                //new FavoritesViewModel(),
                //new CreateViewModel(),
                //new NewsViewModel()
            };
        }

        public string Company { get; }

        public bool TabVisible { get; }

        public static ToolkitPackage Package { get; set; }

        public ObservableCollection<TabViewModel> Tabs { get; }

        public int MaxWidth
            => GeneralOptions.Instance.MaxWidth;
    }
}