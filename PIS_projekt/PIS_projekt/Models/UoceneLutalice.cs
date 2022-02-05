using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class UoceneLutalice
    {
        public int UoceneLutaliceId { get; set; }
        [Display(Name = "Mjesto")]
        [Required(ErrorMessage ="Molimo izaberite mjesto u kojem ste vidjeli lutalicu")]
        public int GradId { get; set; }
        public string Slika { get; set; }
        [Required(ErrorMessage = "Molimo dajte nam neke informacije kako bismo pronašli lutalicu")]
        public string Opis { get; set; }
        public DateTime? DatumPrijave { get; set; }
        [Display(Name = "Unesite sliku")]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public virtual Grad Grad { get; set; }
    }
}
