using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    using Methods;

    internal abstract class ServiceBase : IService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor will produce an instance that will use the <see cref="WeakReferenceMessenger.Default"/> instance
        /// to perform requested operations. It will also be available locally through the <see cref="Messenger"/> property.
        /// </remarks>
        protected ServiceBase()
            : this(WeakReferenceMessenger.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="messenger">The <see cref="IMessenger"/> instance to use to send messages.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="messenger"/> is <see langword="null"/>.</exception>
        protected ServiceBase(IMessenger messenger)
        {
            Messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        /// <summary>
        /// Gets the <see cref="IMessenger"/> instance in use.
        /// </summary>
        protected IMessenger Messenger { get; }


        //--- IRunMethods

        public virtual bool RunMethod(Func<Task<bool>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);

        public virtual bool? RunMethod(Func<Task<bool?>> asyncMethod)
            => RunMethods.RunMethod(asyncMethod);
    }
}