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
    public class IndexModel : PageModel
    {
        private readonly SalonASP.Data.SalonASPContext _context;

        public IndexModel(SalonASP.Data.SalonASPContext context)
        {
            _context = context;
        }

        public IList<Angajati> Angajati { get;set; }

        public async Task OnGetAsync()
        {
            Angajati = await _context.Angajati
            .Include(b=> b.Servicii)
            .ToListAsync();
        }
    }
}
