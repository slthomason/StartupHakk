interface ITask
{
    void Execute();
}

class NetFramework48 : ITask
{
    ...
}

class Net6 : ITask
{
    ...
}


public class HttpContextAccessor : IHttpContextAccessor
{
    public HttpContext HttpContext 
    { 
        get => HttpContext.Current;
        set => throw new NotSupportedException("This is only for migration purposes");
    }
}


public class MyService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public MyService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void DoSomething()
    {
        var context = _httpContextAccessor.HttpContext;
        // do something with the context
    }
}


public class MyMiddleware
{
    private readonly RequestDelegate _next;
    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        // Begin_Request
        await _next(context);
        // End_Request
    }
}