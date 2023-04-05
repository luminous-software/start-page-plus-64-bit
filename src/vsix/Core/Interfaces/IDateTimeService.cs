using System;

namespace StartPagePlus.Core.Interfaces
{
    public interface IDateTimeService : IService
    {
        DateTime Today { get; }

        DateTime Now { get; }
    }
}