using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _09_Razor_Page_EF_Core_P3.Data;
using _09_Razor_Page_EF_Core_P3.Models;

namespace _09_Razor_Page_EF_Core_P3.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly _09_Razor_Page_EF_Core_P3.Data.SchoolContext _context;

        public DetailsModel(_09_Razor_Page_EF_Core_P3.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                                        .Include(s => s.Enrollments)
                                        .ThenInclude(e => e.Course)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
