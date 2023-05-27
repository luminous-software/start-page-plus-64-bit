using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using StartPagePlus.Core;

    internal abstract class ServiceBase : IService
    {
        private readonly IAsyncMethodService _methodService;
        private readonly IMessenger _messenger;

        //---

        protected ServiceBase(IAsyncMethodService methodService, IMessenger messenger)
        {
            _methodService = methodService ?? throw new ArgumentNullException(nameof(methodService));
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        //---

        //protected IMessenger Messenger
        //    => _messenger;

        //---

        protected void Send<TService>()
            where TService : class, new()
            => _messenger.Send<TService>();

        protected void Send<TService>(TService service)
            where TService : class, new()
            => _messenger.Send<TService>(service);

        protected bool Run(Func<Task<bool>> asyncMethod)
            => _methodService.Run(asyncMethod);

        protected bool? Run(Func<Task<bool?>> asyncMethod)
            => _methodService.Run(asyncMethod);
    }
}