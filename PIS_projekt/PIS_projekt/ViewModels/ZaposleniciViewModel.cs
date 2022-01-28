using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class ZaposleniciViewModel
    {
        public int KorisnikId { get; set; }
        public int SklonisteId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string NazivSklonista { get; set; }
        public string Grad { get; set; }
    }
}
