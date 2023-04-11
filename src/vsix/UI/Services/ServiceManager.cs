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
        internal static StartPagePlusContainer Container { get; set; }

        public static void RegisterServices(StartPagePlusContainer container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));

            Container.AddSingleton<IDateTimeService, DateTimeService>();
            Container.AddSingleton<IDialogService, ToolkitDialogService>();

            //---

            Container.AddSingleton<IMruService, MruPrivateSettingsService>();
            Container.AddSingleton<IRecentItemActionService, RecentItemActionService>();
            Container.AddSingleton<IRecentItemDataService, RecentItemDataService>();
            Container.AddSingleton<IRecentItemCommandService, RecentItemCommandService>();

            //---

            Container.AddSingleton<IStartItemDataService, StartItemDataService>();
            Container.AddSingleton<IStartItemCommandService, StartItemCommandService>();

            //---

            Container.AddSingleton<INewsItemDataService, NewsItemDataService>();
            Container.AddSingleton<INewsItemCommandService, NewsItemCommandService>();
            Container.AddSingleton<INewsItemActionService, NewsItemActionService>();

            Container.AddSingleton<IVisualStudioService, VisualStudioService>();
        }

        // only needed if exposing properties, like in ViewModelManager
        private static T GetService<T>()
            where T : IService
        {
            var viewModel = Container.GetInstance<T>();

            return viewModel;
        }
    }
}