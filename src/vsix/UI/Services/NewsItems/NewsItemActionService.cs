using StartPagePlus.UI.ViewModels.NewsItems;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using UI.Interfaces;

    internal class NewsItemActionService : ServiceBase, INewsItemActionService
    {
        public NewsItemActionService() : base()
        { }

        public NewsItemActionService(IVisualStudioService vsService)
            => VisualStudioService = vsService;

        public IVisualStudioService VisualStudioService { get; }

        public void DoAction(NewsItemViewModel currentViewModel, bool internalBrowser = true)
        {
            var url = currentViewModel.Link;

            VisualStudioService.OpenWebPage(url, internalBrowser);
        }
    }
}