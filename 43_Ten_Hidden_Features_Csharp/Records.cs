public record Person(string FirstName, string LastName, int Age);

Person alice = new Person("Alice", "Smith", 30);
Person bob = new Person("Bob", "Jones", 40);
Console.WriteLine(alice.FirstName); // output: Alice
Console.WriteLine(alice == new Person("Alice", "Smith", 30)); // output: true

var person = new Person("John", "Doe", 25);
person.FirstName = "Jane"; // Error: Cannot modify an 'init-only' property

var updatedPerson = person with { FirstName = "Jane" };


