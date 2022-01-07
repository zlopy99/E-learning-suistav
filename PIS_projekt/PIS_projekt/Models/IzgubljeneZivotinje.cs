using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class IzgubljeneZivotinje
    {
        public int IzgubljeneZivotinjeId { get; set; }
        public string BrojMikrocipa { get; set; }
        public string Ime { get; set; }
        public int? SpolId { get; set; }
        public string Kontakt { get; set; }
        public string LokacijaNestanka { get; set; }
        public int? GradId { get; set; }
        public DateTime? DatumNestanka { get; set; }
        public DateTime? DatumPrijave { get; set; }
        public string Slika { get; set; }
        public int? PasminaId { get; set; }
        public int? VrstaZivotinjeId { get; set; }
        public int? KastratId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Kastrat Kastrat { get; set; }
        public virtual Pasmina Pasmina { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual VrstaZivotinje VrstaZivotinje { get; set; }
    }
}
