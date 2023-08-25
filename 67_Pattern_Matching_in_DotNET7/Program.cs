object o = "Hello, world!";
if (o is string s)
{
    Console.WriteLine(s.ToUpper());  // Output: HELLO, WORLD!
}



//Type Pattern

public static void PrintDetails(object o)
{
    switch (o)
    {
        case int i:
            Console.WriteLine($"Integer: {i}");
            break;
        case string s:
            Console.WriteLine($"String: {s}");
            break;
        default:
            Console.WriteLine("Unknown type");
            break;
    }
}





//Positional Pattern

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

public static void PrintPointDetails(object o)
{
    if (o is Point(var x, var y))
    {
        Console.WriteLine($"Point at ({x}, {y})");
    }
}




//Property Pattern

public class Employee
{
    public string Department { get; set; }
    public int Salary { get; set; }
}

public static void PrintEmployeeDetails(Employee e)
{
    if (e is { Department: "Sales", Salary: var s })
    {
        Console.WriteLine($"Salesperson's Salary: {s}");
    }
}







//Tuple Pattern

public static string GetDirection((int dx, int dy) vector)
{
    return vector switch
    {
        (1, 0) => "East",
        (0, 1) => "North",
        (-1, 0) => "West",
        (0, -1) => "South",
        _ => "Unknown"
    };
}









//Pattern Matching in Clean Architecture

public string GetUserPermissions(User user)
{
    return user switch
    {
        Administrator _ => "Full access",
        Guest _ => "Limited access",
        RegisteredUser { Subscription: Premium } => "Premium access",
        RegisteredUser { Subscription: Basic } => "Basic access",
        _ => "Unknown user type"
    };
}