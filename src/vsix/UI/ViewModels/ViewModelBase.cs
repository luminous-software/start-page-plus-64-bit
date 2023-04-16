using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    using Methods;

    public class ViewModelBase : ObservableRecipient, IViewModel
    {
        //--- IMessageMethods

        public virtual void ListenFor<TMessage>(object recipient, MessageHandler<object, TMessage> action)
            where TMessage : class, new()
            => MessageMethods.ListenFor(recipient, action);

        public virtual void SendMessage<TMessage>()
            where TMessage : class, new()
            => MessageMethods.SendMessage<TMessage>();

        public virtual void SendMessage<TMessage>(TMessage message)
            where TMessage : class, new()
            => MessageMethods.SendMessage(message);

        //--- IRunMethods

        public virtual bool RunMethod(Func<Task<bool>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);

        public virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);
    }
}