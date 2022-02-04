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
        public IActionResult Index(string sortOrder,int pg=1)
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
            
            ViewData["NazivOrder"] = string.IsNullOrEmpty(sortOrder) ? "Naziv_desc" : "";
            ViewData["GradOrder"] = sortOrder == "Grad" ? "Grad_desc" : "Grad";
            ViewData["ZupanijaOrder"] = sortOrder == "Zupanija" ? "Zupanija_desc" : "Zupanija";
            switch (sortOrder)
            {
                case "Zupanija_desc":
                    query = ctx.Sklonistes
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
                        .OrderByDescending(s => s.NazivZupanije)
                        .ToList();
                    ViewBag.CurrentSort = "Zupanija_desc";
                    break;
                case "Zupanija":
                    query = ctx.Sklonistes
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
                        .OrderBy(s => s.NazivZupanije)
                        .ToList();
                    ViewBag.CurrentSort = "Zupanija";
                    break;
                case "Grad":
                    query = ctx.Sklonistes
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
                        .OrderBy(s => s.NazivGrada)
                        .ToList();
                    ViewBag.CurrentSort = "Grad";
                    break;
                case "Grad_desc":
                    query = ctx.Sklonistes
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
                        .OrderByDescending(s => s.NazivGrada)
                        .ToList();
                    ViewBag.CurrentSort = "Grad_desc";
                    break;
                case "Naziv_desc":
                    query = ctx.Sklonistes
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
                        .OrderByDescending(s => s.NazivSklonista)
                        .ToList();
                    ViewBag.CurrentSort = "Naziv_desc";
                    break;
                default:
                    query = ctx.Sklonistes
                        .Select(s => new SklonisteViewModel
                        {
                            skloniste_id = s.SklonisteId,
                            NazivSklonista = s.NazivSklonista,
                            Adresa = s.Adresa,
                            NazivGrada = s.Grad.NazivGrada,
                            NazivZupanije = s.Grad.Zupanija.NazivZupanije,
                            KapacitetSklonista = s.KapacitetSklonista,
                            Telefon = s.Telefon,
                            Email = s.Email

                        })
                        .OrderBy(s => s.NazivSklonista)
                        .ToList();
                    ViewBag.CurrentSort = "";
                    break;
            }
           
            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = query.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = query.Skip(recSkip).Take(pager.PageSize).ToList();
            var model = new SklonisteVM
            {
                skloniste = data
            };
            this.ViewBag.Pager = pager;
            
        
            return View("Index", model);
            // return Ok(model);
        }

        public IActionResult Skloniste(int id, int pg = 1)
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

            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = query.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = query.Skip(recSkip).Take(pager.PageSize).ToList();

            var poruka = ctx.Sklonistes
                .Where(s => s.SklonisteId == id)
                .FirstOrDefault<Skloniste>();
            ViewBag.NazivSklonista = poruka.NazivSklonista;
            ViewBag.ID = id;

            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = data
            };
            this.ViewBag.Pager = pager;
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
                    JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
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
