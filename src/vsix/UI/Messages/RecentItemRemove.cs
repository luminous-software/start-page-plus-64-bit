using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StartPagePlus.UI.Messages
{
    using ViewModels.RecentItems;

    public sealed class RecentItemRemove : ValueChangedMessage<RecentItemViewModel>
    {
        public RecentItemRemove(RecentItemViewModel viewModel) : base(viewModel)
        { }
    }
}