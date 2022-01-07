using Microsoft.AspNetCore.Mvc;
using PIS_projekt.Models;
using PIS_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Controllers
{
    public class ZivotinjeController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        public ZivotinjeController(LutaliceInfoSustavContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Pronadjene()
        {
            var query = ctx.ZivotinjaUSklonistus
                .Select(z => new ZivotinjeViewModel
                {
                    ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                    BrojMikrocipa = z.BrojMikrocipa,
                    ImeZivotinje = z.ImeZivotinje,
                    NazivPasmine = z.Pasmina.NazivPasmine,
                    NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                    NazivSpola = z.Spol.NazivSpola,
                    DatumStenjenja = z.DatumStenjenja,
                    Slika = z.Slika,
                    JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                    AdresaPronalaska= z.AdresaPronalaska,
                    DatumPronalaska = z.DatumPronalaska,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                    Adresa = z.Skloniste.Adresa,
                    NazivGrada = z.Skloniste.Grad.NazivGrada,
                    NazivZupanije = z.Skloniste.Grad.Zupanija.NazivZupanije
                })
                .ToList();

            var model = new ZivotinjeVM
            {
                zivotinje = query
            };
            return View("Index",model);
        }
    }
}
