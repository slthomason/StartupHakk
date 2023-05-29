class Program
{
    static void Main(string[] args)
    {
        var recordOne = new GenericRecord(10);
        var recordTwo = new GenericRecord(10);

        Console.WriteLine(recordOne == recordTwo); // true 
        Console.WriteLine(recordOne.Equals(recordTwo)); // true

    }
}

record GenericRecord(int Value);