using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.ViewModels
{
    using Interfaces;

    using StartPagePlus.Core;
    using StartPagePlus.UI.Services;

    public class ViewModelBase : ObservableRecipient, IViewModel
    {
        private readonly IAsyncMethodService _methodService;

        //---

        protected ViewModelBase()
        {
            _methodService = ServiceManager.AsyncMethodService ?? throw new ArgumentNullException(nameof(ServiceManager.AsyncMethodService));
        }

        //---

        protected void ListenFor<TMessage>(object recipient, MessageHandler<object, TMessage> action)
            where TMessage : class //, new()
            => Messenger.Register(recipient, action);

        public bool Run(Func<Task<bool>> asyncMethod)
            => _methodService.Run(asyncMethod);

        public bool? Run(Func<Task<bool?>> asyncMethod)
            => _methodService.Run(asyncMethod);
    }
}