using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class UoceneLutalice
    {
        public int UoceneLutaliceId { get; set; }
        [Display(Name = "Mjesto")]
        public int GradId { get; set; }
        public string Slika { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumPrijave { get; set; }

        public virtual Grad Grad { get; set; }
    }
}
