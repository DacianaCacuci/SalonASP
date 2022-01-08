using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonASP.Data;
using SalonASP.Models;

namespace SalonASP.Pages.Clientis
{
    public class DetailsModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public DetailsModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        public Clienti Clienti { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clienti = await _context.Clienti.FirstOrDefaultAsync(m => m.ClientiID == id);

            if (Clienti == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
