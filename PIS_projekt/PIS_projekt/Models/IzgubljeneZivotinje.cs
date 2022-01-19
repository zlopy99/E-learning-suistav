using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class IzgubljeneZivotinje
    {
        public int IzgubljeneZivotinjeId { get; set; }
        [Display(Name = "Broj mikročipa")]
        public string BrojMikrocipa { get; set; }
        public string Ime { get; set; }
        [Display(Name ="Spol vašeg ljubimca")]
        public int? SpolId { get; set; }
        [Required(ErrorMessage = "Molimo unesite kontakt telefon ili email kako bismo vas kontaktirali u slučaju pronalaska")]
        public string Kontakt { get; set; }
        [Display(Name = "Lokacija/adresa nestanka vašeg ljubimca")]
        public string LokacijaNestanka { get; set; }
        [Display(Name = "Mjesto nestanka vašeg ljubimca")]
        public int? GradId { get; set; }
        [Display(Name = "Datum nestanka vašeg ljubimca")]
        public DateTime? DatumNestanka { get; set; }
        public DateTime? DatumPrijave { get; set; }
        public string Slika { get; set; }
        [Display(Name = "Pasmina")]
        public int? PasminaId { get; set; }
        [Display(Name = "Vrsta životinje")]
        public int? VrstaZivotinjeId { get; set; }
        [Display(Name = "Je li vaš ljubimac kastriran")]
        public int? KastratId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Kastrat Kastrat { get; set; }
        public virtual Pasmina Pasmina { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual VrstaZivotinje VrstaZivotinje { get; set; }
    }
}
