using System.Text.Json;

string fileWithJson = "movies.json";

using (StreamReader reader = new(fileWithJson))
{
    string jsonContent = reader.ReadToEnd();

    List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(jsonContent);

    foreach (Movie movie in movies)
    {
        Console.WriteLine($"The movie {movie.Title} has a rating of {movie.Rating}");
    }
}

class Movie
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double Rating { get; set; }
}