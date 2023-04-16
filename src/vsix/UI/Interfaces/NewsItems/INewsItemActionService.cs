namespace StartPagePlus.Core.Interfaces
{
    using StartPagePlus.UI.ViewModels.NewsItems;

    public interface INewsItemActionService
    {
        void DoAction(NewsItemViewModel currentViewModel, bool internalBrowser = true);
    }
}