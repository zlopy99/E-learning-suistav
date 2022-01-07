using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Zupanija
    {
        public Zupanija()
        {
            Grads = new HashSet<Grad>();
        }

        public int ZupanijaId { get; set; }
        public string NazivZupanije { get; set; }

        public virtual ICollection<Grad> Grads { get; set; }
    }
}
