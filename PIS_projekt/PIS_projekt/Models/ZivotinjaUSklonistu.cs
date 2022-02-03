using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class ZivotinjaUSklonistu
    {
        public int ZivotinjaUSklonistuId { get; set; }
        [Display(Name ="Broj mikročipa")]
        public string BrojMikrocipa { get; set; }
        [Display(Name = "Ime životinje")]
        public string ImeZivotinje { get; set; }
        [Display(Name = "Datum štenjenja")]
        public DateTime? DatumStenjenja { get; set; }
        [Display(Name = "Adresa pronalaska")]
        public string AdresaPronalaska { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage = "Molimo izaberite pasminu")]
        [Display(Name = "Pasmina")]
        public int? PasminaId { get; set; }
        [Required(ErrorMessage = "Molimo izaberite spol")]
        [Display(Name = "Spol životinje")]
        public int SpolId { get; set; }
        [Display(Name = "Je li životinja kastrirana?")]
        public int? KastratId { get; set; }
        public int SklonisteId { get; set; }
        [Display(Name = "Je li životinja za udomljavanje?")]
        public int? UdomljavanjeId { get; set; }
        [MaxLength]
        public string Slika { get; set; }
        [Display(Name = "Datum pronalaska životinje")]
        public DateTime? DatumPronalaska { get; set; }
        [Display(Name = "Unesite sliku")]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public virtual Kastrat Kastrat { get; set; }
        public virtual Pasmina Pasmina { get; set; }
        public virtual Skloniste Skloniste { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual Udomljavanje Udomljavanje { get; set; }
    }
}
