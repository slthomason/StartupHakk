class User
{
    public string Name { get; set; } = string.Empty;
    public Address? Address { get; set; }
}

class Address
{
    public string Street { get; set; } = string.Empty;
}

User user = new User();

Address? address = user.Address;

if (address != null)
{
    Console.WriteLine($"Street: {address.Value.Street}");  // Outputs: Street: 
}

// Using the null-forgiving operator
Console.WriteLine($"Street: {user.Address!.Street}");  // Throws System.NullReferenceException