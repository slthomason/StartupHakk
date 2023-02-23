
//Not Encapsulated
public class Email
{
   public string EmailAddress { get; set; }
}

//Setter is private
public class Email
{
    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }
    public string EmailAddress { get; private set; }
}
