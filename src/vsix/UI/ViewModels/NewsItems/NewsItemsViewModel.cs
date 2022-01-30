namespace StartPagePlus.UI.ViewModels.NewsItems
{
    public class NewsItemsViewModel : ColumnViewModel
    {
        //private const string DEV_NEWS_FEED_URL = "https://vsstartpage.blob.core.windows.net/news/vs";
        private const string HEADING = "Read Developer News";

        //private ObservableCollection<NewsItemViewModel> items = new ObservableCollection<NewsItemViewModel>();

        public NewsItemsViewModel(/*INewsItemDataService dataService, INewsItemActionService actionService, INewsItemCommandService commandService, IVisualStudioService visualStudioService*/)
        {
            //DataService = dataService;
            //ActionService = actionService;
            //CommandService = commandService;
            //VisualStudioService = visualStudioService;
            Heading = HEADING;
            IsVisible = true;

            //GetCommands();
            //Refresh();

            //MessengerInstance.Register<NotificationMessage<NewsItemViewModel>>(this, (message) =>
            //{
            //    var openInVS = NewsItemsOptions.Instance.OpenLinksInVS;

            //    ActionService.DoAction(message.Content, openInVS);
            //});
        }

        //public INewsItemDataService DataService { get; }

        //public INewsItemActionService ActionService { get; }
        //public INewsItemCommandService CommandService { get; }

        //public IVisualStudioService VisualStudioService { get; }

        //public ObservableCollection<NewsItemViewModel> Items
        //{
        //    get => items;
        //    set => Set(ref items, value);
        //}

        //private void GetCommands()
        //    => Commands = CommandService.GetCommands(Refresh, OpenSettings);

        //public void Refresh()
        //{
        //    if (NewsItemsOptions.Instance.ClearListBeforeRefresh)
        //        Items.Clear();

        //    var itemsToDisplay = NewsItemsOptions.Instance.NewsItemsToDisplay;
        //    var url = NewsItemsOptions.Instance.NewsItemsFeedUrl;

        //    ThreadHelper.JoinableTaskFactory.Run(
        //        async () => Items = await DataService.GetItemsAsync(url, itemsToDisplay)
        //        );
        //}

        //private void OpenSettings()
        //    => VisualStudioService.ShowOptions<OptionsProvider.NewsItems>();
    }
}