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

  public IReadOnlyCollection<TelephoneNumber> TelephoneNumbers { get; }
  
  public Employee(string firstName, TelephoneNumber[] telephoneNumbers = null)
  {
    FirstName = firstName;
    TelephoneNumbers = telephoneNumbers?.ToArray() ?? Array.Empty<TelephoneNumber>(); // to copy the items from "telephoneNumbers"
  }
}

var homeTelephoneNumber = new TelephoneNumber("123");
var mobileTelephoneNumber = new TelephoneNumber("456");
var officeTelephoneNumber = new TelephoneNumber("789");

var allTelephoneNumbers = 
  new TelephoneNumber[]
  {
    homeTelephoneNumber,
    mobileTelephoneNumber,
    officeTelephoneNumber
  };

var spencer = new Employee("Spencer", allTelephoneNumbers);

// manipulative code
spencer.TelephoneNumbers.ElementAt(0).Number = "555";