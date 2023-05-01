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
        protected void ListenFor<TMessage>(object recipient, MessageHandler<object, TMessage> action)
            where TMessage : class //, new()
            => Messenger.Register(recipient, action);

        //--- IRunMethods

        public virtual bool RunMethod(Func<Task<bool>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);

        public virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);
    }
}