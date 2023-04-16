namespace StartPagePlus.UI.Interfaces.RecentItems
{
    using StartPagePlus.UI.ViewModels.RecentItems;

    internal interface IRecentItemContextMenuService
    {
        bool RemoveItem(RecentItemViewModel viewModel);

        bool PinItem(RecentItemViewModel viewModel);

        bool UnpinItem(RecentItemViewModel viewModel);

        bool CopyItemPath(RecentItemViewModel viewModel);

        bool EditItemPath(RecentItemViewModel viewModel);

        bool OpenInVS(RecentItemViewModel viewModel);
    }
}