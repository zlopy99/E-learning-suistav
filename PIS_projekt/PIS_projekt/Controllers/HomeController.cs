

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_projekt.Models;
using PIS_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        public HomeController(LutaliceInfoSustavContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            var query = ctx.Sklonistes
                .Select(s => new SklonisteViewModel
                {
                    skloniste_id = s.SklonisteId,
                    /*GradId = s.GradId,
                    ZupanijaId = s.Grad.ZupanijaId,*/
                    NazivSklonista = s.NazivSklonista,
                    Adresa = s.Adresa,
                    NazivGrada = s.Grad.NazivGrada,
                    NazivZupanije = s.Grad.Zupanija.NazivZupanije,
                    KapacitetSklonista = s.KapacitetSklonista,
                    Telefon = s.Telefon,
                    Email = s.Email

                })
                .ToList();
            var model = new SklonisteVM
            {
                skloniste = query
            };
            return View("Index", model);
            // return Ok(query);
        }

        public IActionResult Skloniste(int id)
        {
            var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.SklonisteId == id)
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
            var poruka = ctx.Sklonistes
                .Where(s => s.SklonisteId == id)
                .FirstOrDefault<Skloniste>();
            ViewBag.NazivSklonista = poruka.NazivSklonista;
            ViewBag.ID = id;
            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = query
            };
            return View("ZivotinjeUSklonistu", model);
        }

        public IActionResult Udomljavanje(int id)
        {
            var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.UdomljavanjeId == 1)
                .Where(z=>z.SklonisteId == id)
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
                   // AdresaPronalaska = z.AdresaPronalaska,
                    //DatumPronalaska = z.DatumPronalaska,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                    //Adresa = z.Skloniste.Adresa,
                    NazivGrada = z.Skloniste.Grad.NazivGrada,
                    // NazivZupanije = z.Skloniste.Grad.Zupanija.NazivZupanije*/
                })
                .ToList();
            var poruka = ctx.Sklonistes
                .Where(s => s.SklonisteId == id)
                .FirstOrDefault<Skloniste>();
            ViewBag.NazivSklonista = poruka.NazivSklonista;
            ViewBag.ID = id;
            
            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = query
            };
            return View("ZaUdomljavanje", model);
        }
    }
}
