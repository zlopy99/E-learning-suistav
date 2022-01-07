using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Pasmina
    {
        public Pasmina()
        {
            IzgubljeneZivotinjes = new HashSet<IzgubljeneZivotinje>();
            ZivotinjaUSklonistus = new HashSet<ZivotinjaUSklonistu>();
        }

        public int PasminaId { get; set; }
        public string NazivPasmine { get; set; }
        public int? VrstaZivotinjeId { get; set; }

        public virtual VrstaZivotinje VrstaZivotinje { get; set; }
        public virtual ICollection<IzgubljeneZivotinje> IzgubljeneZivotinjes { get; set; }
        public virtual ICollection<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
    }
}
