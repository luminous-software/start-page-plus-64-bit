using System.Threading.Tasks;
using System;

namespace StartPagePlus.UI.Interfaces
{
    public interface IRunMethods
    {
        /// <summary>A method to safely run asynchronous code syncronously</summary>
        /// <remarks>Only use when the called code has an exception handler</remarks>
        /// <param name="asyncMethod">The asyncronous code to be run synchronously</param>
        /// <returns>A bool from the called code</returns>
        bool Run(Func<Task<bool>> asyncMethod);

        /// <summary>A method to safely run asynchronous code syncronously</summary>
        /// <remarks>Only use when the called code has an exception handler</remarks>
        /// <param name="asyncMethod">The asyncronous code to be run synchronously</param>
        /// <returns>A bool? from the called code</returns>
        bool? Run(Func<Task<bool?>> asyncMethod);
    }
}