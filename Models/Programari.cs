using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonASP.Models
{
    public class Programari
    {
        public int ProgramariID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int ClientiID { get; set; }
        public Clienti Clienti { get; set; }
        public int AngajatiID { get; set; }
        public Angajati Angajati { get; set; }
        public int ServiciiID { get; set; }
        public Servicii Servicii { get; set; }
    }
}