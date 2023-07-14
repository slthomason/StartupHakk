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

string name = user.Name;  // No compiler warning
Address address = user.Address!;  // Requires explicit non-null check

Console.WriteLine($"Name: {name}, Street: {address.Street}");  // Outputs: Name: , Street: