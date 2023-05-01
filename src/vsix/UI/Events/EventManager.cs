using CommunityToolkit.Mvvm.Messaging;

using Community.VisualStudio.Toolkit;

namespace StartPagePlus.UI.Events
{
    using DI;

    using Messages;

    internal class EventManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventManager"/> class.
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

        /// <summary>
        /// Gets the <see cref="IMessenger"/> instance in use.
        /// </summary>
        private static IMessenger Messenger { get; }

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