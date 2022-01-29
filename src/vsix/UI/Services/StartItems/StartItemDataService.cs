namespace StartPagePlus.UI.Services.StartItems
{
    using System.Collections.Generic;

    using StartPagePlus.UI.Interfaces.StartItems;
    using StartPagePlus.UI.ViewModels;
    using StartPagePlus.UI.ViewModels.StartItems;

    public class StartItemDataService : IStartItemDataService
    {
        public List<StartItemViewModel> GetItems()
        {
            var items = new List<StartItemViewModel>
            {
                ViewModelManager.CloneRepositoryViewModel,
                ViewModelManager.OpenFolderViewModel,
                ViewModelManager.OpenProjectViewModel,
                ViewModelManager.CreateProjectViewModel,
                ViewModelManager.RestartNormalViewModel,
                ViewModelManager.RestartElevatedViewModel
            };

            return items;
        }
    }
}