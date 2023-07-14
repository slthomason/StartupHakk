class User
{
    public string Name { get; set; }
    public Address Address { get; set; }
}

class Address
{
    public string Street { get; set; }
}

User user = new User { Name = "John Doe" };

string street = user?.Address?.Street;

Console.WriteLine(street ?? "Unknown");  // Outputs: Unknown