
//Example 1
class User
{
    public string Name { get; set; }
    public int? Age { get; set; }
}

User user = new User { Name = "John Doe" };

string name = user.Name ?? "Unknown";
int age = user.Age ?? 0;

Console.WriteLine($"Name: {name}, Age: {age}");  // Outputs: Name: John Doe, Age: 0


//Example 2

List<int> numbers = null;
//...

foreach (var number in numbers ?? Enumerable.Empty<int>())
{
    // Your logic here
}