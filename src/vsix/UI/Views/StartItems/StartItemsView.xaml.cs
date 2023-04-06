namespace StartPagePlus.UI.Views.StartItems
{
    using System.Windows.Controls;

    public partial class StartItemsView : UserControl
    {
        public StartItemsView() // constructor injection doesn't seem to work for views
        {
            //var viewModel = ViewModelManager.StartItemsViewModel;

            InitializeComponent();

                // NOTE: Refresh is called in viewmodel's constructor
                //       DataContext is being set by the DataTemplate in StartView;

                //var viewModel = ViewModelManager.StartItemsViewModel;
            //DataContext = viewModel;

            //StartItemsListView.SelectionChanged += (sender, e) =>
            //{
            //    var listView = (ListView)sender;

            //    listView.SelectedItem = null;
            //};
        }
    }
}