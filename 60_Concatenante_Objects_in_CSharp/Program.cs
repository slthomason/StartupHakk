string greeting = "Hello, " + "World!";







var sb = new StringBuilder();
string greeting = sb.Append("Hello, ").Append("World!").ToString();

























public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: { Name }, Age: { Age }";
    }
}

var person1 = new Person() { Name = "Tom", Age = 32 };
var person2 = new Person() { Name = "Alice", Age = 28 };

var result = string.Join("; ", person1, person2);
Console.WriteLine(result); //Name: Tom, Age: 32; Name: Alice, Age: 28