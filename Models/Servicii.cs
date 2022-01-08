using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonASP.Models
{
    public class Servicii
    {
        public int ServiciiID { get; set; }
        public string Denumire { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public string Timp_Executie { get; set; }
        public ICollection<Programari> Programari { get; set; }
        public ICollection<Angajati> Angajati {  get; set; }
    }
}
