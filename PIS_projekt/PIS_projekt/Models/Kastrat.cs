using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Kastrat
    {
        public Kastrat()
        {
            IzgubljeneZivotinjes = new HashSet<IzgubljeneZivotinje>();
            ZivotinjaUSklonistus = new HashSet<ZivotinjaUSklonistu>();
        }

        public int KastratId { get; set; }
        public string JeLiKastrat { get; set; }

        public virtual ICollection<IzgubljeneZivotinje> IzgubljeneZivotinjes { get; set; }
        public virtual ICollection<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
    }
}
