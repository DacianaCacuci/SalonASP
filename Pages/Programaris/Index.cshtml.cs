using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonASP.Data;
using SalonASP.Models;

namespace SalonASP.Pages.Programaris
{
    public class IndexModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public IndexModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        public IList<Programari> Programari { get;set; }

        public async Task OnGetAsync()
        {
            Programari = await _context.Programari
                .Include(b => b.Clienti)
                .Include(b => b.Angajati)
                .Include(b => b.Servicii)
                .ToListAsync();
        }
    }
}
