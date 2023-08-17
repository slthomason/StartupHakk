class Program
{
    /// <summary>
    /// Utility to add Employee details.
    /// </summary>
    /// <param name="firstName">First name for Employee</param>
    /// <param name="lastName">Last name for Employee</param>
    /// <param name="dateOfBirth">Date of birth</param>
    /// <param name="address">Address array</param>
    /// <param name="employeeId">Employee Id</param>
    /// <param name="employeePhoto">Path to an image file</param>
    static void Main(string firstName,
                        string lastName,
                        DateTime dateOfBirth,
                        string[] address = null,
                        int employeeId = 42,
                        FileInfo employeePhoto = null)
    {
        Console.WriteLine($@"Employee details - 
                            Name : { firstName} { lastName}
                            DOB: { dateOfBirth }
                            Address: {string.Join(",", address
                                            ?? Array.Empty<string>())}
                            Id: { employeeId }
                            Photo: { employeePhoto } 
                        ");
    }
}