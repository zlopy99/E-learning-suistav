using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.ViewModels
{
    public class SklonisteViewModel
    {
        public int skloniste_id { get; set; }
        

        [Display(Name="Naziv skloništa")]
        public string NazivSklonista { get; set; }
        [Display(Name = "Adresa skloništa")]
        public string Adresa { get; set; }
        [Display(Name = "Mjesto")]
        public string NazivGrada { get; set; }
        [Display(Name = "Županija")]
        public string NazivZupanije { get; set; }
        [Display(Name = "Kapacitet skloništa")]
        public string KapacitetSklonista { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }
    }
}
