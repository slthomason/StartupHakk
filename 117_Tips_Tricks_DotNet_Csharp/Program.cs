public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Stock { get; set; }
    public Status Status { get; set; }
    public bool Available { get; set; }
}

public enum Status
{
    Ordered,
    Delivered
}

List<Product> products = new()
{
    new() { Id = 1, Title = "7Up", Status = Status.Ordered, Stock = 10, Available = true },
    new() { Id = 2, Title = "Chips", Status = Status.Ordered, Stock = 0, Available = true },
    new() { Id = 3, Title = "Sugar", Status = Status.Delivered, Stock = 67, Available = true },
    new() { Id = 4, Title = "Meatballs", Status = Status.Delivered, Stock = 2, Available = true },
};


//Merge If Statements

if (chips.Stock == 0)
{
    if (chips.Status == Status.Ordered)
    {
        chips.Available = false;
    }
}

if(chips is { Stock: 0, Status: Status.Ordered })
{
    chips.Available = false;
}

// Pattern Matching

object? something = products[0];
if(something != null && something.GetType() == typeof(Product))
{
    Product product = (Product)something;

    Console.WriteLine($"The type you are looking at is a {product.GetType()} and has the title {product.Title}");
}


object? something = products[0];
if(something != null && something is Product)
{
    Productproduct = (Product)something;

    Console.WriteLine($"The type you are looking at is a {product.GetType()} and has the title {product.Title}");
}

if(something is Product product)
{
    Console.WriteLine($"The type you are looking at is a {product.GetType()} and has the title {product.Title}");
}

//The Null-Coalescing Assignment Operator

Product apple = null;
Console.WriteLine(apple.Title);


Product apple = null;

if (apple == null)
    apple = new() { Title = "Green apple" };

Console.WriteLine(apple.Title);


Product apple = null;
apple ??= new() { Title = "Green apple" };

Console.WriteLine(apple.Title);


//Expression-Body Constructors

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Stock { get; set; }
    public Status Status { get; set; }
    public bool Available { get; set; }

    public Product(string title, int stock, Status status)
    {
        Title = title;
        Stock = stock;
        Status = status;
    }
}

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Stock { get; set; }
    public Status Status { get; set; }
    public bool Available { get; set; }

    public Product(string title, int stock, Status status) => (Title, Stock, Status) = (title, stock, status);
}


public class Product(string title, int stock, Status status)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public int Stock { get; set; } = stock;
    public Status Status { get; set; } = status;
    public bool Available { get; set; }
}

// DebuggerDisplayAttribute

Product apple = null;
apple ??= new() { Title = "Green apple" };

Console.WriteLine(apple.Title);


[DebuggerDisplay("This is a {Title}, with a stock of {Stock}")]
public class Product(string title, int stock, Status status)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public int Stock { get; set; } = stock;
    public Status Status { get; set; } = status;
    public bool Available { get; set; }
}