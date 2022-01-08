using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonASP.Data;
using SalonASP.Models;

namespace SalonASP.Pages.Programaris
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
            return Page();
        }

        [BindProperty]
        public Programari Programari { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientiID"] = new SelectList(_context.Set<Clienti>(), "ID");
                ViewData["AngjatiID"] = new SelectList(_context.Set<Angajati>(), "ID");
                ViewData["ServiciiID"] = new SelectList(_context.Set<Servicii>(), "ID");
                return Page();
            }

            _context.Programari.Add(Programari);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
