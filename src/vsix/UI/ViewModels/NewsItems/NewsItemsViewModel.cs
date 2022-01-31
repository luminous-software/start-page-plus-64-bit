namespace StartPagePlus.UI.ViewModels.NewsItems
{
    using System.Collections.Generic;

    using Community.VisualStudio.Toolkit;

    using Microsoft.VisualStudio.Shell;

    using StartPagePlus.Options.Pages;
    using StartPagePlus.UI.Interfaces.NewsItems;

    //#region Assembly System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    //namespace System.ServiceModel.Syndication
    //public class SyndicationFeed

    public class NewsItemsViewModel : ColumnViewModel
    {
        //private const string DEV_NEWS_FEED_URL = "https://vsstartpage.blob.core.windows.net/news/vs";
        private const string HEADING = "Read News Item";

        private List<NewsItemViewModel> items = new();

        public NewsItemsViewModel(INewsItemDataService dataService, INewsItemCommandService commandService/*, INewsItemActionService actionService, IVisualStudioService visualStudioService*/)
        {
            DataService = dataService;
            CommandService = commandService;
            //ActionService = actionService;
            //VisualStudioService = visualStudioService;
            Heading = HEADING;
            IsVisible = true;

            GetCommands();
            Refresh();

            //MessengerInstance.Register<NotificationMessage<NewsItemViewModel>>(this, (message) =>
            //{
            //    var openInVS = NewsItemsOptions.Instance.OpenLinksInVS;

            //    ActionService.DoAction(message.Content, openInVS);
            //});
        }

        public INewsItemDataService DataService { get; }

        public INewsItemCommandService CommandService { get; }

        //public INewsItemActionService ActionService { get; }

        //public IVisualStudioService VisualStudioService { get; }

        public List<NewsItemViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public void Refresh()
        {
            if (NewsItemsOptions.Instance.ClearListBeforeRefresh)
                Items.Clear();

            var itemsToDisplay = NewsItemsOptions.Instance.NewsItemsToDisplay;
            var url = NewsItemsOptions.Instance.NewsItemsFeedUrl;

            ThreadHelper.JoinableTaskFactory.Run(
                async () => Items = await DataService.GetItemsAsync(url, itemsToDisplay)
                );
        }

        private void GetCommands()
            => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        private void OpenSettings()
            => VS.Settings.OpenAsync<OptionsProvider.NewsItems>();
    }
}