using System;

using Microsoft.VisualStudio.Imaging.Interop;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.ViewModels.RecentItems
{
    using Enums;

    using Messages;

    public partial class RecentItemViewModel : ViewModelBase
    {
        public RecentItemViewModel()
        { }

        //---

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public PeriodType PeriodType { get; set; }

        public RecentItemType ItemType { get; set; }

        public string Path { get; set; }

        public ImageMoniker Moniker { get; set; }

        public bool Pinned { get; set; }

        //---

        [RelayCommand]
        private void SelectItem()
            => Messenger.Send(new RecentItemSelected(this));

        [RelayCommand]
        private void TogglePinned()
            => Messenger.Send(new RecentItemTogglePinned(this));

        [RelayCommand]
        private void RemoveItem()
            => Messenger.Send(new RecentItemRemove(this));

        [RelayCommand]
        private void CopyItemPath()
            => Messenger.Send(new RecentItemCopyPath(this));

        [RelayCommand]
        private void EditItemPath()
            => Messenger.Send(new RecentItemEditPath(this));

        [RelayCommand]
        private void OpenInVS()
            => Messenger.Send(new RecentItemOpenInVS(this));
    }
}