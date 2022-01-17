using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class IzgubljeneMiniViewModel
    {
        public int IzgubljeneZivotinjeId { get; set; }
        public string VrstaZivotinje { get; set; }
        public string Pasmina { get; set; }
        public string Spol { get; set; }
        public string Kontakt { get; set; }
        public string LokacijaNestanka { get; set; }
        public string Grad { get; set; }
        public DateTime? DatumNestanka { get; set; }
        public DateTime? DatumPrijave { get; set; }
        
    }
}
