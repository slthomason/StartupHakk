public class Email
{
  public Email(string emailAddress) 
    {
        if (!IsValid(emailAddress))
        {
           throw new ArgumentException("Email address is invalid.");
        }
    
        EmailAddress = emailAddress;
    }
    public string EmailAddress { get; private set; }
    private bool IsValid(string emailAddress)
    {
        var match = Regex.Match(
            emailAddress,
            "^\\S+@\\S+$",
            RegexOptions.IgnoreCase);
        return match.Success;
    }
}

public interface IJsonFileParser
{
    // bool Exists(string filePath);
    // Stream GetFileStream(string filePath);
    // T Parse<T>(Stream stream);
    // Dispose(Stream stream);

    T Parse<T>(string filePath); 

}