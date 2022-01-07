using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class VrstaZivotinje
    {
        public VrstaZivotinje()
        {
            IzgubljeneZivotinjes = new HashSet<IzgubljeneZivotinje>();
            Pasminas = new HashSet<Pasmina>();
        }

        public int VrstaZivotinjeId { get; set; }
        public string NazivVrste { get; set; }

        public virtual ICollection<IzgubljeneZivotinje> IzgubljeneZivotinjes { get; set; }
        public virtual ICollection<Pasmina> Pasminas { get; set; }
    }
}
