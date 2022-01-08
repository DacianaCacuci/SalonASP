using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonASP.Data;
using SalonASP.Models;

namespace SalonASP.Pages.Serviciis
{
    public class EditModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public EditModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Servicii Servicii { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servicii = await _context.Servicii.FirstOrDefaultAsync(m => m.ServiciiID == id);

            if (Servicii == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Servicii).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciiExists(Servicii.ServiciiID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiciiExists(int id)
        {
            return _context.Servicii.Any(e => e.ServiciiID == id);
        }
    }
}
