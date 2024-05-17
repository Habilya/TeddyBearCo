namespace TeddyBearCo.Api.Providers;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTime DateTimeNow => DateTime.Now;
}
