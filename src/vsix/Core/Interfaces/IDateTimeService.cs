namespace Luminous.Code.Interfaces
{
    using System;

    public interface IDateTimeService
    {
        DateTime Today { get; }

        DateTime Now { get; }
    }
}