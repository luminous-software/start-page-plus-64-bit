using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;

namespace StartPagePlus.UI.Methods
{
    internal class RunMethods
    {
        public static bool RunMethod(Func<Task<bool>> asyncMethod)
        {
            var result = false;

            result = ThreadHelper.JoinableTaskFactory.Run(async () => await asyncMethod());

            return result;
        }

        public static bool? RunMethod(Func<Task<bool?>> asyncMethod)
        {
            bool? result = false;

            ThreadHelper.JoinableTaskFactory.Run(async () => result = await asyncMethod());

            return result;
        }
    }
}