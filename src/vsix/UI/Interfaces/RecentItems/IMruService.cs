namespace StartPagePlus.UI.Interfaces.RecentItems
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using StartPagePlus.UI.Models;

    public interface IMruService
    {
        Task<List<RecentItem>> GetItemsAsync();

        Task<bool> PinItemAsync(string key);

        Task<bool> UnpinItemAsync(string key);

        Task<bool> RemoveItemAsync(string key);

        Task<bool> UpdatePathAsync(string key, string newValue);

        Task<bool> SetLastAccessedAsync(string path, DateTime date);
    }
}