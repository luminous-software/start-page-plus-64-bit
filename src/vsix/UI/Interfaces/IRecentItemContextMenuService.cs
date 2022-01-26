namespace StartPagePlus.UI.Interfaces
{
    using StartPagePlus.UI.ViewModels;

    public interface IRecentItemContextMenuService
    {
        bool RemoveItem(RecentItemViewModel viewModel);

        bool PinItem(RecentItemViewModel viewModel);

        bool UnpinItem(RecentItemViewModel viewModel);

        bool CopyItemPath(RecentItemViewModel viewModel);

        bool EditItemPath(RecentItemViewModel viewModel);

        bool OpenInVS(RecentItemViewModel viewModel);
    }
}