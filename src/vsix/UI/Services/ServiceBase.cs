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

        //---

        protected ServiceBase(IAsyncMethodService methodService, IMessenger messenger)
        {
            _methodService = methodService ?? throw new ArgumentNullException(nameof(methodService));

            Messenger = messenger ?? throw new ArgumentNullException(nameof(methodService));
        }

        //---

        protected IMessenger Messenger { get; }

        //---

        protected bool Run(Func<Task<bool>> asyncMethod)
            => _methodService.Run(asyncMethod);

        protected bool? Run(Func<Task<bool?>> asyncMethod)
            => _methodService.Run(asyncMethod);
    }
}