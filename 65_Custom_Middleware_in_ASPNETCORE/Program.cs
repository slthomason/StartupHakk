var builder = WebApplication.CreateBuilder(args);

// Services here ...

// Register the service
builder.Services.AddSingleton<IDateTimeService, DateTimeService>();

var app = builder.Build();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Https Redirection middleware
app.UseHttpsRedirection();

// Add the middleware component to the pipeline
app.UseMiddleware<DateTimeMiddleware>();


// Add the middleware component to the pipeline
app.UseMiddleware<LoggingMiddleware>();


// Static Files middleware
app.UseStaticFiles();

// Cookie Policy middleware
app.UseCookiePolicy();

// Use session middleware
app.UseSession();

// Use response caching middleware
app.UseResponseCaching();

// Use compression middleware
app.UseResponseCompression();

app.UseRouting();

// Use CORS middleware
app.UseCors("AllowAll");

// Use authentication middleware
app.UseAuthentication();

// Use authorization middleware
app.UseAuthorization();

// End Points middleware
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});