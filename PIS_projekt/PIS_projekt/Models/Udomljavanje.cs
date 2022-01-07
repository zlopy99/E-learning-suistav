using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Udomljavanje
    {
        public Udomljavanje()
        {
            ZivotinjaUSklonistus = new HashSet<ZivotinjaUSklonistu>();
        }

        public int UdomljavanjeId { get; set; }
        public string JeLiZaUdomljavanje { get; set; }

        public virtual ICollection<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
    }
}
