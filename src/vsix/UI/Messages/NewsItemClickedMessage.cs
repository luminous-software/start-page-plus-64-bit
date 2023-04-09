using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StartPagePlus.UI.Messages
{
    using ViewModels.NewsItems;

    public sealed class NewsItemClickedMessage : ValueChangedMessage<NewsItemViewModel>
    {
        public NewsItemClickedMessage(NewsItemViewModel vm) : base(vm)
        { }
    }
}