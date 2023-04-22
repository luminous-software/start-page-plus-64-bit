using CommunityToolkit.Mvvm.ComponentModel;

namespace StartPagePlus.DI
{
    using UI.Services;

    internal class StartPagePlusContainer : MicrosoftDependencyInjectionContainer
    {
        public T GetService<T>()
            where T : ServiceBase
        {
            try
            {
                var service = GetInstance<T>();

                return service;

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public T GetViewModel<T>()
            where T : ObservableObject
        {
            try
            {
                var viewModel = GetInstance<T>();

                return viewModel;

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}