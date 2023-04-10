namespace StartPagePlus.UI.Services.RecentItems
{
    using System;
    using System.Collections.Generic;

    using CommunityToolkit.Mvvm.Input;

    using Microsoft.VisualStudio.Imaging;

    using StartPagePlus.UI.Interfaces.RecentItems;

    using ViewModels;

    internal class RecentItemCommandService : IRecentItemCommandService
    {
        public List<CommandViewModel> GetCommands(Action refresh, Action showSettings)
            => new List<CommandViewModel>
            {
                new CommandViewModel
                {
                    Name = "Refresh",
                    Command = new RelayCommand(refresh),
                }  ,
                new CommandViewModel
                {
                    Name = "Settings",
                    Command = new RelayCommand(showSettings),
                }
            };

        public List<ContextCommandViewModel> GetContextCommands(
            Func<bool> canPin, Action pin,
            Func<bool> canUnpin, Action unpin,
            Func<bool> canRemove, Action remove,
            Func<bool> canCopyPath, Action copyPath,
            Func<bool> canEditPath, Action editPath,
            Func<bool> canOpenInVS, Action openInVS
            )
            => new List<ContextCommandViewModel>
            {
                new ContextCommandViewModel
                {
                    Name = "Pin item",
                    Moniker = KnownMonikers.Pin,
                    Command = new RelayCommand(pin, canPin),
                    IsVisible = canPin(),
                },
                new ContextCommandViewModel
                {
                    Name = "Unpin item",
                    Moniker = KnownMonikers.Unpin,
                    Command = new RelayCommand(unpin, canUnpin),
                    IsVisible = canUnpin(),
                },
                new ContextCommandViewModel
                {
                    Name = "Remove item",
                    Moniker = KnownMonikers.DeleteListItem,
                    Command = new RelayCommand(remove, canRemove),
                    IsVisible = canRemove(),
                },
                new ContextCommandViewModel
                {
                    Name = "Copy item path",
                    Moniker = KnownMonikers.Copy,
                    Command = new RelayCommand(copyPath, canCopyPath),
                    IsVisible = canCopyPath(),
                },
                new ContextCommandViewModel
                {
                    Name = "Edit item path",
                    Moniker = KnownMonikers.Edit,
                    Command = new RelayCommand(editPath, canEditPath),
                    IsVisible = canEditPath(),
                },
                new ContextCommandViewModel
                {
                    Name = "Open in VS",
                    Moniker = KnownMonikers.VisualStudio,
                    Command = new RelayCommand(openInVS, canOpenInVS),
                    IsVisible = canCopyPath(),
                },
            };
    }
}