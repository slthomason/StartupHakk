using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _09_Razor_Page_EF_Core_P7.Data;
using _09_Razor_Page_EF_Core_P7.Models;
using _09_Razor_Page_EF_Core_P7.Models.SchollViewModels;

namespace _09_Razor_Page_EF_Core_P7.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly _09_Razor_Page_EF_Core_P7.Data.SchoolContext _context;

        public IndexModel(_09_Razor_Page_EF_Core_P7.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                CourseVM = await _context.Courses
    .Select(p => new CourseViewModel
    {
        CourseID = p.CourseID,
        Title = p.Title,
        Credits = p.Credits,
        DepartmentName = p.Department.Name
    }).ToListAsync();
            }
        }
    }
}
