//Authentication

var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
var user = await userManager.FindAsync(model.UserName, model.Password);

if (user != null)
{
    var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
}

//Authorization
[Authorize(Roles = "Admin")]
public ActionResult Delete(int id)
{
    // Code to delete a record
}

//Cross-Site Scripting (XSS) Prevention
var encodedInput = AntiXssEncoder.HtmlEncode(input, false);

//Cross-Site Request Forgery (CSRF) Prevention

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult UpdateUser(UserModel model)
{
    // Code to update user information
}




//Input Validation

public class UserModel
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
}

//Logging and Monitoring

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Configure Serilog for logging
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    app.UseSerilogRequestLogging(); // Adds Serilog middleware for logging HTTP requests

    // ...
}

//SQL Injection Prevention

public async Task<UserModel> GetUserById(int id)
{
    using (var connection = new SqlConnection(_connectionString))
    {
        var query = "SELECT Id, FirstName, LastName, Email FROM Users WHERE Id = @Id";
        var parameters = new { Id = id };

        return await connection.QuerySingleOrDefaultAsync<UserModel>(query, parameters);
    }
}