var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
var app = builder.Build();
app.MapHealthChecks("/health");
app.Run();



public class SqlServerHealthCheck : IHealthCheck 
{ 
    private readonly string _connectionString; 
    public SqlServerHealthCheck(IConfiguration configuration) { 
    _connectionString = configuration.GetConnectionString("DefaultConnection"); 
    } 
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
     CancellationToken cancellationToken = default) 
    { 
        using var connection = new SqlConnection(_connectionString); 
        try { 
            await connection.OpenAsync(cancellationToken); 
            return HealthCheckResult.Healthy(); 
        }      
        catch (Exception) { 
            return HealthCheckResult.Unhealthy(); 

        } 
    } 
} 







builder.Services.AddHealthChecks().AddCheck<SqlServerHealthCheck>("SqlServer");



























builder.Services.AddHealthChecks() 
.AddNpgSql(Configuration["ConnectionString:PostgreSQL"]) 
.AddRabbitMQ(Configuration["ConnectionString:RabbitMQ"]); 

