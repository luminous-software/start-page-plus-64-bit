namespace StartPagePlus.Core.Interfaces
{
    using System;

    public interface IDialogService
    {
        void ShowNotImplemented(string method);

        void ShowInformation(string message);

        void ShowExclamation(string message);

        void ShowWarning(string error);

        void ShowError(string error);

        void ShowException(Exception error);

        void ShowSuccess(string message);

        bool ShowConfirm(string question);

        bool Confirmed(string question);
    }
}