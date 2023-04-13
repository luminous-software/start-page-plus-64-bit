﻿using System;
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
    using Core.Interfaces;

    using StartPagePlus.Options.Pages;

    using UI.Interfaces;

    public class ToolkitVisualStudioService : IVisualStudioService
    {
        private const string VERB_OPEN = "Open";

        private const string FILE_OPEN_FOLDER = "File.OpenFolder";
        private const string FILE_OPEN_PROJECT = "File.OpenProject";
        private const string FILE_NEW_PROJECT = "File.NewProject";
        private const string FILE_CLONE_REPOSITORY = "File.CloneRepository";

        private const string TOOLS_OPTIONS = "Tools.Options";

        private const uint FORCE_NEW_WINDOW = (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew;
        private const string VS_RUNNING_AS_ADMIN = "VS is currently running elevated. To return to running normally VS will need to close. Do you want to continue?";
        private const string RESTART_VS_AS_ADMIN = "You're about to restart VS as Administrator (elevated)";

        public ToolkitVisualStudioService(IDialogService dialogService)
            => DialogService = dialogService;

        private IDialogService DialogService { get; }

        private IVsWebBrowsingService BrowsingService
            => VS.GetRequiredService<SVsWebBrowsingService, IVsWebBrowsingService>();

        private static DTE2 Dte
            => VS.GetRequiredService<_DTE, DTE2>(); //YD: investigate toolkit for DTE2 alternative, also a way to not call every service (some may never be used)

        private IVsShell3 VsShell3
            => VS.GetRequiredService<SVsShell, IVsShell3>(); //YD: investigate toolkit for IVsShell3 alternative

        private IVsShell4 VsShell4
            => VS.GetRequiredService<SVsShell, IVsShell4>(); //YD: investigate toolkit for IVsShell4 alternative

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
                DialogService.ShowException(ex);
                result = false;
            }

            return result;
        }

        public bool OpenWebPage(string url, bool openInVS) //YD: OpenWebpage uses BrowsingService & Process
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

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

        public bool OpenFolder() //: YD send message to RecentItemsViewModel to refresh the list
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                return ExecuteCommand(FILE_OPEN_FOLDER); // opens Open Folder dialog
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenFolder(string path) //: YD send message to RecentItemsViewModel to refresh the list
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

                return ExecuteCommand(FILE_OPEN_PROJECT); // opens Open Project/Solution dialog
            }
            catch (ArgumentException ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        public bool OpenProject(string path) //: YD send message to RecentItemsViewModel to refresh the list
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

        private string RestartSuffix(bool elevated) // YD: clumsy whe combined with below
        {
            var suffix = (elevated)
                ? " as Administrator (elevated)"
                : "";

            return suffix;
        }

        public bool Restart(bool confirmRestart = true, bool asAdmin = false) //YD: investigate any better ways to Restart
        {
            //YD: thing whole restart code needs to be examined carely as to the work flow
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                // currently running elevated

                if (IsRunningElevated)
                {
                    if (DialogService.Confirmed(VS_RUNNING_AS_ADMIN))
                    {
                        CloseVisualStudio();

                        return true; // should never reach here
                    }
                    else
                    {
                        return false;
                    }
                }

                // YD: re-jig code here

                //if (confirmRestart && RestartSuffix(asAdmin))
                //{
                //    switch (asAdmin)
                //    {
                //        case true:
                //            RestartElevated();
                //            break;

                //        case false:
                //            RestartNormal();
                //            break;
                //    }

                //    return true;
                //}

                return false;
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }

        private void RestartNormal()
            => Restart(false);

        private void RestartElevated()
            => Restart(true);

        private void Restart(bool elevated = false)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                VS.Shell.RestartAsync(elevated).FireAndForget();
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
            }
        }

        private bool IsRunningElevated //YD: IsRunningElevated is using VsShell3
        {
            get
            {
                try
                {
                    ThreadHelper.ThrowIfNotOnUIThread();

                    VsShell3.IsRunningElevated(out bool elevated);

                    return elevated;

                }
                catch (Exception ex)
                {
                    DialogService.ShowException(ex);
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
                DialogService.ShowException(ex);
                result = false;
            }
            return Task.FromResult(result);
        }

        private void CloseVisualStudio() //YD: CloseVisualStudio is using DTE
            => Dte.Quit();

        public bool ShowOptions<T>()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                VS.Settings.OpenAsync<OptionsProvider.General>().FireAndForget();
                return true;
            }
            catch (Exception ex)
            {
                DialogService.ShowException(ex);
                return false;
            }
        }
    }
}