using System.Collections.Generic;

namespace StartPagePlus.UI.Interfaces.StartItems
{
    using ViewModels.StartItems;

    public interface IStartItemDataService
    {
        List<StartItemViewModel> GetItems();
    }
}