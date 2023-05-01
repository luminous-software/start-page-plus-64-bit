namespace StartPagePlus.UI.Services
{
    using Interfaces;

    internal class StartItemActionService : ServiceBase, IStartItemActionService
    {
        private readonly IVisualStudioService _visualStudioService;

        public StartItemActionService() : base()
        { }

        public StartItemActionService(IVisualStudioService visualStudioService)
            => _visualStudioService = visualStudioService;

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