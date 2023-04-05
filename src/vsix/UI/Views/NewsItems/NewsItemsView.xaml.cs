using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Luminous.Code.Extensions.Exceptions;
using Luminous.Code.Extensions.Strings;

namespace StartPagePlus.UI.Views.NewsItems
{
    using ViewModels;
    using ViewModels.NewsItems;

    public partial class NewsItemsView : UserControl
    {
        public NewsItemsView()
        {
            InitializeComponent();

            try
            {
                var viewModel = ViewModelManager.NewsItemsViewModel;

                // NOTE: Refresh is called in viewmodel's constructor

                DataContext = viewModel;

                var view = (ListCollectionView)CollectionViewSource.GetDefaultView(viewModel.Items);

                using (view.DeferRefresh())
                {
                    //    AddGrouping(view);
                    //    AddSorting(view);
                    AddFilter(view);
                }

                RefreshViewWhenFilterChanges(view);
                SetSelectedItemToNull();

                //RootMethods.ListenFor<NewsItemsRefresh>(this, FocusFilterTextBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ExtendedMessage());
            }
        }

        private static void AddGrouping(ListCollectionView view)
        {
            view.GroupDescriptions.Clear();
            view.IsLiveGrouping = true;
            //view.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NewsItemViewModel.PeriodType)));
        }

        private static void AddSorting(ListCollectionView view)
        {
            view.SortDescriptions.Clear();
            view.IsLiveSorting = true;
            //view.SortDescriptions.Add(new SortDescription(nameof(NewsItemViewModel.PeriodType), ListSortDirection.Ascending));
            //view.SortDescriptions.Add(new SortDescription(nameof(NewsItemViewModel.Date), ListSortDirection.Descending));
        }

        private void AddFilter(ListCollectionView view)
        {
            view.Filter = (object obj) =>
            {
                if (string.IsNullOrEmpty(FilterTextBox.Text))
                    return true;

                if (!(obj is NewsItemViewModel item))
                    return false;

                var name = item.Title;

                return name.IsNotNullOrEmpty()
                    && name.MatchesFilter(FilterTextBox.Text);
            };
        }

        private void RefreshViewWhenFilterChanges(ListCollectionView view)
            => FilterTextBox.TextChanged += (object sender, TextChangedEventArgs e)
                => view.Refresh();

        private void SetSelectedItemToNull()
            => NewsItemsListView.Loaded += (sender, e)
                => NewsItemsListView.SelectedItem = null;

        private void ClearFilterText_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Text = "";
            FocusFilterTextBox();
        }

        private void FocusFilterTextBox(object sender = null)
            => FilterTextBox.Focus();

        private void OnExpanded(object sender, RoutedEventArgs e)
            => FocusFilterTextBox();

        private void OnCollapsed(object sender, RoutedEventArgs e)
            => FocusFilterTextBox();

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            => FocusFilterTextBox();
    }
}