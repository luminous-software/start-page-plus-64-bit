using System;

namespace StartPagePlus.Core.Interfaces
{
    public interface IDateTimeService : ISimpleService
    {
        DateTime Today { get; }

        DateTime Now { get; }
    }
}