namespace StartPagePlus.UI.Services
{
    using CommunityToolkit.Mvvm.Messaging;

    using Interfaces;

    using StartPagePlus.Core;

    internal class StartItemActionService : ServiceBase, IStartItemActionService
    {
        private readonly IVisualStudioService _visualStudioService;

        //---

        public StartItemActionService(IVisualStudioService visualStudioService, IAsyncMethodService methodService, IMessenger messenger)
            : base(methodService, messenger)
            => _visualStudioService = visualStudioService;

        //---

        public bool CloneRepository()
            => _visualStudioService.CloneRepository();

        public bool CreateNewProject()
            => _visualStudioService.CreateNewProject();

        public bool OpenFolder()
            => _visualStudioService.OpenFolder();

        public bool OpenProject()
            => _visualStudioService.OpenProject();

        public bool RestartVisualStudio(bool confirm, bool elevated)
            => _visualStudioService.Restart(confirm, elevated);

        public bool OpenWebPage(string url, bool openInVS)
            => _visualStudioService.OpenWebPage(url, openInVS);
    }
}