namespace StartPagePlus.UI.ViewModels
{
    using System;
    using System.Windows.Input;

    using Microsoft.VisualStudio.Imaging.Interop;

    public class RecentItemViewModel : ViewModelBase
    {
        public RecentItemViewModel()
        {
            //SelectItemCommand = new RelayCommand(SelectItem, true);
            //TogglePinnedCommand = new RelayCommand(TogglePinned, true);
            //RemoveItemCommand = new RelayCommand(RemoveItem, true);
            //CopyItemPathCommand = new RelayCommand(CopyItemPath, true);
            //EditItemPathCommand = new RelayCommand(EditItemPath, true);
            //OpenInVSCommand = new RelayCommand(OpenInVS, true);
        }

        //---

        public ICommand SelectItemCommand { get; }

        public ICommand TogglePinnedCommand { get; }

        public ICommand RemoveItemCommand { get; }

        public ICommand CopyItemPathCommand { get; }

        public ICommand EditItemPathCommand { get; }

        public ICommand OpenInVSCommand { get; }

        //---

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        //public PeriodType PeriodType { get; set; }

        //internal RecentItemType ItemType { get; set; }

        public string Path { get; set; }

        public ImageMoniker Moniker { get; set; }

        public bool Pinned { get; set; }

        //---

        //private void SelectItem()
        //    => SendMessage(new RecentItemSelected(this));

        //private void TogglePinned()
        //    => SendMessage(new RecentItemTogglePinned(this));

        //private void RemoveItem()
        //    => SendMessage(new RecentItemRemove(this));

        //private void CopyItemPath()
        //    => SendMessage(new RecentItemCopyPath(this));

        //private void EditItemPath()
        //    => SendMessage(new RecentItemEditPath(this));

        //private void OpenInVS()
        //    => SendMessage(new RecentItemOpenInVS(this));
    }
}