using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Community.VisualStudio.Toolkit;

using EnvDTE;

using EnvDTE80;

using Luminous.Code.Extensions.Strings;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using Process = System.Diagnostics.Process;
using Task = System.Threading.Tasks.Task;

namespace StartPagePlus.UI.Services.Other
{
    using CommunityToolkit.Mvvm.Messaging;

    using Core.Interfaces;

    using Interfaces;

    using StartPagePlus.Core;

    internal class ToolkitVisualStudioService : ServiceBase, IVisualStudioService
    {
        private const string VERB_OPEN = "Open";

        private const string FILE_OPEN_FOLDER = "File.OpenFolder";
        private const string FILE_OPEN_PROJECT = "File.OpenProject";
        private const string FILE_NEW_PROJECT = "File.NewProject";
        private const string FILE_CLONE_REPOSITORY = "File.CloneRepository";

        private const string TOOLS_OPTIONS = "Tools.Options";

        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;

        //private const string RUNNING_ELEVATED_MESSAGE = @"VS is currently running elevated (as admin) & will remain elevated if you choose to continue.\n\nDo you want to continue?";
        //private const string VS_MUST_CLOSE_MESSAGE = @"VS is currently running elevated. If you want to return to mom-elevated VS Must close.\\n\\nDo you want to continue?";

        private const string RESTART_MESSAGE = "You're about to restart VS. Do you want to continue?";
        //VS will remain non-elevated VS will need to close. Do you want to continue?";

        private readonly IDialogService _dialogService;

        //---

        public ToolkitVisualStudioService(IDialogService dialogService, IAsyncMethodService methodService, IMessenger messenger) : base(methodService, messenger)
            => _dialogService = dialogService;

        //---

        private static DTE2 Dte
            => VS.GetRequiredService<_DTE, DTE2>(); //YD: investigate toolkit for DTE2 alternative, also a way to not call every service (some may never be used)

        private IVsShell3 VsShell3
            => VS.GetRequiredService<SVsShell, IVsShell3>(); //YD: investigate toolkit for IVsShell3 alternative

        //private IVsShell4 VsShell4
        //    => VS.GetRequiredService<SVsShell, IVsShell4>(); //YD: investigate toolkit for IVsShell4 alternative

        public bool ExecuteCommand(string action, string args = "")
        {
            var result = false;

            try
            {
                result = ThreadHelper.JoinableTaskFactory.Run(
                    async () => result = await VS.Commands.ExecuteAsync(action, args)
                    );
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
                result = false;
            }

            return result;
        }

        public bool OpenWebPage(string url, bool openInVS) //YD: OpenWebpage uses BrowsingService & Process
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                var browsingService = VS.GetRequiredService<SVsWebBrowsingService, IVsWebBrowsingService>();

                if (openInVS == true)
                {
                    browsingService.Navigate(url, FORCE_NEW_WINDOW, out var ppFrame);
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
                _dialogService.ShowError($"Can't open '{url}'"); // friendlier message
                return false;
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        public bool CloneRepository()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                return ExecuteCommand(FILE_CLONE_REPOSITORY);
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenFolder() //: YD send message to RecentItemsViewModel to refresh the list
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                return ExecuteCommand(FILE_OPEN_FOLDER); // opens Open Folder dialog
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenFolder(string path) //: YD send message to RecentItemsViewModel to refresh the list
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                if (Directory.Exists(path))
                {
                    return ExecuteCommand(FILE_OPEN_FOLDER, path.ToQuotedString());
                }
                else
                {
                    _dialogService.ShowError($"Unable to find '{path}'");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenProject()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                return ExecuteCommand(FILE_OPEN_PROJECT); // opens Open Project/Solution dialog
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenProject(string path) //: YD send message to RecentItemsViewModel to refresh the list
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                if (File.Exists(path))
                {
                    return ExecuteCommand(FILE_OPEN_PROJECT, path.ToQuotedString());
                }
                else
                {
                    _dialogService.ShowExclamation($"Unable to find '{path}'"); //YD: aall DialogService.ShowXXX should return a bool result
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        public bool CreateNewProject()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                ExecuteCommand(FILE_NEW_PROJECT);

                return true;
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }

        // YD: revisit ToolkitVisualStudioService.Restart to include going from elevated to normal
        public bool Restart(bool confirmRestart = true, bool asAdmin = false)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var result = false;

            try
            {
                var restart = !confirmRestart || _dialogService.Confirmed(RESTART_MESSAGE);

                if (restart is true)
                {

                    RestartAs(elevated: asAdmin);

                    result = true; // won't end up being returned, as VS will have restarted
                }

                result = false; // restart was cancelled

                //var restart = false;
                //var closeVS = false;

                // YD: potential solution to going from elevated to normal
                //if (IsElevated && !asAdmin)
                //{
                //ask if ok to close, then close VS
                //}

                //if (IsRunningElevated)
                //{
                //    restart = !confirmRestart || _dialogService.Confirmed(RUNNING_ELEVATED_MESSAGE);

                //    if (restart is false)
                //    {
                //        return false; // restart was cancelled
                //    }

                //    closeVS = !confirmRestart || _dialogService.Confirmed(VS_MUST_CLOSE_MESSAGE);

                //    if (closeVS is true)
                //    {
                //        CloseVisualStudio();

                //        return true; // won't end up being returned, as VS will be closed
                //    }

                //    return false; // close vs was cancelled
                //}

                //// non-elevated

                //restart = !confirmRestart || _dialogService.Confirmed(RUNNING_NORMAL_MESSAGE);

                //if (restart is true)
                //{
                //    RestartBase(elevated: false);

                //    return true; // won't end up being returned, as VS will have restarted
                //}

                //return false; // restart was cancelled
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }

            return result;
        }

        private void RestartAs(bool elevated = false)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                VS.Shell.RestartAsync(elevated).FireAndForget();
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
            }
        }

        private bool IsRunningElevated //YD: IsRunningElevated is using VsShell3
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                try
                {
                    VsShell3.IsRunningElevated(out var elevated);

                    return elevated;

                }
                catch (Exception ex)
                {
                    _dialogService.ShowException(ex);
                    return false;
                }
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
                    _dialogService.ShowError($"Unable to find '{path}'");

                    result = false;
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);

                result = false;
            }

            return Task.FromResult(result);
        }

        private Task<bool> OpenProjectOrSolutionInNewInstanceAsync(string path) //YD: OpenProjectOrSolutionInNewInstanceAsync is using Process
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
                _dialogService.ShowException(ex);
                result = false;
            }
            return Task.FromResult(result);
        }

        private void CloseVisualStudio() //YD: CloseVisualStudio is using DTE
            => Dte.Quit();

        public bool ShowOptions<T>()
            where T : DialogPage
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                VS.Settings.OpenAsync<T>().FireAndForget();
                return true;
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
                return false;
            }
        }
    }
}