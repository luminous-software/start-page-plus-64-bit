using System;
using System.Threading.Tasks;

namespace StartPagePlus.Core
{
    using Interfaces;

    internal interface IAsyncMethodService : IService
    {
        void Run(Func<Task> asyncMethod);

        bool Run(Func<Task<bool>> asyncMethod);

        bool? Run(Func<Task<bool?>> asyncMethod);
    }
}