 class Program
{
    static void Main(string[] args)
    {
        var instanceOne = new GenericClass(10);
        var instanceTwo = new GenericClass(10);
        Console.WriteLine(instanceOne == instanceTwo); // false 
    }

}
class GenericClass
{
    public int Value { get; }
    public GenericClass(int value) => Value = value;
}