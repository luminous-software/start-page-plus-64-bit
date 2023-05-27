using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Services
{
    using Core;

    using Interfaces;

    using Options.Pages;

    internal class StartItemActionService : ServiceBase, IStartItemActionService
    {
        private readonly IVisualStudioService _visualStudioService;

        //---

        public StartItemActionService(IVisualStudioService visualStudioService, IAsyncMethodService methodService, IMessenger messenger)
            : base(methodService, messenger)
        {
            var _delay = StartItemsOptions.Instance.CloneRepositoryDelay;
            _visualStudioService = visualStudioService;
        }

        //---

        public bool CloneRepository()
            => _visualStudioService.CloneRepository(StartItemsOptions.Instance.CloneRepositoryDelay);

        public bool CreateNewProject()
            => _visualStudioService.CreateNewProject(StartItemsOptions.Instance.CreateProjectDelay);

        public bool OpenFolder()
            => _visualStudioService.OpenFolder(StartItemsOptions.Instance.OpenFolderDelay);

        public bool OpenProject()
            => _visualStudioService.OpenProject(StartItemsOptions.Instance.OpenProjectDelay);

        //---

        public bool RestartVisualStudio(bool confirm, bool elevated)
            => _visualStudioService.Restart(confirm, elevated);

        public bool OpenWebPage(string url, bool openInVS)
            => _visualStudioService.OpenWebPage(url, openInVS);
    }
}