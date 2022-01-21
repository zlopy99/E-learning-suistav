using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class IzgubljeneViewModel
    {
        public int IzgubljeneZivotinjeId { get; set; }
        public string BrojMikrocipa { get; set; }
       // [Display(Name = "Ime ljubimca")]
        public string Ime { get; set; }
        public string Pasmina { get; set; }
      //  [Display(Name = "Vrsta životinje")]
        public string VrstaZivotinje { get; set; }
        public string Spol { get; set; }
        public string Kastrat { get; set; } 
        public string Slika { get; set; }
        //[Display(Name = "Lokacija/adresa nestanka vašeg ljubimca")]
        public string LokacijaNestanka { get; set; }
       // [Display(Name = "Mjesto nestanka vašeg ljubimca")]
        public string Grad { get; set; }
        public DateTime? DatumNestanka { get; set; }
        public DateTime? DatumPrijave { get; set; }
        public string Kontakt { get; set; }

    }
}
