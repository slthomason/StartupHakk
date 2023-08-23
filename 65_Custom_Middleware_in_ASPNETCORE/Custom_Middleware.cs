var builder = WebApplication.CreateBuilder(args);

// Services here ...

var app = builder.Build();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    // Some context manipulation code here...

    // Call the next delegate/middleware in the pipeline.
    await next(context);
}); 

app.Run();