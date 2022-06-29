using System.ComponentModel.DataAnnotations;

namespace _09_Razor_Page_EF_Core_P4.Models.SchollViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
