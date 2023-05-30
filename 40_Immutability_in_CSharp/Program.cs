public class Employee
{
  public string FirstName { get; set; }

  public Employee(string firstName)
  {
    FirstName = firstName;
  }
}


var john = new Employee("John");


john.FirstName = "Doe";


public class Employee
{
  public string FirstName { get; }

  public Employee(string firstName)
  {
    FirstName = firstName;
  }
}