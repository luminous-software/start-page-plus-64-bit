using System;

using Community.VisualStudio.Toolkit;

using Luminous.Code.Extensions.Exceptions;

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

        //public static IDialogService DialogService
        //    => GetService<IDialogService>();

        public static void RegisterServices(StartPagePlusContainer container)
        {
            try
            {
                _container = container ?? throw new ArgumentNullException(nameof(container));

                //--- other (kepp these first)

                _container.AddSingleton<IDateTimeService, DateTimeService>();
                _container.AddSingleton<IDialogService, ToolkitDialogService>();
                _container.AddSingleton<IVisualStudioService, ToolkitVisualStudioService>();

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
            }
            catch (Exception ex)
            {
                VS.MessageBox.ShowError(ex.ExtendedMessage());
            }
        }

        // WARNING: only use these properties when constructor injection is not possible

        //private static T GetService<T>()
        //    where T : ISimpleService
        //{
        //    return (_container is null)
        //        ? throw new ArgumentNullException(nameof(_container))
        //        : _container.GetInstance<T>();
        //}
    }
}