public class Employee
{
  public string FirstName { get; }

  public List<Employee> Manage { get; }

  public Employee(string firstName, List<Employee> manage = null)
  {
    FirstName = firstName;
    Manage = manage?.ToList() ?? new List<Employee>(); // to copy the items from "manage"
  }
}

var john = new Employee("John");
var doe = new Employee("Doe");
var spencer = new Employee("Spencer", new List<Employee> { john, doe });

// manipulative code
spencer.Manage.Add(new Employee("Jeremy"));