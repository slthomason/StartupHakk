using Microsoft.Extensions.Logging;

public class MyClass
{
    private readonly ILogger _logger;

    public MyClass(ILogger<MyClass> logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.LogInformation("Doing something...");
        // Perform the desired operation
        _logger.LogInformation("Something done.");
    }
}


using Microsoft.Extensions.Logging;

public class MyClass
{
    private readonly ILogger<MyClass> _logger;

    public MyClass(ILogger<MyClass> logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.LogInformation("Doing something...");
        // Perform the desired operation
        _logger.LogInformation("Something done.");
    }
}


using Microsoft.Extensions.Logging;

public class MyClass
{
    private readonly ILogger _logger;

    public MyClass(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<MyClass>();
    }

    public void DoSomething()
    {
        _logger.LogInformation("Doing something...");
        // Perform the desired operation
        _logger.LogInformation("Something done.");
    }
}


using Microsoft.Extensions.Logging;

public class MyLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        // Implement your custom logger creation logic here
        return new MyLogger();
    }

    public void Dispose()
    {
        // Implement disposal logic if required
    }
}

public class MyLogger : ILogger
{
    public void LogInformation(string message)
    {
        // Custom logging logic
        Console.WriteLine("[INFO] " + message);
    }

    // Implement other ILogger methods as needed
}

public class MyClass
{
    private readonly ILogger _logger;

    public MyClass(ILoggerProvider loggerProvider)
    {
        _logger = loggerProvider.CreateLogger("MyClass");
    }

    public void DoSomething()
    {
        _logger.LogInformation("Doing something...");
        // Perform the desired operation
        _logger.LogInformation("Something done.");
    }
}