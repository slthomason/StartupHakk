public class DateTimeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDateTimeService _dateTimeService;

    public DateTimeMiddleware(
      RequestDelegate next, 
      IDateTimeService dateTimeService)
    {
        _next = next;
        _dateTimeService = dateTimeService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Add
        (
            "X-DateTime", 
            _dateTimeService.GetCurrentDateTime().ToString()
        );
        await _next(context);
    }
}