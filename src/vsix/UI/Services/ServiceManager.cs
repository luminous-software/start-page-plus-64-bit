using System;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;
    using Core.Services;

    using DI;

    using Interfaces;
    using Interfaces.NewsItems;
    using Interfaces.RecentItems;
    using Interfaces.StartItems;

    using NewsItems;

    using RecentItems;

    using StartItems;

    using Other;

    internal static class ServiceManager
    {
        private static StartPagePlusContainer _container;

        public static void RegisterServices(StartPagePlusContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

            //--- recent items

            _container.AddSingleton<IMruService, MruPrivateSettingsService>();
            _container.AddSingleton<IRecentItemActionService, RecentItemActionService>();
            _container.AddSingleton<IRecentItemDataService, RecentItemDataService>();
            _container.AddSingleton<IRecentItemCommandService, RecentItemCommandService>();

            //--- start items

            _container.AddSingleton<IStartItemActionService, StartItemActionService>();
            _container.AddSingleton<IStartItemDataService, StartItemDataService>();
            _container.AddSingleton<IStartItemCommandService, StartItemCommandService>();

            //--- news items

            _container.AddSingleton<INewsItemDataService, NewsItemDataService>();
            _container.AddSingleton<INewsItemCommandService, NewsItemCommandService>();
            _container.AddSingleton<INewsItemActionService, NewsItemActionService>();

            //--- other

            _container.AddSingleton<IDateTimeService, DateTimeService>();
            _container.AddSingleton<IDialogService, ToolkitDialogService>();
            _container.AddSingleton<IVisualStudioService, ToolkitVisualStudioService>();
        }

        // only needed if exposing properties, like in ViewModelManager
        //private static T GetService<T>()
        //    where T : IService
        //{
        //    var viewModel = Container.GetInstance<T>();

        //    return viewModel;
        //}
    }
}