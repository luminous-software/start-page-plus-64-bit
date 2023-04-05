using Luminous.Code.Interfaces;

namespace StartPagePlus.UI.Services
{
    using Interfaces.NewsItems;
    using Interfaces.RecentItems;
    using Interfaces.StartItems;

    using NewsItems;

    using RecentItems;

    using StartItems;

    using StartPagePlus.DI;

    internal static class ServiceManager
    {
        public static void RegisterServices(StartPagePlusContainer container)
        {
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
        }
    }
}