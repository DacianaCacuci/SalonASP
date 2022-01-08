using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonASP.Data;
using SalonASP.Models;

namespace SalonASP.Pages.Angajatis
{
    public class DeleteModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public DeleteModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajati Angajati { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Angajati = await _context.Angajati.FirstOrDefaultAsync(m => m.AngajatiID == id);

            if (Angajati == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Angajati = await _context.Angajati.FindAsync(id);

            if (Angajati != null)
            {
                _context.Angajati.Remove(Angajati);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
