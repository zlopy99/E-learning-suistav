using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class ZivotinjeViewModel
    {
        public int ZivotinjaUSklonistuId { get; set; }
        public string BrojMikrocipa { get; set; }
        public string ImeZivotinje { get; set; }
        public string NazivPasmine { get; set; }
        public string NazivVrste { get; set; }
        public string NazivSpola { get; set; }
        public DateTime? DatumStenjenja { get; set; }
        public string Slika { get; set; }
        public string JeLiZaUdomljavanje { get; set; }
        public string AdresaPronalaska { get; set; }
        public DateTime? DatumPronalaska { get; set; }
        public string NazivSklonista { get; set; }
        public string Adresa { get; set; }
        public string NazivGrada { get; set; }
        public string NazivZupanije { get; set; }


    }
}
