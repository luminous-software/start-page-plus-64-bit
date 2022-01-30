namespace StartPagePlus.UI.Interfaces.NewsItems
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StartPagePlus.UI.ViewModels.NewsItems;

    public interface INewsItemDataService
    {
        Task<List<NewsItemViewModel>> GetItemsAsync(string url, int itemsToDisplay);
    }
}