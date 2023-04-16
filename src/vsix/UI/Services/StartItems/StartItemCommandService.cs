using System;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.Input;

namespace StartPagePlus.UI.Services.StartItems
{
    using Interfaces.StartItems;

    using Options.Pages;

    using ViewModels;

    public class StartItemCommandService : IStartItemCommandService
    {
        private string VersionNumber
            => GeneralOptions.Instance.PackageVersion;

        public List<CommandViewModel> GetCommands(Action openChangelog, Action openWebsite, Action openOptions)
            => new()
            {
                new CommandViewModel
                {
                    Name = "Changelog",
                    Command = new RelayCommand(openChangelog)
                },
                new CommandViewModel
                {
                    Name = $"v{VersionNumber}",
                    Command = new RelayCommand(openWebsite)
                },
                new CommandViewModel
                {
                    Name = "Options",
                    Command = new RelayCommand(openOptions)
                },
            };
    }
}