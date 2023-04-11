using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Methods
{
    using Messages;

    internal class MessageMethods
    {
        public static void ListenFor<TMessage>(object recipient, MessageHandler<object, TMessage> action)
            where TMessage : class, new()
            => MessageManager.GetMessenger.Register(recipient, action);

        public static void SendMessage<TMessage>()
            where TMessage : class, new()
            => MessageManager.GetMessenger.Send<TMessage>();

        public static void SendMessage<TMessage>(TMessage message)
            where TMessage : class, new()
            => MessageManager.GetMessenger.Send(message);
    }
}