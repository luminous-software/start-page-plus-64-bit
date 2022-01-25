namespace StartPagePlus.UI.Interfaces
{
    using System.Threading.Tasks;

    public interface IMruDataService<T> : IDataService<T>
        where T : IViewModel
    {
        bool UpdateLastAccessed(string path);

        Task<bool> UpdateLastAccessedAsync(string path);
    }
}