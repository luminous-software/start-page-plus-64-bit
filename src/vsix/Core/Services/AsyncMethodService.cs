using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.Core.Services
{
    using Interfaces;

    /// <summary>
    /// A service to ensure that when async code needs to be run synchronously, that it will all use the same methodology
    /// (if the methodology  needs to be changed, it only needs to be changed in one place)
    /// </summary>
    internal sealed class AsyncMethodService : IAsyncMethodService
    {
        private readonly IDialogService _dialogService;

        public AsyncMethodService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        //--- methods

        [SuppressMessage("Usage", "VSTHRD102:Implement internal logic asynchronously", Justification = "Required")]
        public void Run(Func<Task> asyncMethod)
        {
            try
            {
                ThreadHelper.JoinableTaskFactory.Run(async () => await asyncMethod());

            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);
            }
        }

        [SuppressMessage("Usage", "VSTHRD102:Implement internal logic asynchronously", Justification = "Required")]
        public bool Run(Func<Task<bool>> asyncMethod)
        {
            var result = false;

            try
            {
                result = ThreadHelper.JoinableTaskFactory.Run(async () => await asyncMethod());

            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);

                result = false;
            }

            return result;
        }

        [SuppressMessage("Usage", "VSTHRD102:Implement internal logic asynchronously", Justification = "Required")]
        public bool? Run(Func<Task<bool?>> asyncMethod)
        {
            bool? result = false;

            try
            {
                result = ThreadHelper.JoinableTaskFactory.Run(async () => result = await asyncMethod());
            }
            catch (Exception ex)
            {
                _dialogService.ShowException(ex);

                result = false;
            }

            return result;
        }
    }
}