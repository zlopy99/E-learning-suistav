using System;
using System.Collections.Generic;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Skloniste
    {
        public Skloniste()
        {
            ZivotinjaUSklonistus = new HashSet<ZivotinjaUSklonistu>();
        }

        public int SklonisteId { get; set; }
        public string NazivSklonista { get; set; }
        public string Adresa { get; set; }
        public string KapacitetSklonista { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
    }
}
