// Create a minimal API WebApplication instance
var app = WebApplication.Create();

// Function to generate or retrieve a file path for the uploaded file
string GetOrCreateFilePath(string fileName, string filesDirectory = "uploadFiles")
{
    var directoryPath = Path.Combine(app.Environment.ContentRootPath, filesDirectory);
    Directory.CreateDirectory(directoryPath);
    return Path.Combine(directoryPath, fileName);
}
// Function to upload the file with the specified name
async Task UploadFileWithName(IFormFile file, string fileSaveName)
{
    var filePath = GetOrCreateFilePath(fileSaveName);
    await using var fileStream = new FileStream(filePath, FileMode.Create);
    await file.CopyToAsync(fileStream);
}
// Use the MapPost method to define a POST route that accepts an IFormFile parameter without needing the FromForm attribute
app.MapPost("/upload", async (IFormFile file) => {
    var fileSaveName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
    await UploadFileWithName(file, fileSaveName);
    return TypedResults.Ok("File uploaded successfully!");
});
// Start and run the WebApplication
app.Run();



// The .http file simplifies testing your app's endpoints using the new Visual Studio HTTP editor
// Define your API host address to avoid hardcoding it in each request
@MyApi_HostAddress = http://localhost:5233

// Test a GET request to fetch all todos by using the defined API host address
GET {{MyApi_HostAddress}}/todos/
Accept: application/json
// Use the three hash (#) symbols to separate different request examples
// Test another GET request to fetch a specific todo item (e.g., with id 1)
GET {{MyApi_HostAddress}}/todos/1
Accept: application/json
// Add more request examples with different HTTP methods and endpoints as needed    



//<EnableRequestDelegateGenerator>true</EnableRequestDelegateGenerator>
// Create a minimal API WebApplication instance
var app = WebApplication.Create();

// Define an API endpoint activated by enabling the Request Delegate Generator (RDG)
// Automatic logging and exception handling are provided by RDG, simplifying development
app.MapGet("/hello/{name}", (string name)
    => $"Hello {name}!");
// Define another API endpoint that calculates age based on the input birthdate
app.MapGet("/age", (DateTime birthDate)
    => $"You're about {DateTime.Now.Year - birthDate.Year} years old!");
// Start and run the WebApplication
app.Run();


// Send a request without providing the required 'name' parameter in the /hello endpoint
// The following cURL command will cause a BadHttpRequestException, as the parameter is not specified:
curl "http://localhost:5056/hello"

// The exception message will look like this:
/*
Microsoft.AspNetCore.Http.BadHttpRequestException: Required parameter "string name" was not provided from route or query string.
   ....
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)
*/


// Send a request with an unparsable 'birthDate' parameter in the /age endpoint
// The following cURL command will cause a BadHttpRequestException due to the 'invalidDate' value:
curl "http://localhost:5056/age?birthDate=invalidDate"

// The exception message will look like this:
/*
Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to bind parameter "DateTime birthDate" from "invalidDate".
   ...
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)
*/