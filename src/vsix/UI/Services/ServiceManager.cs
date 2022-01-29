namespace StartPagePlus.UI.Services
{

    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

    using Luminous.Code.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    using StartPagePlus.Core.Interfaces;
    using StartPagePlus.UI.Interfaces;
    using StartPagePlus.UI.Interfaces.RecentItems;
    using StartPagePlus.UI.Interfaces.StartItems;
    using StartPagePlus.UI.Services.RecentItems;
    using StartPagePlus.UI.Services.StartItems;

    public static class ServiceManager
    {
        public static IDateTimeService DateTimeService { get; set; }

        public static IMruService MruService { get; set; }

        //---

        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IDialogService, ToolkitDialogService>();

            //---

            services.AddSingleton<IMruService, MruPrivateSettingsService>();
            services.AddSingleton<IRecentItemDataService, RecentItemDataService>();
            services.AddSingleton<IRecentItemCommandService, RecentItemCommandService>();

            //---

            services.AddSingleton<IStartItemDataService, StartItemDataService>();
            services.AddSingleton<IStartItemCommandService, StartItemCommandService>();
        }

        //---

        public static T GetService<T>()
            where T : IService
        {
            var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            var service = serviceProvider.GetService<T>();

            return service;
        }
    }
}