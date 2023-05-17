public class Student(int id, string name, IEnumerable<decimal> grades)
{
    public Student(int id, string name) : this(id, name, Enumerable.Empty<decimal>()) { }
    public int Id => id;
    public string Name { get; set; } = name.Trim();
    public decimal GPA => grades.Any() ? grades.Average() : 4.0m;
}