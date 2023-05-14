using System;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

namespace StartPagePlus.DI
{
    using Core.Interfaces;

    internal class MicrosoftDependencyInjectionContainer : IDependencyInjectionContainer
    {
        private static readonly ServiceCollection _serviceCollection = new();
        private static ServiceProvider _serviceProvider = null;

        public void AddSingleton<TService>()
        {
            try
            {
                _serviceCollection.AddSingleton(typeof(TService));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddSingleton<TService>(TService implementation)
        {
            try
            {
                _serviceCollection.AddSingleton(typeof(TService), implementation);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddSingleton<TService, TImplementation>()
        {
            try
            {
                _serviceCollection.AddSingleton(typeof(TService), typeof(TImplementation));

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsRegistered(Type serviceType)
            => _serviceCollection.Any(x => x.ServiceType == serviceType);

        public T GetInstance<T>()
        {
            try
            {
                if (_serviceProvider == null)
                {
                    BuildServiceProvider();
                }

                return _serviceProvider.GetService<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object GetInstance(Type serviceType)
        {
            try
            {
                if (_serviceProvider == null)
                {
                    BuildServiceProvider();
                }

                return _serviceProvider.GetService(serviceType);

            }
            catch (Exception)
            {
                throw;
            }
        }


        private void BuildServiceProvider()
        {
            try
            {
                _serviceProvider = _serviceCollection.BuildServiceProvider();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}