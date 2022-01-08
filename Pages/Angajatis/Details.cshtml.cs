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
    public class DetailsModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public DetailsModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

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
    }
}
