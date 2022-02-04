using Microsoft.AspNetCore.Http;
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
        public IActionResult Pronadjene(string sortOrder, int pg = 1)
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
                    JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                    NazivGrada = z.Skloniste.Grad.NazivGrada
                })
                .ToList();

            ViewData["PasminaOrder"] = string.IsNullOrEmpty(sortOrder) ? "Pasmina_desc" : "";
            ViewData["ImeOrder"] = sortOrder == "Ime" ? "Ime_desc" : "Ime";
            ViewData["VrstaZivotinjeOrder"] = sortOrder == "VrstaZivotinje" ? "VrstaZivotinje_desc" : "VrstaZivotinje";
            ViewData["SpolOrder"] = sortOrder == "Spol" ? "Spol_desc" : "Spol";
            ViewData["ZaUdomljavanjeOrder"] = sortOrder == "ZaUdomljavanje" ? "ZaUdomljavanje_desc" : "ZaUdomljavanje";
            ViewData["NazivSklonistaOrder"] = sortOrder == "NazivSklonista" ? "NazivSklonista_desc" : "NazivSklonista";
            ViewData["MjestoOrder"] = sortOrder == "Mjesto" ? "Mjesto_desc" : "Mjesto";

            switch (sortOrder)
            {
                case "Mjesto":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivGrada)
                            .ToList();
                    ViewBag.CurrentSort = "Mjesto";
                    break;
                case "Mjesto_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivGrada)
                            .ToList();
                    ViewBag.CurrentSort = "Mjesto_desc";
                    break;
                case "NazivSklonista_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivSklonista)
                            .ToList();
                    ViewBag.CurrentSort = "NazivSklonista_desc";
                    break;
                case "NazivSklonista":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivSklonista)
                            .ToList();
                    ViewBag.CurrentSort = "NazivSklonista";
                    break;
                case "ZaUdomljavanje":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.JeLiZaUdomljavanje)
                            .ToList();
                    ViewBag.CurrentSort = "ZaUdomljavanje";
                    break;
                case "ZaUdomljavanje_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.JeLiZaUdomljavanje)
                            .ToList();
                    ViewBag.CurrentSort = "ZaUdomljavanje_desc";
                    break;
                case "Spol_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivSpola)
                            .ToList();
                    ViewBag.CurrentSort = "Spol_desc";
                    break;
                case "Spol":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivSpola)
                            .ToList();
                    ViewBag.CurrentSort = "Spol";
                    break;
                case "VrstaZivotinje_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivVrste)
                            .ToList();
                    ViewBag.CurrentSort = "VrstaZivotinje_desc";
                    break;
                case "VrstaZivotinje":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivVrste)
                            .ToList();
                    ViewBag.CurrentSort = "VrstaZivotinje";
                    break;
                case "Ime":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.ImeZivotinje)
                            .ToList();
                    ViewBag.CurrentSort = "Ime";
                    break;
                case "Ime_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.ImeZivotinje)
                            .ToList();
                    ViewBag.CurrentSort = "Ime_desc";
                    break;
                case "Pasmina_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivPasmine)
                            .ToList();
                    ViewBag.CurrentSort = "Pasmina_desc";
                    break;
                default:
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z=>z.NazivPasmine)
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
            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = data
            };
            this.ViewBag.Pager = pager;

            
            return View("Index",model);
        }
        public IActionResult ZaUdomljavanje(string sortOrder,int pg = 1)
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
                    JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                    NazivSklonista = z.Skloniste.NazivSklonista,
                    NazivGrada = z.Skloniste.Grad.NazivGrada,
                   
                })
                .ToList();

            ViewData["PasminaOrder"] = string.IsNullOrEmpty(sortOrder) ? "Pasmina_desc" : "";
            ViewData["ImeOrder"] = sortOrder == "Ime" ? "Ime_desc" : "Ime";
            ViewData["VrstaZivotinjeOrder"] = sortOrder == "VrstaZivotinje" ? "VrstaZivotinje_desc" : "VrstaZivotinje";
            ViewData["SpolOrder"] = sortOrder == "Spol" ? "Spol_desc" : "Spol";
            ViewData["ZaUdomljavanjeOrder"] = sortOrder == "ZaUdomljavanje" ? "ZaUdomljavanje_desc" : "ZaUdomljavanje";
            ViewData["NazivSklonistaOrder"] = sortOrder == "NazivSklonista" ? "NazivSklonista_desc" : "NazivSklonista";
            ViewData["MjestoOrder"] = sortOrder == "Mjesto" ? "Mjesto_desc" : "Mjesto";

            switch (sortOrder)
            {
                case "Mjesto":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivGrada)
                            .ToList();
                    ViewBag.CurrentSort = "Mjesto";
                    break;
                case "Mjesto_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivGrada)
                            .ToList();
                    ViewBag.CurrentSort = "Mjesto_desc";
                    break;
                case "NazivSklonista_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivSklonista)
                            .ToList();
                    ViewBag.CurrentSort = "NazivSklonista_desc";
                    break;
                case "NazivSklonista":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivSklonista)
                            .ToList();
                    ViewBag.CurrentSort = "NazivSklonista";
                    break;
                case "ZaUdomljavanje":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.JeLiZaUdomljavanje)
                            .ToList();
                    ViewBag.CurrentSort = "ZaUdomljavanje";
                    break;
                case "ZaUdomljavanje_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.JeLiZaUdomljavanje)
                            .ToList();
                    ViewBag.CurrentSort = "ZaUdomljavanje_desc";
                    break;
                case "Spol_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivSpola)
                            .ToList();
                    ViewBag.CurrentSort = "Spol_desc";
                    break;
                case "Spol":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivSpola)
                            .ToList();
                    ViewBag.CurrentSort = "Spol";
                    break;
                case "VrstaZivotinje_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivVrste)
                            .ToList();
                    ViewBag.CurrentSort = "VrstaZivotinje_desc";
                    break;
                case "VrstaZivotinje":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivVrste)
                            .ToList();
                    ViewBag.CurrentSort = "VrstaZivotinje";
                    break;
                case "Ime":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.ImeZivotinje)
                            .ToList();
                    ViewBag.CurrentSort = "Ime";
                    break;
                case "Ime_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.ImeZivotinje)
                            .ToList();
                    ViewBag.CurrentSort = "Ime_desc";
                    break;
                case "Pasmina_desc":
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderByDescending(z => z.NazivPasmine)
                            .ToList();
                    ViewBag.CurrentSort = "Pasmina_desc";
                    break;
                default:
                    query = ctx.ZivotinjaUSklonistus
                            .Select(z => new ZivotinjeMiniViewModel
                            {
                                ZivotinjaUSklonistuId = z.ZivotinjaUSklonistuId,
                                SklonisteId = z.SklonisteId,
                                BrojMikrocipa = z.BrojMikrocipa,
                                ImeZivotinje = z.ImeZivotinje,
                                NazivPasmine = z.Pasmina.NazivPasmine,
                                NazivVrste = z.Pasmina.VrstaZivotinje.NazivVrste,
                                NazivSpola = z.Spol.NazivSpola,
                                JeLiZaUdomljavanje = z.Udomljavanje.JeLiZaUdomljavanje,
                                NazivSklonista = z.Skloniste.NazivSklonista,
                                NazivGrada = z.Skloniste.Grad.NazivGrada
                            })
                            .OrderBy(z => z.NazivPasmine)
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
            var model = new ZivotinjeMiniVM
            {
                ZivotinjeMini = data
            };
            this.ViewBag.Pager = pager;
            return View("ZaUdomljavanje", model);
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
        public IActionResult Izgubljene(string sortOrder,int pg=1)
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

            ViewData["DatumNestankaOrder"] = string.IsNullOrEmpty(sortOrder) ? "DatumNestanka_desc" : "";
            ViewData["VrstaZivotinjeOrder"] = sortOrder == "VrstaZivotinje" ? "VrstaZivotinje_desc" : "VrstaZivotinje";
            ViewData["PasminaOrder"] = sortOrder == "Pasmina" ? "Pasmina_desc" : "Pasmina";
            ViewData["SpolOrder"] = sortOrder == "Spol" ? "Spol_desc" : "Spol";
            ViewData["DatumPrijaveOrder"] = sortOrder == "DatumPrijave" ? "DatumPrijave_desc" : "DatumPrijave";
            ViewData["MjestoNestankaOrder"] = sortOrder == "MjestoNestanka" ? "MjestoNestanka_desc" : "MjestoNestanka";
            ViewData["LokacijaOrder"] = sortOrder == "Lokacija" ? "Lokacija_desc" : "Lokacija";
            switch (sortOrder)
            {
                case "Lokacija":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz => iz.LokacijaNestanka)
                        .ToList();
                    ViewBag.CurrentSort = "Lokacija";
                    break;
                case "Lokacija_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.LokacijaNestanka)
                        .ToList();
                    ViewBag.CurrentSort = "Lokacija_desc";
                    break;
                case "MjestoNestanka":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz => iz.Grad)
                        .ToList();
                    ViewBag.CurrentSort = "MjestoNestanka";
                    break;
                case "MjestoNestanka_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.Grad)
                        .ToList();
                    ViewBag.CurrentSort = "MjestoNestanka_desc";
                    break;
                case "DatumPrijave":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz => iz.DatumPrijave)
                        .ToList();
                    ViewBag.CurrentSort = "DatumPrijave";
                    break;
                case "DatumPrijave_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.DatumPrijave)
                        .ToList();
                    ViewBag.CurrentSort = "DatumPrijave_desc";
                    break;
                case "Spol":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz => iz.Spol)
                        .ToList();
                    ViewBag.CurrentSort = "Spol";
                    break;
                case "Spol_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.Spol)
                        .ToList();
                    ViewBag.CurrentSort = "Spol_desc";
                    break;
                case "Pasmina":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz => iz.Pasmina)
                        .ToList();
                    ViewBag.CurrentSort = "Pasmina";
                    break;
                case "Pasmina_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.Pasmina)
                        .ToList();
                    ViewBag.CurrentSort = "Pasmina_desc";
                    break;
                case "VrstaZivotinje":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz => iz.VrstaZivotinje)
                        .ToList();
                    ViewBag.CurrentSort = "VrstaZivotinje";
                    break;
                case "VrstaZivotinje_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.VrstaZivotinje)
                        .ToList();
                    ViewBag.CurrentSort = "VrstaZivotinje_desc";
                    break;
                case "DatumNestanka_desc":
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderByDescending(iz => iz.DatumNestanka)
                        .ToList();
                    ViewBag.CurrentSort = "DatumNestanka_desc";
                    break;
                default:
                    query = ctx.IzgubljeneZivotinjes
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
                        .OrderBy(iz=>iz.DatumNestanka)
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
            var model = new IzgubljeneMiniVM
            {
                IzgubljeneMini = data
            };
            this.ViewBag.Pager = pager;
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
        public IActionResult ZivotinjeUSklonistu(int pg=1)
        {
            var logiraniKorisnik = ctx.Korisniks
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .FirstOrDefault<Korisnik>();
            var skloniste = ctx.Sklonistes
                .Where(s => s.SklonisteId == logiraniKorisnik.SklonisteFk)
                .FirstOrDefault<Skloniste>();
            ViewBag.ID = skloniste.SklonisteId;
            if (skloniste != null)
            {
                var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.SklonisteId == skloniste.SklonisteId)
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
                
            
                const int pageSize = 2;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = query.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = query.Skip(recSkip).Take(pager.PageSize).ToList();
                var model = new ZivotinjeMiniVM
                {
                    ZivotinjeMini = data
                };
                this.ViewBag.Pager = pager;
                return View("ZivotinjeUSklonistu", model);
            }
            else
            {
                return Ok("problemi, problemi");
            }
            

         }
        public IActionResult UoceneLutalice(int pg = 1)
        {
            var zaposlenik = ctx.Korisniks
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .Where(k=>k.Ime == HttpContext.Session.GetString("imeLogiranogKorisnika"))
                .FirstOrDefault<Korisnik>();
            
            var skloniste = ctx.Sklonistes
                .Where(s => s.SklonisteId == zaposlenik.SklonisteFk)
                .FirstOrDefault<Skloniste>();
            
            
            var grad = ctx.Grads
                .Where(g => g.GradId == skloniste.GradId)
                .FirstOrDefault<Grad>();
            
            var query = ctx.UoceneLutalices
                .Where(ul => ul.GradId == grad.GradId)
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
            this.ViewBag.Pager = pager;
            return View("PrijavljeneLutalice", data);
        }
        //  ZaUdomljavanjeSkloniste
        public IActionResult ZaUdomljavanjeSkloniste(int pg=1)
        {
            var logiraniKorisnik = ctx.Korisniks
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .FirstOrDefault<Korisnik>();
            var skloniste = ctx.Sklonistes
                .Where(s => s.SklonisteId == logiraniKorisnik.SklonisteFk)
                .FirstOrDefault<Skloniste>();
            ViewBag.ID = skloniste.SklonisteId;
            if (skloniste != null)
            {
                var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.SklonisteId == skloniste.SklonisteId)
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


                const int pageSize = 5;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = query.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = query.Skip(recSkip).Take(pager.PageSize).ToList();
                var model = new ZivotinjeMiniVM
                {
                    ZivotinjeMini = data
                };
                this.ViewBag.Pager = pager;
                return View("ZaUdomljavanjeSkloniste", model);
            }
            else
            {
                return Ok("problemi, problemi");
            }
        }
        public IActionResult IzgubljeneSkloniste(int pg = 1)
        {
            var logiraniKorisnik = ctx.Korisniks
                   .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                   .FirstOrDefault<Korisnik>();
            var skloniste = ctx.Sklonistes
                .Where(s => s.SklonisteId == logiraniKorisnik.SklonisteFk)
                .FirstOrDefault<Skloniste>();
            ViewBag.ID = skloniste.SklonisteId;
            var query = ctx.IzgubljeneZivotinjes
                .Where(iz=>iz.GradId == skloniste.GradId)
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
            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = query.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = query.Skip(recSkip).Take(pager.PageSize).ToList();
            var model = new IzgubljeneMiniVM
            {
                IzgubljeneMini = data
            };
            this.ViewBag.Pager = pager;
            return View("IzgubljeneSkloniste", model);
        }
        public IActionResult IzgubljeneDetaljiSkloniste(int id)
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
            return View("izgubljeneDetaljiSkloniste", model);
        }
    }
}
