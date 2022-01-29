namespace StartPagePlus.UI.Interfaces.StartItems
{
    using System.Collections.Generic;

    using StartPagePlus.UI.ViewModels.StartItems;

    public interface IStartItemDataService
    {
        List<StartItemViewModel> GetItems();
    }
}