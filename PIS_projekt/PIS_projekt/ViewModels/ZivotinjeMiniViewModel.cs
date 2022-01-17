using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class ZivotinjeMiniViewModel
    {
        public int ZivotinjaUSklonistuId { get; set; }
        public int SklonisteId { get; set; }
        public string BrojMikrocipa { get; set; }
        public string ImeZivotinje { get; set; }
        public string NazivPasmine { get; set; }
        public string NazivVrste { get; set; }
        public string NazivSpola { get; set; }
        public string JeLiZaUdomljavanje { get; set; }
        public string NazivSklonista { get; set; }
        public string NazivGrada { get; set; }
    }
}
