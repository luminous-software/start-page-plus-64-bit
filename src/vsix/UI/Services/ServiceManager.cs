//namespace StartPagePlus.UI.Services
//{

//    using Community.VisualStudio.Toolkit;
//    using Community.VisualStudio.Toolkit.DependencyInjection.Core;

//    using Microsoft.Extensions.DependencyInjection;

//    public static class ServiceManager
//    {
//        public static T GetService<T>()
//            where T : class //YD to be revised
//        {
//            var serviceProvider = VS.GetRequiredService<SToolkitServiceProvider<StartPagePlusPackage>, IToolkitServiceProvider<StartPagePlusPackage>>();
//            var service = serviceProvider.GetService<T>();

//            return service;
//        }

//        internal static void RegisterServices(IServiceCollection services)
//        {
//            //services.AddSingleton<IService, Service>();
//        }
//    }
//}