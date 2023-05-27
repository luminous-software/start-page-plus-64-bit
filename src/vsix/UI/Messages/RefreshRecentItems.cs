using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StartPagePlus.UI.Messages
{
    public sealed class RefreshRecentItems : ValueChangedMessage<int>
    {
        public RefreshRecentItems() : base(0)
        { }

        public RefreshRecentItems(int delay) : base(delay)
        { }
    }
}