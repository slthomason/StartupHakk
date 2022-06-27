namespace _09_Razor_Page_EF_Core_P3.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Secret { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
       
    }
}
