namespace StartPagePlus.UI.Services
{
    using System;
    using System.Threading.Tasks;

    using StartPagePlus.UI.Interfaces;

    public abstract class ServiceBase : IService
    {
        public virtual bool RunMethod(Func<Task<bool>> asyncMethod)
        => true;
        //=> RootMethods.RunMethod(asyncMethod);

        public virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
        => true;
        //=> RootMethods.RunMethod(asyncMethod);

        //---

        public virtual void LìstenFor<T>(object recipient, Action<T> action)
            where T : IViewModel
        { }
        //=> RootMethods.ListenFor(recipient, action);

        //public virtual void SendMessage(MessageBase message)
        //    => RootMethods.SendMessage(message);
    }
}