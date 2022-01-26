using System;

using Community.VisualStudio.Toolkit;

using Luminous.Code.Extensions.Exceptions;

namespace StartPagePlus.UI.Services
{
    using Core.Interfaces;

    public class ToolkitDialogService : IDialogService
    {
        public void ShowNotImplemented(string method)
            => VS.MessageBox.Show(Vsix.Name, $"'{method}' is not yet implemented"); //YD: add ShowNotImplemented to VS.Notifications.MessageBox

        public void ShowInformation(string message)
            => VS.MessageBox.Show(Vsix.Name, message); //YD: add ShowInformation to VS.Notifications.MessageBox

        public void ShowExclamation(string message)
            => VS.MessageBox.Show(Vsix.Name, message); //YD: add ShowExclamation to VS.Notifications.MessageBox

        public void ShowWarning(string message)
            => VS.MessageBox.ShowWarning(Vsix.Name, message); //YD: add ShowWarning to VS.Notifications.MessageBox

        public void ShowSuccess(string message)
            => VS.MessageBox.Show(Vsix.Name, message); //YD: add ShowSuccess to VS.Notifications.MessageBox

        public void ShowError(string message)
            => VS.MessageBox.ShowError(Vsix.Name, message);

        public void ShowException(Exception ex)
            => VS.MessageBox.ShowError(Vsix.Name, ex.ExtendedMessage()); //YD: add ShowException to VS.Notifications.MessageBox

        public bool ShowConfirm(string question)
            => VS.MessageBox.ShowConfirm(Vsix.Name, question);

        public bool Confirmed(string question)
            => ShowConfirm(question); //YD: add Confirmed to VS.Notifications.MessageBox
    }
}