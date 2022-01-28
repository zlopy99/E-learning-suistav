using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class Skloniste
    {
        public Skloniste()
        {
            ZivotinjaUSklonistus = new HashSet<ZivotinjaUSklonistu>();
            Korisniks = new HashSet<Korisnik>();
        }

        public int SklonisteId { get; set; }
        [Display(Name = "Naziv skloništa")]
        public string NazivSklonista { get; set; }
        public string Adresa { get; set; }
        [Display(Name = "Kapacitet skloništa")]
        public string KapacitetSklonista { get; set; }
        [EmailAddress(ErrorMessage = "Molimo unesite validnu email adresu")]
        public string Email { get; set; }
        public string Telefon { get; set; }
        [Display(Name = "Mjesto")]
        [Required(ErrorMessage ="Molimo izaberite mjesto")]
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
