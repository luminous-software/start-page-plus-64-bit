using System;

using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;

namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using Messages;

    public partial class NewsItemViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        //---

        [RelayCommand]
        private void SelectItem()
            => Messenger.Send(new NewsItemSelected(this));
    }
}