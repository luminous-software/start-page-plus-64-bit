using CommunityToolkit.Mvvm.Messaging;

using Community.VisualStudio.Toolkit;

namespace StartPagePlus.UI.Events
{
    using DI;

    using Messages;

    using Services;

    using StartPagePlus.Core.Interfaces;

    internal class EventManager
    {
        private static readonly IDialogService _dialogService;
        private static readonly IAsyncMethodService _methodService;
        /// </summary>
        /// <remarks>
        /// This constructor will produce an instance that will use the <see cref="WeakReferenceMessenger.Default"/> instance
        /// to perform requested operations. It will also be available locally through the <see cref="Messenger"/> property.
        /// </remarks>
        static EventManager()
        { Messenger = WeakReferenceMessenger.Default; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventManager"/> class.
        /// </summary>
        /// <param name="messenger">The <see cref="IMessenger"/> instance to use to send messages.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="messenger"/> is <see langword="null"/>.</exception>
        //static EventManager(IMessenger messenger)
        //{
        //    Messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        //}

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
            VS.Events.SolutionEvents.OnAfterCloseSolution += OnAfterCloseSolution;
        }

        internal static void DeregisterEvents(StartPagePlusContainer container)
        {
            VS.Events.SolutionEvents.OnAfterCloseSolution -= OnAfterCloseSolution;
        }

        //---

        private static void OnAfterCloseSolution()
            => Messenger.Send<RecentItemsRefresh>();
    }
}