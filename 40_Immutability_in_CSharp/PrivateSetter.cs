public class Employee
{
  public string FirstName { get; private set; }

  public Employee(string firstName)
  {
    FirstName = firstName;
  }
}