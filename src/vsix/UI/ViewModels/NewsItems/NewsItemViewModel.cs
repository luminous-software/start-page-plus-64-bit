using System;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using Messages;

    using Options.Pages;

    public partial class NewsItemViewModel : ViewModelBase
    {
        //private readonly bool _showTooltip;

        //public NewsItemViewModel()
        //{

        //}

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        public bool ShowTooltip
            => NewsItemsOptions.Instance.ShowNewsItemTooltip;

        //---

        [RelayCommand]
        private void SelectItem()
            => Messenger.Send(new NewsItemSelected(this));
    }
}