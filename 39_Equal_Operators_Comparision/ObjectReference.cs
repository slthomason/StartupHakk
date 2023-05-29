static void Main(string[] args)
{
  var instanceOne = new GenericClass(10);
  var instanceTwo = new GenericClass(10);
  Console.WriteLine(instanceOne == instanceTwo); // true 
  Console.WriteLine(instanceOne.Equals(instanceTwo)); // true
  Console.WriteLine(object.ReferenceEquals(instanceOne, instanceTwo)); // false
}

class GenericClass
{
    public int Value { get; }
    public GenericClass(int value) => Value = value;

    public static bool operator ==(GenericClass a, GenericClass b) => a.Value == b.Value;
    public static bool operator !=(GenericClass a, GenericClass b) => !(a == b);

    public override bool Equals(object obj)
    {
        if (obj is GenericClass instance)
        {
            return instance.Value == Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}