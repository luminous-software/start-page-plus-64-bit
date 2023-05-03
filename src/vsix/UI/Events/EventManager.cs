using System;

using Community.VisualStudio.Toolkit;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Events
{
    using Core;

    using DI;

    using Messages;

    using Services;

    using StartPagePlus.Core.Interfaces;

    internal class EventManager
    {
        private static readonly IDialogService _dialogService;
        private static readonly IAsyncMethodService _methodService;
        private static readonly IMessenger _messenger;

        //---

        static EventManager()
        {
            _dialogService = ServiceManager.DialogService;
            _methodService = ServiceManager.AsyncMethodService;
            _messenger = MessengerManager.Messenger;
        }

        //---

        internal static void RegisterEvents(StartPagePlusContainer container)
        {
            VS.Events.SolutionEvents.OnBeforeOpenSolution += OnBeforeOpenSolution;
            VS.Events.SolutionEvents.OnAfterCloseSolution += OnAfterCloseSolution;
        }

        internal static void DeregisterEvents(StartPagePlusContainer container)
        {
            VS.Events.SolutionEvents.OnAfterCloseSolution -= OnAfterCloseSolution;
            VS.Events.SolutionEvents.OnBeforeOpenSolution -= OnBeforeOpenSolution;
        }

        //---

        private static void OnBeforeOpenSolution(string obj)
        {
            _methodService.Run(async () =>
            {
                var result = false;

                try
                {
                    var mainWindow = await VS.Windows.FindWindowAsync(PackageGuids.StartPagePlusWindow);

                    await mainWindow.CloseFrameAsync(FrameCloseOption.NoSave);

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    _dialogService.ShowException(ex);
                }

                return result;
            });
        }

        private static void OnAfterCloseSolution()
        {
            _methodService.Run(async () =>
            {
                var result = false;

                try
                {
                    var mainWindow = await VS.Windows.FindWindowAsync(PackageGuids.StartPagePlusWindow);

                    await mainWindow.ShowAsync();

                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    _dialogService.ShowException(ex);
                }

                return result;
            });

            _messenger.Send<RecentItemsRefresh>();
        }
    }
}