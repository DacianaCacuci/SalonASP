using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonASP.Data;
using SalonASP.Models;

namespace SalonASP.Pages.Angajatis
{
    public class CreateModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public CreateModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ServiciiID"] = new SelectList(_context.Set<Servicii>(), "ServiciiID");
            return Page();
        }

        [BindProperty]
        public Angajati Angajati { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Angajati.Add(Angajati);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
