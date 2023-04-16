﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Methods
{
    internal sealed class RunMethods
    {
        [SuppressMessage("Usage", "VSTHRD102:Implement internal logic asynchronously", Justification = "Required")]
        public static bool RunMethod(Func<Task<bool>> asyncMethod)
        {
            var result = false;

            try
            {
                result = ThreadHelper.JoinableTaskFactory.Run(async () => await asyncMethod());

            }
            catch (Exception) // ex)
            {
                //YD: can ServiceManager.DialogService.ShowException be added back?
                //ServiceManager.DialogService.ShowException(ex); // get only if required, not ahead of time
                result = false;
            }

            return result;
        }

        [SuppressMessage("Usage", "VSTHRD102:Implement internal logic asynchronously", Justification = "Required")]
        public static bool? RunMethod(Func<Task<bool?>> asyncMethod)
        {
            bool? result = false;

            try
            {
                result = ThreadHelper.JoinableTaskFactory.Run(async () => result = await asyncMethod());
            }
            catch (Exception) // ex) 
            {
                //YD: can ServiceManager.DialogService.ShowException be added back?
                //ServiceManager.DialogService.ShowException(ex); // get only if required, not aahead of time
                result = false;
            }

            return result;
        }
    }
}