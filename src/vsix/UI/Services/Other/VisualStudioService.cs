using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Community.VisualStudio.Toolkit;

using EnvDTE;

using EnvDTE80;

using Luminous.Code.Extensions.Exceptions;
using Luminous.Code.Extensions.Strings;
//using Luminous.Code.VisualStudio.Packages;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using Process = System.Diagnostics.Process;
using Task = System.Threading.Tasks.Task;

namespace StartPagePlus.UI.Services.Other
{
    using Core.Interfaces;

    using UI.Interfaces;

    internal class VisualStudioService : ServiceBase, IVisualStudioService
    {
        private const string VERB_OPEN = "Open";

        private const string FILE_OPEN_FOLDER = "File.OpenFolder";
        private const string FILE_OPEN_PROJECT = "File.OpenProject";
        private const string FILE_NEW_PROJECT = "File.NewProject";
        private const string FILE_CLONE_REPOSITORY = "File.CloneRepository";

        private const string TOOLS_OPTIONS = "Tools.Options";

        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;

        public VisualStudioService(IDialogService dialogService) : base()
            => DialogService = dialogService;

        private IDialogService DialogService { get; }

        private IVsWebBrowsingService BrowsingService
            => VS.GetRequiredService<SVsWebBrowsingService, IVsWebBrowsingService>();

        private static DTE2 Dte
            => VS.GetRequiredService<_DTE, DTE2>(); //YD: investogate toolkit way for DTE2

        private IVsShell3 VsShell3
            => VS.GetRequiredService<SVsShell, IVsShell3>(); //YD: investogate toolkit way for IVsShell3

        private IVsShell4 VsShell4
            => VS.GetRequiredService<SVsShell, IVsShell4>(); //YD: investogate toolkit way for IVsShell4

        public bool ExecuteCommand(string action, string args = "")
        {
            try
            {
                VS.Commands.ExecuteAsync(action, args).FireAndForget();
                return true;
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                return false;
            }

        }

        public bool OpenWebPage(string url, bool openInVS)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (openInVS == true)
                {
                    BrowsingService.Navigate(url, FORCE_NEW_WINDOW, out var ppFrame);
                }
                else
                {
                    using (var proc = new Process())
                    {
                        proc.StartInfo.FileName = url;
                        proc.StartInfo.Verb = VERB_OPEN;
                        proc.Start();
                    }
                }
                return true;
            }
            catch (FileNotFoundException)
            {
                DialogService.ShowError($"Can't open '{url}'"); // friendlier message
                return false;
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool CloneRepository()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return ExecuteCommand(FILE_CLONE_REPOSITORY);
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenFolder()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return ExecuteCommand(FILE_OPEN_FOLDER);
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenFolder(string path)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (Directory.Exists(path))
                {
                    return ExecuteCommand(FILE_OPEN_FOLDER, path.ToQuotedString());
                }
                else
                {
                    DialogService.ShowError($"Unable to find '{path}'");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenProject()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return ExecuteCommand(FILE_OPEN_PROJECT);
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenProject(string path)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                if (File.Exists(path))
                {
                    return ExecuteCommand(FILE_OPEN_PROJECT, path.ToQuotedString());
                }
                else
                {
                    DialogService.ShowExclamation($"Unable to find '{path}'");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool CreateNewProject()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                ExecuteCommand(FILE_NEW_PROJECT);

                return true;
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool Restart(bool confirm = true, bool elevated = false)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                if (IsRunningElevated)
                {
                    if (!DialogService.Confirmed("Visual Studio is currently running as Administrator. To return to running normally Visual Studio will need to close"))
                    {
                        return false;
                    }

                    CloseVisualStudio();

                    return true;
                }

                if (confirm && !RestartConfirmed(elevated))
                    return false;

                switch (elevated)
                {
                    case true:
                        RestartElevated();
                        break;

                    case false:
                        RestartNormal();
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public async Task<bool> OpenInNewInstanceAsync(string path)
        {
            return path.IsFolder()
                ? await OpenFolderInNewInstanceAsync(path)
                : await OpenProjectOrSolutionInNewInstanceAsync(path);
        }

        private Task<bool> OpenFolderInNewInstanceAsync(string path)
        {
            var result = false;

            try
            {
                if (Directory.Exists(path))
                {
                    using (var process = new Process())
                    {
                        var startInfo = new ProcessStartInfo("devenv.exe", "/edit " + path.ToQuotedString());

                        process.StartInfo = startInfo;
                        process.Start();

                        result = true;
                    }
                }
                else
                {
                    DialogService.ShowError($"Unable to find '{path}'");

                    result = false;
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);

                result = false;
            }

            return Task.FromResult(result);
        }

        private Task<bool> OpenProjectOrSolutionInNewInstanceAsync(string path)
        {
            var result = false;

            try
            {
                using (var proc = new Process())
                {
                    proc.StartInfo.FileName = path.ToQuotedString();
                    proc.StartInfo.Verb = VERB_OPEN;
                    proc.Start();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                result = false;
            }

            return Task.FromResult(result);
        }

        private void CloseVisualStudio()
            => Dte.Quit();

        private bool RestartConfirmed(bool elevated)
        {
            var suffix = (elevated) ? " as Administrator" : "";

            return DialogService.Confirmed($"You're about to restart Visual Studio{suffix}");
        }

        private string RestartNormal()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            const uint mode = (uint)__VSRESTARTTYPE.RESTART_Normal;

            return Restart(mode);
        }

        private string RestartElevated()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            const uint mode = (uint)__VSRESTARTTYPE.RESTART_Elevated;

            return Restart(mode);
        }

        private string Restart(uint mode)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                //VS.Shell.RestartAsync().FireAndForget();
                return ErrorHandler.Failed(VsShell4.Restart(mode))
                    ? "Unable to restart Visual Studio"
                    : "";
            }
            catch (Exception ex)
            {
                return ex.ExtendedMessage();
            }
        }

        private bool IsRunningElevated
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                VsShell3.IsRunningElevated(out var elevated);

                return elevated;
            }
        }

        public bool ShowOptions<T>()
            where T : DialogPage
        {
            try
            {
                var guid = typeof(T).GUID;

                if (ExecuteCommand(TOOLS_OPTIONS, guid.ToString()))
                    return true;
                else
                {
                    DialogService.ShowError("Unable to open the options page");
                    return false;
                };

            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }
    }
}