using System.ComponentModel.DataAnnotations;

namespace _09_Razor_Page_EF_Core_P6.Models.SchollViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
