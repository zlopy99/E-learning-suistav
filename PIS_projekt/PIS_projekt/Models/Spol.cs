using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Spol
    {
        public Spol()
        {
            IzgubljeneZivotinjes = new HashSet<IzgubljeneZivotinje>();
            ZivotinjaUSklonistus = new HashSet<ZivotinjaUSklonistu>();
        }

        public int SpolId { get; set; }
        public string NazivSpola { get; set; }

        public virtual ICollection<IzgubljeneZivotinje> IzgubljeneZivotinjes { get; set; }
        public virtual ICollection<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
    }
}
