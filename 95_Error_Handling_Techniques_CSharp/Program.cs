//Always keep trace of the exception stack
//Bad Way
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    logger.LogInfo(ex);
    throw ex;
}

//Good Way
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw;
}

//Avoiding the use of “throw ex”
//Bad Way
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw ex;
}

//Good Way
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw;
}

//Avoid using if conditions
//Bad Way
try
{
    // Do something..
}
catch (Exception ex)
{
    if (ex is TaskSchedulerException)
    {
        // Take action
    }
    else if (ex is TaskCanceledException)
    {
        // Take action
    }
}

//Good Way
try
{
    // Do something..
}
catch (TaskCanceledException ex)
{
    // Take action 
}
catch (TaskSchedulerException ex)
{
    // Take action
}

//Always analyze the caught errors
//Bad Way
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    // silent exception
}

//Good Way
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    NotifyUserOfError(error);
    // Another option
    ReportErrorToService(error);
}