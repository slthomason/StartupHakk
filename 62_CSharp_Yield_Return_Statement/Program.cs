var engineers = GetSoftwareEngineers();

public IEnumerable<SoftwareEngineer> GetSoftwareEngineers()
{
    var result = new List<SoftwareEngineer>();
    for(var i = 0; i < 10; i++)
    {
        result.Add(new SoftwareEngineer
        { 
            Id = i 
        });
    }
    return result;
}



var engineers = GetSoftwareEngineers();
public IEnumerable<SoftwareEngineer› GetSoftwareEngineers()
{
    for(var i = 0; i < 10; i++)
    {
        yield return new SoftwareEngineer 
        {
            Id = i
        };
    }
}



Console.WriteLine(string.Join(",",TakeWhilePositive(new[] { 1, 2, -3, 4 })));
// Output: 1, 2
public IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
{
    foreach(int num in numbers)
    {
        if (num > 0)
        {
            yield return num;
        }
        else
        {
            yield break;
        }
    }
}




public async Task<IEnumerable<User>> GetUsersAsync()
{
    var users = await GetUsersFromDbAsync();
    foreach(var user in users)
    {
        user.ProfileImage = await GetProfileImageAsync(user.Id);
        return users;
    }

}
// And you would call the method like this.
var users = await GetUsersAsync();
foreach(var user in users)
{
    Console.WriteLine(user);
}


public async IAsyncEnumerable<User> GetUsersAsync()
{
    var users = await GetUsersFromDbAsync();
    foreach(var user in users)
    {
        user.ProfileImage = await GetProfileImageAsync(user.Id);
        yield return user;
    }
}
// And you would call the method like this. 
await foreach(var user in GetUsersAsync())
{
    Console.WriteLine(user);
}
















public class Address
{
    public string City { get; init; }
    public string Street { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return Zip;
        yield return Country;
    }
}

