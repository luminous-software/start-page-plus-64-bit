namespace StartPagePlus.UI.Services
{
    using System;

    using Luminous.Code.Interfaces;

    public class DateTimeService : IDateTimeService
    {
        public DateTime Today
            => DateTime.Today.Date;

        public DateTime Now
            => DateTime.UtcNow;
    }
}