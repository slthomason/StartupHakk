public sealed class Pizza : SmartEnum<Pizza>
{
    public static readonly Pizza Margherita = new Pizza(1, "Margherita", 10m);
    public static readonly Pizza Pepperoni = new Pizza(2, "Pepperoni", 12m);
    public static readonly Pizza Hawaiian = new Pizza(3, "Hawaiian", 15m);

    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    private Pizza(int id, string name, decimal price)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
    }

    public void PrintDescription()
    {
        Console.WriteLine($"{this.Name} pizza is {this.Price:C}.");
    }
}