public static class PersonExtensions
{
    public static void GenerateRandomName(this Person person, Func<Person> action)
    {
        var randomPerson = action();
        person.FirstName = randomPerson.FirstName;
        person.LastName = randomPerson.LastName;
    }
    public static void Mutate(this Person person, Func<string, string> action)
    {
        person.FirstName = action(person.FirstName);
        person.LastName = action(person.LastName);
    }
}