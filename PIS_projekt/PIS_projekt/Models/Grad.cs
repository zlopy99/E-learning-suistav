using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Grad
    {
        public Grad()
        {
            IzgubljeneZivotinjes = new HashSet<IzgubljeneZivotinje>();
            Sklonistes = new HashSet<Skloniste>();
            UoceneLutalices = new HashSet<UoceneLutalice>();
        }

        public int GradId { get; set; }
        [Display(Name = "Mjesto")]
        public string NazivGrada { get; set; }
        public int ZupanijaId { get; set; }

        public virtual Zupanija Zupanija { get; set; }
        public virtual ICollection<IzgubljeneZivotinje> IzgubljeneZivotinjes { get; set; }
        public virtual ICollection<Skloniste> Sklonistes { get; set; }
        public virtual ICollection<UoceneLutalice> UoceneLutalices { get; set; }
    }
}
