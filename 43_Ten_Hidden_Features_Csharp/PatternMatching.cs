object myObject = "Hello, world!";
if (myObject is string myString)
{
    Console.WriteLine($"The length of the string is {myString.Length}");
}
else
{
    Console.WriteLine("The object is not a string");
}

if (myObject is int myInt && myInt > 0)
{
    Console.WriteLine("The integer is positive");
}
else if (myObject is int myInt && myInt < 0)
{
    Console.WriteLine("The integer is negative");
}
else
{
    Console.WriteLine("The object is not an integer");
}