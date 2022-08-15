using Distillery.Application.Common.Interfaces;

namespace Distillery.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
