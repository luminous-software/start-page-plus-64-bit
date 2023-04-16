using CommunityToolkit.Mvvm.ComponentModel;

namespace StartPagePlus.DI
{
    using UI.Services;

    internal class StartPagePlusContainer : MicrosoftDependencyInjectionContainer
    {
        public T GetGetService<T>()
            where T : ServiceBase
        {
            var viewModel = GetInstance<T>();

            return viewModel;
        }

        public T GetViewModel<T>()
            where T : ObservableObject
        {
            var viewModel = GetInstance<T>();

            return viewModel;
        }
    }
}