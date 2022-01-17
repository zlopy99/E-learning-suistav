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
                .Select(z => new ZivotinjeMiniViewModel
                {
                    ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                    SklonisteId = z.SklonisteId,
                    BrojMikrocipa = z.BrojMikrocipa,
                    ImeZivotinje = z.ImeZivotinje,
                    NazivPasmine = z.Pasmina.NazivPasmine,
                    NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                    NazivSpola = z.Spol.NazivSpola,
                   // DatumStenjenja = z.DatumStenjenja,
                   // Slika = z.Slika,
                    JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                    //AdresaPronalaska= z.AdresaPronalaska,
                    //DatumPronalaska = z.DatumPronalaska,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                   // Adresa = z.Skloniste.Adresa,
                    NazivGrada = z.Skloniste.Grad.NazivGrada,
                   // NazivZupanije = z.Skloniste.Grad.Zupanija.NazivZupanije*/
                })
                .ToList();

            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = query
            };
            return View("Index",model);
        }
        public IActionResult ZaUdomljavanje()
        {
            var query = ctx.ZivotinjaUSklonistus
                .Where(z=>z.UdomljavanjeId == 1)
                .Select(z => new ZivotinjeMiniViewModel
                {
                    ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                    BrojMikrocipa = z.BrojMikrocipa,
                    ImeZivotinje = z.ImeZivotinje,
                    NazivPasmine = z.Pasmina.NazivPasmine,
                    NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                    NazivSpola = z.Spol.NazivSpola,
                    //DatumStenjenja = z.DatumStenjenja,
                    //Slika = z.Slika,
                    JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                    //AdresaPronalaska = z.AdresaPronalaska,
                    //DatumPronalaska = z.DatumPronalaska,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                    //Adresa = z.Skloniste.Adresa,
                    NazivGrada = z.Skloniste.Grad.NazivGrada,
                   // NazivZupanije = z.Skloniste.Grad.Zupanija.NazivZupanije*/
                })
                .ToList();
            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = query
            };
            return View("Index", model);
        }
        public IActionResult Detalji(int id)
        {
            var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.ZivotinjaUSklonistuId == id)
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
                    AdresaPronalaska = z.AdresaPronalaska,
                    DatumPronalaska = z.DatumPronalaska,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                    //Adresa = z.Skloniste.Adresa,
                    NazivGrada = z.Skloniste.Grad.NazivGrada,
                   // NazivZupanije = z.Skloniste.Grad.Zupanija.NazivZupanije*/
                })
                .ToList();
            var model = new ZivotinjeVM
            {
                zivotinje = query
            };
            return View("Detalji", model);
        }
        public IActionResult Izgubljene()
        {
            var query = ctx.IzgubljeneZivotinjes
                .Select(iz => new IzgubljeneMiniViewModel
                {
                    IzgubljeneZivotinjeId = iz.IzgubljeneZivotinjeId,
                    VrstaZivotinje = iz.Pasmina.VrstaZivotinje.NazivVrste,
                    Pasmina = iz.Pasmina.NazivPasmine,
                    Spol = iz.Spol.NazivSpola,
                    Kontakt = iz.Kontakt,
                    LokacijaNestanka = iz.LokacijaNestanka,
                    Grad = iz.Grad.NazivGrada,
                    DatumNestanka = iz.DatumNestanka,
                    DatumPrijave = iz.DatumPrijave
                })
                .ToList();
            var model = new IzgubljeneMiniVM
            {
                IzgubljeneMini = query
            };
            return View("Izgubljene", model);
        }
        public IActionResult IzgubljeneDetalji(int id)
        {
            var query = ctx.IzgubljeneZivotinjes
                .Where(iz => iz.IzgubljeneZivotinjeId == id)
                .Select(iz => new IzgubljeneViewModel
                {
                    IzgubljeneZivotinjeId = iz.IzgubljeneZivotinjeId,
                    BrojMikrocipa = iz.BrojMikrocipa,
                    Ime = iz.Ime,
                    Pasmina = iz.Pasmina.NazivPasmine,
                    VrstaZivotinje = iz.VrstaZivotinje.NazivVrste,
                    Spol = iz.Spol.NazivSpola,
                    Kastrat = iz.Kastrat.JeLiKastrat,
                    Slika = iz.Slika,
                    LokacijaNestanka = iz.LokacijaNestanka,
                    Grad = iz.Grad.NazivGrada,
                    DatumNestanka = iz.DatumNestanka,
                    DatumPrijave = iz.DatumPrijave,
                    Kontakt = iz.Kontakt
                })
                .ToList();

            var model = new IzgubljeneVM
            {
                izgubljene = query
            };
            return View("IzgubljeneDetalji", model);
        }
    }
}
