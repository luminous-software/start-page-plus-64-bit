namespace StartPagePlus.UI.Services.StartItems
{
    using System.Collections.Generic;

    using CommunityToolkit.Mvvm.Messaging;

    using Interfaces.StartItems;

    using StartPagePlus.Core;

    using ViewModels.StartItems;

    internal class StartItemDataService : ServiceBase, IStartItemDataService
    {
        private readonly CloneRepositoryViewModel _cloneRepository;
        private readonly OpenFolderViewModel _openFolder;
        private readonly OpenProjectViewModel _openProject;
        private readonly CreateProjectViewModel _createProject;
        private readonly RestartNormalViewModel _restartNormal;
        private readonly RestartElevatedViewModel _restartElevated;

        public StartItemDataService(
            CloneRepositoryViewModel cloneRepository,
            OpenFolderViewModel openFolder,
            OpenProjectViewModel openProjext,
            CreateProjectViewModel createProject,
            RestartNormalViewModel restartNormal,
            RestartElevatedViewModel restartElevated,
            IAsyncMethodService methodService, IMessenger messenger)
            : base(methodService, messenger)
        {
            _cloneRepository = cloneRepository;
            _openFolder = openFolder;
            _openProject = openProjext;
            _createProject = createProject;
            _restartNormal = restartNormal;
            _restartElevated = restartElevated;
        }

        public List<StartItemViewModel> GetItems()
        {
            var items = new List<StartItemViewModel>
            {
                _cloneRepository,
                _openFolder,
                _openProject,
                _createProject,
                _restartNormal,
                _restartElevated // icon size has been tweaked in viewmodel
            };

            return items;
        }
    }
}