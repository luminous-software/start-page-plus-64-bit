namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using System;
    using System.Windows.Input;

    using CommunityToolkit.Mvvm.Input;

namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using Messages;

    public class NewsItemViewModel : ViewModelBase
    {
        public NewsItemViewModel()
            => SelectCommand = new RelayCommand(OnSelect);

        //---

        public ICommand SelectCommand { get; set; }

        //---

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        //---

        private void OnSelect()
        {
            => Messenger.Send(new NewsItemSelected(this));
        }
    }
}