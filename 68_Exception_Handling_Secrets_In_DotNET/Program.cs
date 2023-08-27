
//1 — Use Specific Exception Types:
//Bad Example

try
{
    // Some code that may throw an exception
}
catch (Exception ex)
{
    // Catching the base Exception type
    Console.WriteLine("An error occurred: " + ex.Message);
}

//Improved Example
try
{
    // Some code that may throw a specific exception
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("File not found: " + ex.FileName);
}
catch (IOException ex)
{
    Console.WriteLine("Input/output error: " + ex.Message);
}




//2 — Catch Only What You Can Handle:
//Bad Example:

try
{
    // Some code that may throw an exception
}
catch (Exception ex)
{
    // Suppressing the exception without proper handling
    // This can lead to hidden bugs and make debugging difficult
}


//Improved Example:

try
{
    // Some code that may throw an exception
}
catch (SpecificException ex)
{
    // Handle the specific exception appropriately
    Console.WriteLine("An error occurred: " + ex.Message);
}   




//3 — Log Exceptions:
//Bad Example:

try
{
    // Some code that may throw an exception
}
catch (Exception ex)
{
    // No logging of the exception
    Console.WriteLine("An error occurred: " + ex.Message);
}


//Improved Example:

try
{
    // Some code that may throw an exception
}
catch (Exception ex)
{
    // Log the exception for diagnosis
    Logger.Log(ex);
    Console.WriteLine("An error occurred. Please contact support.");
}





//4 — Keep Catch Blocks Short:

//Bad Example:

try
{
    // Some code that may throw an exception
}
catch (Exception ex)
{
    // Complex logic within the catch block
    if (ex is SomeSpecificException)
    {
        // Handle specific case
    }
    else if (ex is AnotherSpecificException)
    {
        // Handle another case
    }
}


//Improved Example:

try
{
    // Some code that may throw an exception
}
catch (SomeSpecificException ex)
{
    // Handle specific case
}
catch (AnotherSpecificException ex)
{
    // Handle another case
}





//5 — Use Finally for Cleanup:

//Bad Example:

FileStream fileStream = null;
try
{
    fileStream = new FileStream("file.txt", FileMode.Open);
    // Some code that may throw an exception
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally
{
    // Cleanup code mixed with exception handling
    if (fileStream != null)
    {
        fileStream.Close();
    }
}


//Improved Example:

try
{
    using (FileStream fileStream = new FileStream("file.txt", FileMode.Open))
    {
        // Some code that may throw an exception
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}