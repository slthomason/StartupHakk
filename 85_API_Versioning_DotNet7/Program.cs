builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = true;

    //URL Path Versioning
    o.ApiVersionReader = new UrlSegmentApiVersionReader();
    //Query String Versioning
    o.ApiVersionReader = new QueryStringApiVersionReader();
    //Header Versioning
    o.ApiVersionReader = new HeaderApiVersionReader("api-version");
    //Media Type Versioning
    o.ApiVersionReader = new MediaTypeApiVersionReader();
});


[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/weather")]
public class UsersController : Controller
{
    [HttpGet, MapToApiVersion("1.0")]
    public IActionResult GetUsersV1()
    {
        // Your code for version 1 goes here
       return View();
    }

    [HttpGet, MapToApiVersion("2.0")]
    public IActionResult GetUsersV2()
    {
        return View();
        // Your code for version 2 goes here
    }
}

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/users")]
public class UsersController : Controller
{
    [HttpGet, MapToApiVersion("1.0")]
    public IActionResult GetUsersV1()
    {
        // Your code for version 1 goes here
       return View();
    }

    [HttpGet, MapToApiVersion("2.0")]
    public IActionResult GetUsersV2()
    {
        return View();
        // Your code for version 2 goes here
    }
}