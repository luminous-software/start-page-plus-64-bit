using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Methods;

    internal abstract class ServiceBase : IService
    {
        //--- IRunMethods

        public virtual bool RunMethod(Func<Task<bool>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);

        public virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);

        //--- IMessageMethods

        public virtual void ListenFor<TMessage>(object recipient, MessageHandler<object, TMessage> action)
            where TMessage : class, new()
            => MessageMethods.ListenFor(recipient, action);

        public virtual void SendMessage<T>()
            where T : class, new()
            => MessageMethods.SendMessage<T>();

        public virtual void SendMessage<TMessage>(TMessage message)
            where TMessage : class, new()
            => MessageMethods.SendMessage(message);
    }
}