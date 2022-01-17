//namespace StartPagePlus.UI.ViewModels
//{
//    using System.Collections.ObjectModel;

//    using Community.VisualStudio.Toolkit;

//    using StartPagePlus.Options.Models;

//    public class MainViewModel : ViewModelBase
//    {
//        public MainViewModel()
//        {
//            Company = "Luminous Software Solutions";
//            IsVisible = false;
//            Tabs = new ObservableCollection<TabViewModel>
//            {
//                ViewModelLocator.StartViewModel//,
//                //new FavoritesViewModel(),
//                //new CreateViewModel(),
//                //new NewsViewModel()
//            };
//        }

//        public string Company { get; }

//        public bool IsVisible { get; }

//        public static ToolkitPackage Package { get; set; }

//        public ObservableCollection<TabViewModel> Tabs { get; }

//        public int MaxWidth
//            => GeneralOptions.Instance.MaxWidth;
//    }

//}