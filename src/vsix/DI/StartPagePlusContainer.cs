namespace StartPagePlus.DI
{
    using UI.Services;
    using UI.ViewModels;

    internal class StartPagePlusContainer : MicrosoftDependencyInjectionContainer
    {
        private static StartPagePlusContainer _instance;

        //---

        public static StartPagePlusContainer Instance
            => _instance ??= new StartPagePlusContainer();

        //---

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
            where T : ViewModelBase
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