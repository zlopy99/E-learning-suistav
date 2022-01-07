using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class ZivotinjaUSklonistu
    {
        public int ZivotinjaUSklonistuId { get; set; }
        public string BrojMikrocipa { get; set; }
        public string ImeZivotinje { get; set; }
        public DateTime? DatumStenjenja { get; set; }
        public string AdresaPronalaska { get; set; }
        public string Opis { get; set; }
        public int? PasminaId { get; set; }
        public int SpolId { get; set; }
        public int? KastratId { get; set; }
        public int SklonisteId { get; set; }
        public int? UdomljavanjeId { get; set; }
        public string Slika { get; set; }
        public DateTime? DatumPronalaska { get; set; }

        public virtual Kastrat Kastrat { get; set; }
        public virtual Pasmina Pasmina { get; set; }
        public virtual Skloniste Skloniste { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual Udomljavanje Udomljavanje { get; set; }
    }
}
