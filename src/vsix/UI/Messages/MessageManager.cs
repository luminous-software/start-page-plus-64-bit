using System;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Messages
{
    using StartPagePlus.DI;

    internal static class MessageManager
    {
        internal static StartPagePlusContainer Container { get; set; }

        public static void RegisterMessages(StartPagePlusContainer container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));

            container.AddSingleton<IMessenger, WeakReferenceMessenger>();
        }

        public static IMessenger GetMessenger
        {
            get => Container.GetInstance<IMessenger>();
        }
    }
}