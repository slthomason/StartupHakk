public class Movie
{
    [Required]
    public string Title { get; set; }
    public string Plot { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool Seen { get; set; }
    public int Rating { get; set; }
}



public class Movie
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    public string Plot { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool Seen { get; set; }
    [Range(0, 5)]
    [Required]
    public int Rating { get; set; }
}


[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColorAttribute : Attribute
{
    public ColorAttribute(ConsoleColor color = ConsoleColor.White)
    {
        Color = color;
    }

    public ConsoleColor Color { get; }
}   


public class Movie
{
    [Color(ConsoleColor.Red)]
    public string Title { get; set; }
    [Color(ConsoleColor.Blue)]
    public string Description { get; set; }
    [Color(ConsoleColor.Green)]
    public int Rating { get; set; }
    
}

var movies = new List<Movie>
{
    new Movie{ Description = "Green fellow", Title = "Shrek", Rating = 5},
    new Movie{ Description = "Worst movie with Ryan Reynolds", Title = "Green Latern", Rating = 1},
    new Movie{ Description = "To hard to follow and I still don't get", Title = "Inception", Rating = 5},
    new Movie{ Description = "A movie that would even make Dwayne Johnson cry", Title = "Titanic", Rating = 5}
};

foreach (var item in movies)
{
    Console.WriteLine(item.Title);
    Console.WriteLine("A rating of " + item.Rating);
    Console.WriteLine(item.Description);
    Console.WriteLine(string.Empty);
}


ConsoleColor GetPropertyColor(string propertyName)
{
    PropertyInfo propertyInfo = typeof(Movie).GetProperty(propertyName);
    ColorAttribute colorAttribute = (ColorAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ColorAttribute));

    if (colorAttribute != null)
        return colorAttribute.Color;

    return defaultColor;
}