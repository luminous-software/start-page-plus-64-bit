using System;

using Community.VisualStudio.Toolkit;

using Luminous.Code.Extensions.Exceptions;

using StartPagePlus.Core.Interfaces;

namespace StartPagePlus.UI.Services.Other
{
    internal class ToolkitDialogService : IDialogService
    {
        //---

        public void ShowNotImplemented(string method)
            => VS.MessageBox.Show(Vsix.InternalName, $"'{method}' is not yet implemented"); //YD: add ShowNotImplemented to VS.Notifications.MessageBox

        public void ShowInformation(string message)
            => VS.MessageBox.Show(Vsix.InternalName, message); //YD: add ShowInformation to VS.Notifications.MessageBox

        public void ShowExclamation(string message)
            => VS.MessageBox.Show(Vsix.InternalName, message); //YD: add ShowExclamation to VS.Notifications.MessageBox

        public void ShowWarning(string message)
            => VS.MessageBox.ShowWarning(Vsix.InternalName, message); //YD: add ShowWarning to VS.Notifications.MessageBox

        public void ShowSuccess(string message)
            => VS.MessageBox.Show(Vsix.InternalName, message); //YD: add ShowSuccess to VS.Notifications.MessageBox

        public void ShowError(string message)
            => VS.MessageBox.ShowError(Vsix.InternalName, message);

        public void ShowException(Exception ex)
            => VS.MessageBox.ShowError(Vsix.InternalName, ex.ExtendedMessage()); //YD: add ShowException to VS.Notifications.MessageBox

        public bool ShowConfirm(string question)
            => VS.MessageBox.ShowConfirm(Vsix.InternalName, question);

        public bool Confirmed(string question)
            => ShowConfirm(question); //YD: add Confirmed to VS.Notifications.MessageBox
    }
}