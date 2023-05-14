using System;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Messages
{
    using DI;

    internal class MessengerManager
    {
        private static StartPagePlusContainer _container;

        //---

        public static IMessenger Messenger
            => _container?.GetInstance<IMessenger>();

        //---

        public static void RegisterMessenger(StartPagePlusContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

            _container.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
        }
    }
}