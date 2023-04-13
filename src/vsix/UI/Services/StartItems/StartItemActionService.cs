namespace StartPagePlus.UI.Services
{
    using Interfaces;

    public class StartItemActionService : IStartItemActionService
    {
        public StartItemActionService(IVisualStudioService visualStudioService)
            => VisualStudioService = visualStudioService;

        private IVisualStudioService VisualStudioService { get; }

        public bool CloneRepository()
            => VisualStudioService.CloneRepository();

        public bool CreateNewProject()
            => VisualStudioService.CreateNewProject();

        public bool OpenFolder()
            => VisualStudioService.OpenFolder();

        public bool OpenProject()
            => VisualStudioService.OpenProject();

        public bool RestartVisualStudio(bool confirm, bool elevated)
            => VisualStudioService.Restart(confirm, elevated);

        public bool OpenWebPage(string url, bool openInVS)
            => VisualStudioService.OpenWebPage(url, openInVS);
    }
}