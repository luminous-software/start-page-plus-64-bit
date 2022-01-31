namespace StartPagePlus.UI.Interfaces.NewsItems
{
    using System;
    using System.Collections.Generic;

    using StartPagePlus.UI.ViewModels;

    public interface INewsItemCommandService
    {
        List<CommandViewModel> GetCommands(Action refresh, Action openSettings);
    }
}