using System;
using System.Collections.Generic;

namespace StartPagePlus.UI.Interfaces.StartItems
{
    using ViewModels;

    public interface IStartItemCommandService
    {
        List<CommandViewModel> GetCommands(Action openChangelog, Action openWebsite, Action openSettings);
    }
}