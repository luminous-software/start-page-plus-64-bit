using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StartPagePlus.UI.Messages
{
    using ViewModels.RecentItems;

    public sealed class RecentItemTogglePinned : ValueChangedMessage<RecentItemViewModel>
    {
        public RecentItemTogglePinned(RecentItemViewModel viewModel) : base(viewModel)
        { }
    }
}