using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS_projekt.Models;
using PIS_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Controllers
{
    public class AdminController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        public AdminController(LutaliceInfoSustavContext ctx)
        {
            this.ctx = ctx;
            
        }
        public IActionResult CreateSkloniste()
        {
            var query = ctx.Grads
                      .OrderBy(g=>g.NazivGrada)
                      .Select(g => new
                      {
                          g.GradId,
                          g.NazivGrada
                      })
                      .ToList();
            ViewBag.Gradovi = new SelectList(query, nameof(Grad.GradId), nameof(Grad.NazivGrada));
            return View("NovoSkloniste");
        }
        public IActionResult SpremiSkloniste(Skloniste s)
        {
            if (ModelState.IsValid)
            {
                ctx.Sklonistes.Add(s);
                ctx.SaveChanges();
                return RedirectToAction("Sklonista");

            }
            else
            {
                return View("NovoSkloniste", s);
            }
        }
        public IActionResult Sklonista(int pg = 1)
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
           

            const int pageSize = 2;
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
            return View("Sklonista", model);
        }
        public IActionResult DodajAdmina()
        {
            return View("DodajAdmina");
        }
        public IActionResult Add(Korisnik k)
        {
            
            if (ModelState.IsValid)
            {
                k.UlogaFk = 1;
                ctx.Korisniks.Add(k);
                ctx.SaveChanges();
                HttpContext.Session.SetString("imeLogiranogKorisnika", k.Ime);
                HttpContext.Session.SetString("prezimeLogiranogKorisnika", k.Prezime);
                HttpContext.Session.SetInt32("idLogiranogKorisnika", k.KorisnikId);
                return RedirectToAction("PrikazAdmina", "Korisnici");
                
            }
            else
            {
                return View("DodajAdmina", k);
            }
        }
        public IActionResult DeleteAdmin(int id)
        {
            var query = ctx.Korisniks
                .Where(a => a.KorisnikId == id)
                .Where(a => a.UlogaFk == 1)
                .FirstOrDefault<Korisnik>();
            ctx.Korisniks.Remove(query);
            ctx.SaveChanges();
            return RedirectToAction("PrikazAdmina", "Korisnici");
        }
        public IActionResult IzbrisiSkloniste(int id)
        {
            var query = ctx.Sklonistes
                .Where(s => s.SklonisteId == id)
                .FirstOrDefault<Skloniste>();
            ctx.Sklonistes.Remove(query);
            ctx.SaveChanges();
            return RedirectToAction("Sklonista");

        }
        public IActionResult IzbrišiKorisnika(int id)
        {
            var query = ctx.Korisniks
                .Where(s => s.KorisnikId == id)
                .Where(a => a.UlogaFk == 2)
                .FirstOrDefault<Korisnik>();
            ctx.Korisniks.Remove(query);
            ctx.SaveChanges();
            return RedirectToAction("PrikazZaposlenika","Korisnici");

        }
    }
}
