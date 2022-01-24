namespace StartPagePlus.Extensions.Exceptions
{
    using System;

    public static class ExceptionExtensions
    {
        public static string ExtendedMessage(this Exception instance)
        {
            if (instance == null)
                return "";

            var innerException = instance.InnerException;

            return (innerException == null)
                ? instance.Message
                : innerException.ExtendedMessage();
        }
    }
}