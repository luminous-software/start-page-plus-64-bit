namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using System;
    using System.Windows.Input;

    using Microsoft.Toolkit.Mvvm.Input;

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
        { }
        //=> MessengerInstance.Send(new NotificationMessage<NewsItemViewModel>(this, Link));
    }
}