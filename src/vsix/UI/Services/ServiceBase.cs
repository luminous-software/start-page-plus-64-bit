using System;
using System.Threading.Tasks;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using UI.Interfaces;

    internal abstract class ServiceBase : IService
    {
        internal virtual bool RunMethod(Func<Task<bool>> asyncMethod)
        => true;
        // ==> RootMethods.RunMethod(asyncMethod);

        internal virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
        => true;
        // ==> RootMethods.RunMethod(asyncMethod);

        //---

        internal virtual void LìstenFor<T>(object recipient, Action<T> action)
            where T : IViewModel
        { }
        // ==> RootMethods.ListenFor(recipient, action);

        //public virtual void SendMessage(MessageBase message)
        //    => RootMethods.SendMessage(message);
    }
}