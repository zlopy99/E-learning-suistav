using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        [Required(ErrorMessage ="Molimo unesite ime")]
        
        public string Ime { get; set; }
        [Required(ErrorMessage = "Molimo unesite prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Molimo unesite vašu email adresu")]
        [EmailAddress(ErrorMessage = "Molimo unesite validnu email adresu")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Molimo unesite lozinku")]
        [MinLength(6, ErrorMessage = "Lozinka mora sadržavati minimalno 6 znakova!")]
        public string Lozinka { get; set; }
        public int UlogaFk { get; set; }
        public int? SklonisteFk { get; set; }

        public virtual Uloga Uloga { get; set; }
        public virtual Skloniste Skloniste { get; set; }
    }
}
