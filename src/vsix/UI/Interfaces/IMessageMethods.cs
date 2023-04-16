using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Interfaces
{
    // syntactic sugar for better readability

    public interface IMessageMethods
    {
        void ListenFor<TMessage>(object recipient, MessageHandler<object, TMessage> action)
            where TMessage : class, new();

        void SendMessage<TMessage>()
            where TMessage : class, new();

        void SendMessage<TMessage>(TMessage message)
            where TMessage : class, new();
    }
}