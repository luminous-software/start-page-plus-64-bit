namespace StartPagePlus.UI.ViewModels
{
    using Task = System.Threading.Tasks.Task;

    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Toolkit.Mvvm.ComponentModel;

    public class ViewModelBase : ObservableObject
    {
        //public virtual bool RunMethod(Func<Task<bool>> asyncMethod)
        //    => RootMethods.RunMethod(asyncMethod);

        //public virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
        //    => RootMethods.RunMethod(asyncMethod);

        //public virtual void LìstenFor<T>(object recipient, Action<T> action)
        //    where T : IMessage
        //    => RootMethods.ListenFor(recipient, action);

        //public virtual void SendMessage(MessageBase message)
        //    => RootMethods.SendMessage(message);
    }
}