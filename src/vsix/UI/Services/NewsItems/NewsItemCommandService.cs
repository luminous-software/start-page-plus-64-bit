using System;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace StartPagePlus.UI.Services
{
    using Core;

    using Interfaces.NewsItems;

    using ViewModels;

    internal class NewsItemCommandService : ServiceBase, INewsItemCommandService
    {
        public NewsItemCommandService(IAsyncMethodService methodService, IMessenger messenger) : base(methodService, messenger)
        { }

        public List<CommandViewModel> GetCommands(Action refresh, Action openSettings)
            => new()
            {
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(refresh),
                },
                new CommandViewModel
                {
                    Name = "Settings",
                    Command = new RelayCommand(openSettings),
                }
            };
    }
}