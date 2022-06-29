using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _09_Razor_Page_EF_Core_P4.Data;
using _09_Razor_Page_EF_Core_P4.Models;
using _09_Razor_Page_EF_Core_P4.ViewModels;

namespace _09_Razor_Page_EF_Core_P4.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly _09_Razor_Page_EF_Core_P4.Data.SchoolContext _context;

        public CreateModel(_09_Razor_Page_EF_Core_P4.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentVM StudentVM { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                var entry = _context.Add(emptyStudent);
                entry.CurrentValues.SetValues(StudentVM);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
