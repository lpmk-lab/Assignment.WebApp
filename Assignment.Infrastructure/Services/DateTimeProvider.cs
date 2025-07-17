using Assignment.Application.Common.Interface.Services;


namespace Assignment.Infrastructure.Services
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.Now;
    }
}

