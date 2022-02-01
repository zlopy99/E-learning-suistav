﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult Edit(int id)
        {
            var query = ctx.Sklonistes
                .Where(s => s.SklonisteId == id)
                .FirstOrDefault<Skloniste>();

            var gradovi = ctx.Grads
                      .OrderBy(g => g.NazivGrada)
                      .Select(g => new
                      {
                          g.GradId,
                          g.NazivGrada
                      })
                      .ToList();
            ViewBag.Gradovi = new SelectList(gradovi, nameof(Grad.GradId), nameof(Grad.NazivGrada));
            return View("SklonisteEdit", query);
        }
        public IActionResult SpremiPromjene(Skloniste s)
        {
            if (ModelState.IsValid)
            {
                var query = ctx.Sklonistes
                    .Where(sk => sk.SklonisteId == s.SklonisteId)
                    .FirstOrDefault<Skloniste>();

                Skloniste sklonisteEdit = ctx.Sklonistes.Find(s.SklonisteId);
                sklonisteEdit.NazivSklonista = s.NazivSklonista;
                ctx.SaveChanges();
                sklonisteEdit.Adresa = s.Adresa;
                ctx.SaveChanges();
                sklonisteEdit.KapacitetSklonista = s.KapacitetSklonista;
                ctx.SaveChanges();
                sklonisteEdit.Email = s.Email;
                ctx.SaveChanges();
                sklonisteEdit.Telefon = s.Telefon;
                ctx.SaveChanges();
                sklonisteEdit.GradId = s.GradId;
                ctx.SaveChanges();

                return RedirectToAction("Sklonista", "Admin");

            }
            else
            {
                return View("SklonisteEdit", s);
            }
        }
        public IActionResult UrediAdmina(int id)
        {
            var query = ctx.Korisniks
                .Where(k => k.UlogaFk == 1)
                .Where(k => k.KorisnikId == id)
                .FirstOrDefault<Korisnik>();

            return View("AdminsEdit",query);
        }
        public IActionResult Uredi(Korisnik k)
        {
            k.UlogaFk = 1;
            if (ModelState.IsValid)
            {
                var query = ctx.Korisniks
                    .Where(kor => kor.KorisnikId == k.KorisnikId)
                    .FirstOrDefault<Korisnik>();

                Korisnik korisnikEdit = ctx.Korisniks.Find(k.KorisnikId);
                korisnikEdit.Ime = k.Ime;
                ctx.SaveChanges();
                korisnikEdit.Prezime = k.Prezime;
                ctx.SaveChanges();
                korisnikEdit.Email = k.Email;
                ctx.SaveChanges();
                korisnikEdit.Lozinka = k.Lozinka;
                ctx.SaveChanges();

                return RedirectToAction("PrikazAdmina", "Korisnici");
            }
            else
            {
                return View("AdminsEdit", k);
            }
        }
        public IActionResult UrediZaposlenika(int id)
        {
            var query = ctx.Korisniks
                .Where(k => k.KorisnikId == id)
                .Where(k => k.UlogaFk == 2)
                .FirstOrDefault<Korisnik>();
            var sklonista = ctx.Sklonistes
                      .OrderBy(s => s.NazivSklonista)
                      .Select(s => new
                      {
                          s.SklonisteId,
                          s.NazivSklonista
                      })
                      .ToList();
            ViewBag.Sklonista = new SelectList(sklonista, nameof(Skloniste.SklonisteId), nameof(Skloniste.NazivSklonista));
            return View("ZaposlenikEdit",query);
        }
        public IActionResult SpremiPromjeneZaposlenik(Korisnik k)
        {
            k.UlogaFk = 2;
            if (ModelState.IsValid)
            {
                Korisnik korisnikEdit = ctx.Korisniks.Find(k.KorisnikId);
                korisnikEdit.Ime = k.Ime;
                ctx.SaveChanges();
                korisnikEdit.Prezime = k.Prezime;
                ctx.SaveChanges();
                korisnikEdit.Email = k.Email;
                ctx.SaveChanges();
                korisnikEdit.Lozinka = k.Lozinka;
                ctx.SaveChanges();
                korisnikEdit.SklonisteFk = k.SklonisteFk;
                ctx.SaveChanges();
                return RedirectToAction("PrikazZaposlenika", "Korisnici");
            }
            else
            {
                return View("ZaposlenikEdit", k);
            }
        }
    }
}
