namespace StartPagePlus.UI.Interfaces.StartItems
{
    using System;
    using System.Collections.Generic;

    using StartPagePlus.UI.ViewModels;

    public interface IStartItemCommandService
    {
        List<CommandViewModel> GetCommands(Action openChangelog, Action openWebsite, Action openSettings);
    }
}