﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StartPagePlus.UI.Interfaces
{
    using Core.Interfaces;

    internal interface IDataService<T> : IService
        where T : IViewModel
    {
        ObservableCollection<T> GetItems();

        Task<ObservableCollection<T>> GetItemsAsync();
    }
}