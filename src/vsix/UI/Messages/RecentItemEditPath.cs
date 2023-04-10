using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StartPagePlus.UI.Messages
{
    using ViewModels.RecentItems;

    public sealed class RecentItemEditPath : ValueChangedMessage<RecentItemViewModel>
    {
        public RecentItemEditPath(RecentItemViewModel viewModel) : base(viewModel)
        { }
    }
}