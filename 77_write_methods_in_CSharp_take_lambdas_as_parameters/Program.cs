public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if(env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

public class Program
{
    private static void Main(string[] args)
    {
        var randomPerson = new Person();
        randomPerson.GenerateRandomName(() =>
        {
            return new Person()
            {
                FirstName = Name.First(),
                LastName = Name.Last()
            };
        });
        Console.WriteLine($"{randomPerson.FirstName} {randomPerson.LastName}"); // Output: Rico Wiegand
        randomPerson.Mutate(x => x.ToUpper());
        Console.WriteLine($"{randomPerson.FirstName} {randomPerson.LastName}"); // Output: RICO WIEGAND
    }
}