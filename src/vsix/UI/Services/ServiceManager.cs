using System;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;
    using Core.Services;

    using DI;

    using Interfaces.NewsItems;
    using Interfaces.RecentItems;
    using Interfaces.StartItems;

    using NewsItems;

    using RecentItems;

    using StartItems;

    using UI.Interfaces;

    using UI.Services.Other;

    internal static class ServiceManager
    {
        private static StartPagePlusContainer _container;

        // only needed if exposing properties, like in ViewModelManager
        //public static IDialogService DialogService
        //    => GetService<IDialogService>();

        public static void RegisterServices(StartPagePlusContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

            container.AddSingleton<IDateTimeService, DateTimeService>();
            container.AddSingleton<IDialogService, ToolkitDialogService>();

            //---

            container.AddSingleton<IMruService, MruPrivateSettingsService>();
            container.AddSingleton<IRecentItemDataService, RecentItemDataService>();
            container.AddSingleton<IRecentItemCommandService, RecentItemCommandService>();

            //---

            container.AddSingleton<IStartItemDataService, StartItemDataService>();
            container.AddSingleton<IStartItemCommandService, StartItemCommandService>();

            //---

            container.AddSingleton<INewsItemDataService, NewsItemDataService>();
            container.AddSingleton<INewsItemCommandService, NewsItemCommandService>();
            container.AddSingleton<INewsItemActionService, NewsItemActionService>();

            container.AddSingleton<IVisualStudioService, VisualStudioService>();
        }

        //private static T GetService<T>()
        //    where T : IService
        //{
        //    var viewModel = _container.GetInstance<T>();

        //    return viewModel;
        //}
    }
}