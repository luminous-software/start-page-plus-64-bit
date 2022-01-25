namespace StartPagePlus.UI.Services
{

    using Community.VisualStudio.Toolkit;
    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

    using Luminous.Code.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    using StartPagePlus.UI.Interfaces;

    public static class ServiceManager
    {
        public static IDateTimeService DateTimeService { get; set; }

        public static IMruService MruService { get; set; }
        
        public static IRecentItemDataService RecentItemDataService { get; set; }

        public static T GetService<T>()
            where T : IService
        {
            var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
            var service = serviceProvider.GetService<T>();

            return service;
        }

        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IMruService, MruPrivateSettingsService>();
            services.AddSingleton<IRecentItemDataService, RecentItemDataService>();
        }
    }
}