namespace StartPagePlus.UI.Services.RecentItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.VisualStudio.Shell;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using StartPagePlus.UI.Interfaces.RecentItems;
    using StartPagePlus.UI.Models;
    using StartPagePlus.UI.ViewModels;

    internal class MruPrivateSettingsService : IMruService
    {
        private const string _offlinePath = "/content/indexed/collection[@name='CodeContainers.Offline']";
        private const string _privateSettingsXml = @"\ApplicationPrivateSettings.xml";

        private string _settingsPath
            //YD: kind of clunky, but it works, for now
            => MainViewModel.Package?.UserDataPath.Replace("Roaming", "Local") + _privateSettingsXml;

        public async Task<List<RecentItem>> GetItemsAsync()
        {
            List<RecentItem> items;

            try
            {
                items = await LoadAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return items;
        }

        public async Task<bool> PinItemAsync(string key)
        {
            bool result;

            try
            {
                result = await SetPinnedAsync(key, true);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> UnpinItemAsync(string key)
        {
            bool result;

            try
            {
                result = await SetPinnedAsync(key, false);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> RemoveItemAsync(string key)
        {
            bool result;

            try
            {
                var items = await LoadAsync();
                if (items is null)
                    return false;

                var item = items.FirstOrDefault(x => x.Key == key);
                if (item is null)
                    return false;

                items.Remove(item);

                result = await SaveAsync(items);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> UpdatePathAsync(string key, string newValue)
        {
            bool result;

            try
            {
                var items = await LoadAsync();
                if (items is null)
                    return false;

                var item = items.FirstOrDefault(x => x.Key == key);
                if (item != null)
                    return false;

                item.Key = newValue;
                item.Value.LocalProperties.FullPath = newValue;

                result = await SaveAsync(items);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> SetLastAccessedAsync(string path, DateTime date)
        {
            bool result;

            try
            {
                var items = await LoadAsync();
                if (items is null)
                    return false;

                var item = items.FirstOrDefault(x => x.Key == path);
                if (item is null)
                    return false;

                item.Value.LastAccessed = date;

                result = await SaveAsync(items);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //---

        private async Task<bool> SetPinnedAsync(string key, bool value)
        {
            bool result;

            try
            {
                var items = await LoadAsync();
                if (items is null)
                    return false;

                var item = items?.FirstOrDefault(x => x.Key == key);
                if (item is null)
                    return false;

                item.Value.IsFavorite = value;

                result = await SaveAsync(items);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        private async Task<List<RecentItem>> LoadAsync()
        {
            var items = new List<RecentItem>();

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                var xmlDocument = new XmlDocument();

                xmlDocument.Load(_settingsPath);

                using (var offline = xmlDocument.DocumentElement.SelectNodes(_offlinePath))
                {
                    var codeContainers = offline?.Item(0)?.FirstChild;

                    if (codeContainers is null)
                        return items; // empty list

                    var text = codeContainers.InnerText;

                    items = JArray.Parse(text).ToObject<List<RecentItem>>();
                }
            }

            catch (Exception)
            {
                throw;
            }

            return items;
        }

        private async Task<bool> SaveAsync(List<RecentItem> items)
        {
            bool result;

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                var xmlDocument = new XmlDocument();

                xmlDocument.Load(_settingsPath);

                using (var offline = xmlDocument.DocumentElement.SelectNodes(_offlinePath))
                {
                    var codeContainers = offline.Item(0).FirstChild;
                    var recentItems = JsonConvert.SerializeObject(items);

                    codeContainers.InnerText = recentItems;
                }

                xmlDocument.Save(_settingsPath);

                result = true;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}