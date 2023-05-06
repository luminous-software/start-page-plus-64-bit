using System;

using Community.VisualStudio.Toolkit;

using Luminous.Code.Extensions.Exceptions; //YD:???

namespace StartPagePlus.UI.Services
{
    using Core;
    using Core.Interfaces;
    using Core.Services;

    using DI;

    using Interfaces;
    using Interfaces.NewsItems;
    using Interfaces.RecentItems;
    using Interfaces.StartItems;

    using NewsItems;

    using Other;

    using RecentItems;

    using StartItems;

    internal class ServiceManager
    {
        private static StartPagePlusContainer _container;

        //---

        public static IAsyncMethodService AsyncMethodService
            => GetService<IAsyncMethodService>();

        public static IDialogService DialogService
            => GetService<IDialogService>();

        //---

        public static void RegisterServices(StartPagePlusContainer container)
        {
            try
            {
                _container = container ?? throw new ArgumentNullException(nameof(container));

                //--- other (keep these first)

                _container.AddSingleton<IDateTimeService, DateTimeService>();
                _container.AddSingleton<IDialogService, ToolkitDialogService>();
                _container.AddSingleton<IAsyncMethodService, AsyncMethodService>();
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
                //YD: it might be better to get an instance of the DialogService & store it in a field to do this, for consistency?
                VS.MessageBox.ShowError(ex.ExtendedMessage());
            }
        }

        //---

        // NOTE: only use properties that use GetService when constructor injection is not possible (like in UserControls, or static constructors)

        private static T GetService<T>()
            where T : ISimpleService
        {
            return (_container is null)
                ? throw new NullReferenceException(nameof(_container))
                : _container.GetInstance<T>();
        }
    }
}