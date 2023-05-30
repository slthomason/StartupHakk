public class TelephoneNumber
{
  public string Number { get; set; } // this is mutable

  public TelephoneNumber(string number)
  {
    Number = number;
  }
}

public class Employee
{
  public string FirstName { get; }

  public TelephoneNumber TelephoneNumber { get; }
  
  public Employee(string firstName, TelephoneNumber telephoneNumber)
  {
    FirstName = firstName;
    TelephoneNumbers = telephoneNumbers;
  }
}

var homeTelephoneNumber = new TelephoneNumber("123");
var spencer = new Employee("Spencer", homeTelephoneNumber);

// manipulative code
spencer.TelephoneNumber.Number = "555";