// Classic
public enum UserRole
{
    Admin,
    Manager,
    Employee
}

//Smart 
public class UserRole : SmartEnum<UserRole, int>
{
    public static readonly UserRole Admin = new UserRole(1, "Admin");
    public static readonly UserRole Manager = new UserRole(2, "Manager");
    public static readonly UserRole Employee = new UserRole(3, "Employee");

    private UserRole(int value, string name)
        : base(value, name)
    {
    }
}