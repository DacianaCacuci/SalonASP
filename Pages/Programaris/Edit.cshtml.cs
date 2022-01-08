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

namespace SalonASP.Pages.Programaris
{
    public class EditModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public EditModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programari Programari { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programari = await _context.Programari.FirstOrDefaultAsync(m => m.ProgramariID == id);

            if (Programari == null)
            {
                return NotFound();
            }
            ViewData["ClientiID"] = new SelectList(_context.Set<Clienti>(), "ID");
            ViewData["AngajatiID"] = new SelectList(_context.Set<Angajati>(), "ID");
            ViewData["ServiciiID"] = new SelectList(_context.Set<Servicii>(), "ID");
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

            _context.Attach(Programari).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramariExists(Programari.ProgramariID))
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

        private bool ProgramariExists(int id)
        {
            return _context.Programari.Any(e => e.ProgramariID == id);
        }
    }
}
