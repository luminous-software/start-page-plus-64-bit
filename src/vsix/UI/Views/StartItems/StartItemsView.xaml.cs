using System;
using System.Windows;
using System.Windows.Controls;

using Luminous.Code.Extensions.Exceptions;

namespace StartPagePlus.UI.Views.StartItems
{
    public partial class StartItemsView : UserControl
    {
        public StartItemsView() // constructor injection doesn't seem to work for views
        {
            InitializeComponent();

            try
            {
                // NOTE: Refresh is called in viewmodel's constructor
                //       DataContext is being set by the DataTemplate in StartView;

                //var viewModel = ViewModelManager.StartItemsViewModel;
                //DataContext = viewModel;

                //YD: do the same as SetSelectedItemToNull (change names to OnListViewSelectionChanged & OnListViewLoaded
                //    OnListViewLoaded may not be needed - test

                //StartItemsListView.SelectionChanged += (sender, e) =>
                //{
                //    var listView = (ListView)sender;

                //    listView.SelectedItem = null;
                //};

                OnLoadedSetSelectedItemToNull();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ExtendedMessage());
            }
        }

        private void OnLoadedSetSelectedItemToNull()
            => StartItemsListView.Loaded += (sender, e)
                => StartItemsListView.SelectedItem = null;
    }
}