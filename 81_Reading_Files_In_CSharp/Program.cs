//Get It All

using (StreamReader reader = new("YourFileHere.txt"))
{
    Console.WriteLine(reader.ReadToEnd());
}

//Line By Line

using (StreamReader reader = new("YourFileHere.klc"))
{
    string line;

    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}



