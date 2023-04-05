using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

namespace StartPagePlus.DI
{
    using Core.Interfaces;

    internal class MicrosoftDependencyInjectionContainer : IDependencyInjectionContainer
    {
        private static readonly ServiceCollection _serviceCollection = new();
        private static ServiceProvider _serviceProvider = null;

        public void AddSingleton<TService, TImplementation>()
        {
            _serviceCollection.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        public void AddSingleton<TService>()
        {
            _serviceCollection.AddSingleton(typeof(TService));
        }

        internal bool IsRegistered(Type serviceType)
            => _serviceCollection.Any(x => x.ServiceType == serviceType);

        public T GetInstance<T>()
        {
            if (_serviceProvider == null)
            {
                BuildServiceProvider();
            }

            return _serviceProvider.GetService<T>();
        }

        public object GetInstance(Type serviceType)
        {
            if (_serviceProvider == null)
            {
                BuildServiceProvider();
            }

            return _serviceProvider.GetService(serviceType);
        }


        private void BuildServiceProvider()
        {
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }
    }
}