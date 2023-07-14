class Program
{
    static void Main(string[] args)
    {
        string myString = null;
        Console.WriteLine(myString.Length);  // Throws a NullReferenceException
    }
}











class Program
{
    static void Main(string[] args)
    {
        string myString = null;
        if (myString != null)
        {
            Console.WriteLine(myString.Length);
        }
    }
}