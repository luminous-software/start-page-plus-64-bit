using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Interfaces
{
    public interface IVisualStudioService
    {
        bool ExecuteCommand(string action, string args = "");

        bool OpenWebPage(string url, bool internalBrowser);

        bool CloneRepository();

        bool OpenFolder(string path);

        bool OpenFolder();

        bool OpenProject(string path);

        bool OpenProject();

        bool CreateNewProject();

        bool Restart(bool confirm = true, bool elevated = false);

        Task<bool> OpenInNewInstanceAsync(string path);

        bool ShowOptions<T>() where T : DialogPage;
    }
}