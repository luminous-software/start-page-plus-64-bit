namespace StartPagePlus.UI.Interfaces
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public interface IDataService<T> : IService
        where T : IViewModel
    {
        ObservableCollection<T> GetItems();

        Task<ObservableCollection<T>> GetItemsAsync();
    }
}