using CommunityToolkit.Mvvm.Input;

using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.ViewModels.StartItems
{
    using StartPagePlus.UI.Interfaces;

    public abstract partial class StartItemViewModel : ViewModelBase
    {
        public StartItemViewModel(IStartItemActionService actionService)
        {
            ActionService = actionService;
            ImageSize = 40;
            Margin = "5,5,0,0";
            IsEnabled = true;
        }

        public ImageMoniker Moniker { get; set; }

        public int ImageSize { get; set; }

        public string Margin { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEnabled { get; set; }

        public IStartItemActionService ActionService { get; }

        [RelayCommand]
        protected virtual void OnClick()
        { }
    }
}