// Classic
public enum PizzaType
    {
        MeatLovers,
        Vegetarian,
        PineappleLovers
    }

//Smart 
public sealed class Pizza : SmartEnum<Pizza>
{
    public static readonly Pizza Margherita = new Pizza(1, "Margherita", PizzaType.Vegetarian);
    public static readonly Pizza Pepperoni = new Pizza(2, "Pepperoni", PizzaType.MeatLovers);
    public static readonly Pizza Hawaiian = new Pizza(3, "Hawaiian", PizzaType.PineappleLovers);
    public static readonly Pizza MeatLovers = new Pizza(4, "Meat Lovers", PizzaType.MeatLovers);
    public static readonly Pizza VeggieLovers = new Pizza(5, "Veggie Lovers", PizzaType.Vegetarian);

    public int Id { get; }
    public string Name { get; }
    public PizzaType Type { get; }

    private Pizza(int id, string name, PizzaType type)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
    }
}