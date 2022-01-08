using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonASP.Models
{
    public class Angajati
    {
        public int AngajatiID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set;  }
        public string Email { get; set; }
        public int ServiciiID { get; set; }
        public Servicii Servicii { get; set;  }
        public ICollection<Programari> Programari { get; set; }

    }
}
