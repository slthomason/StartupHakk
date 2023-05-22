//Classic Enum
public enum Gender
{
    Male,
    Female,
    Unknown
}

//Smart Enum
public class Gender : SmartEnum<Gender, string>
{
    public static readonly Gender Male = new Gender("M", "Male");
    public static readonly Gender Female = new Gender("F", "Female");
    public static readonly Gender Unknown = new Gender("U", "Unknown");

    private Gender(string value, string name)
        : base(value, name)
    {
    }
}