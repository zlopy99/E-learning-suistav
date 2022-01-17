using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class IzgubljeneViewModel
    {
        public int IzgubljeneZivotinjeId { get; set; }
        public string BrojMikrocipa { get; set; }
        public string Ime { get; set; }
        public string Pasmina { get; set; }
        public string VrstaZivotinje { get; set; }
        public string Spol { get; set; }
        public string Kastrat { get; set; } 
        public string Slika { get; set; }
        public string LokacijaNestanka { get; set; }
        public string Grad { get; set; }
        public DateTime? DatumNestanka { get; set; }
        public DateTime? DatumPrijave { get; set; }
        public string Kontakt { get; set; }

    }
}
