namespace StartPagePlus.UI.ViewModels.RecentItems
{
    using System;

    using CommunityToolkit.Mvvm.Input;
    using Microsoft.VisualStudio.Imaging.Interop;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

    public class RecentItemViewModel : ViewModelBase
    {
        public RecentItemViewModel()
        {
            SelectItemCommand = new RelayCommand(SelectItem);
            TogglePinnedCommand = new RelayCommand(TogglePinned);
            RemoveItemCommand = new RelayCommand(RemoveItem);
            CopyItemPathCommand = new RelayCommand(CopyItemPath);
            EditItemPathCommand = new RelayCommand(EditItemPath);
            OpenInVSCommand = new RelayCommand(OpenInVS);
        }

        //---

        public RelayCommand SelectItemCommand { get; }

        public RelayCommand TogglePinnedCommand { get; }

        public RelayCommand RemoveItemCommand { get; }

        public RelayCommand CopyItemPathCommand { get; }

        public RelayCommand EditItemPathCommand { get; }

        public RelayCommand OpenInVSCommand { get; }

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

        private void SelectItem() { }
        //    => SendMessage(new RecentItemSelected(this));
            => Messenger.Send(new RecentItemSelected(this));

        private void TogglePinned() { }
        //    => SendMessage(new RecentItemTogglePinned(this));
            => Messenger.Send(new RecentItemTogglePinned(this));

        private void RemoveItem() { }
        //    => SendMessage(new RecentItemRemove(this));
            => Messenger.Send(new RecentItemRemove(this));

        private void CopyItemPath() { }
        //    => SendMessage(new RecentItemCopyPath(this));
            => Messenger.Send(new RecentItemCopyPath(this));

        private void EditItemPath() { }
        //    => SendMessage(new RecentItemEditPath(this));
            => Messenger.Send(new RecentItemEditPath(this));

        private void OpenInVS() { }
        //    => SendMessage(new RecentItemOpenInVS(this));
            => Messenger.Send(new RecentItemOpenInVS(this));
    }
}