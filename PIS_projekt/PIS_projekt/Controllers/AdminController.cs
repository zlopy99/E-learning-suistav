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
            if (HttpContext.Session.GetInt32("idUloge") == 1)
            {
                var query = ctx.Grads
                      .OrderBy(g => g.NazivGrada)
                      .Select(g => new
                      {
                          g.GradId,
                          g.NazivGrada
                      })
                      .ToList();
                ViewBag.Gradovi = new SelectList(query, nameof(Grad.GradId), nameof(Grad.NazivGrada));
                return View("NovoSkloniste");
            }
            else
            {
                return Ok("Nemate pristup ovoj stranici");
            }
                
        }
        public IActionResult SpremiSkloniste(Skloniste s)
        {
            if (ModelState.IsValid)
            {
                ctx.Sklonistes.Add(s);
                ctx.SaveChanges();
                //return RedirectToAction("Sklonista");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "NovoSkloniste") });

            }
            else
            {
                if (s.GradId == 0)
                {
                    ViewBag.Error = "Molimo izaberite sklonište";
                }
                var query = ctx.Grads
                      .OrderBy(g => g.NazivGrada)
                      .Select(g => new
                      {
                          g.GradId,
                          g.NazivGrada
                      })
                      .ToList();
                ViewBag.Gradovi = new SelectList(query, nameof(Grad.GradId), nameof(Grad.NazivGrada));
                //return View("NovoSkloniste", s);
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "NovoSkloniste", s) });
            }
        }
        public IActionResult Sklonista(string sortOrder,int pg = 1)
        {
            if (HttpContext.Session.GetInt32("idUloge") == 1)
            {
                var query = ctx.Sklonistes
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
                return View("Sklonista", model);
            }
            else
            {
                return Ok("Nemate pristup ovoj stranici");
            }
            
        }
        public IActionResult DodajAdmina()
        {
            if (HttpContext.Session.GetInt32("idUloge") == 1)
            {
                return View("DodajAdmina");
            }
            else
            {
                return Ok("Nemate pristup ovoj stranici");
            }
                
        }
        public IActionResult Add(Korisnik k)
        {
            
            if (ModelState.IsValid)
            {
                k.UlogaFk = 1;
                ctx.Korisniks.Add(k);
                ctx.SaveChanges();
               /* HttpContext.Session.SetString("imeLogiranogKorisnika", k.Ime);
                HttpContext.Session.SetString("prezimeLogiranogKorisnika", k.Prezime);
                HttpContext.Session.SetInt32("idLogiranogKorisnika", k.KorisnikId);*/
                //return RedirectToAction("PrikazAdmina", "Korisnici");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "DodajAdmina") });

            }
            else
            {
                //return View("DodajAdmina", k);
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "DodajAdmina", k) });
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
            //var query1 = ctx.Sklonistes
            //    .Select(s => new SklonisteViewModel
            //    {
            //        skloniste_id = s.SklonisteId,
            //        NazivSklonista = s.NazivSklonista,
            //        Adresa = s.Adresa,
            //        NazivGrada = s.Grad.NazivGrada,
            //        NazivZupanije = s.Grad.Zupanija.NazivZupanije,
            //        KapacitetSklonista = s.KapacitetSklonista,
            //        Telefon = s.Telefon,
            //        Email = s.Email

            //    })
            //    .ToList();
            //return Json(new { html = Helper.RenderRazorViewToString(this, "Sklonista", query1) });

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
            if (HttpContext.Session.GetInt32("idUloge") == 1)
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
            else
            {
                return Ok("Nemate pristup ovoj stranici");
            }
                
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

                //return RedirectToAction("Sklonista", "Admin");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "SklonisteEdit") });

            }
            else
            {
                var gradovi = ctx.Grads
                      .OrderBy(g => g.NazivGrada)
                      .Select(g => new
                      {
                          g.GradId,
                          g.NazivGrada
                      })
                      .ToList();
                ViewBag.Gradovi = new SelectList(gradovi, nameof(Grad.GradId), nameof(Grad.NazivGrada));

                //return View("SklonisteEdit", s);
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "SklonisteEdit", s) });
            }
        }
        public IActionResult UrediAdmina(int id)
        {
            if (HttpContext.Session.GetInt32("idUloge") == 1)
            {
                var query = ctx.Korisniks
                .Where(k => k.UlogaFk == 1)
                .Where(k => k.KorisnikId == id)
                .FirstOrDefault<Korisnik>();

                return View("AdminsEdit", query);
            }
            else
            {
                return Ok("Nemate pristup ovoj stranici");
            }
                
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

                //return RedirectToAction("PrikazAdmina", "Korisnici");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AdminsEdit") });
            }
            else
            {
                //return View("AdminsEdit", k);
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AdminsEdit", k) });
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
                //return RedirectToAction("PrikazZaposlenika", "Korisnici");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ZaposlenikEdit") });
            }
            else
            {
                //return View("ZaposlenikEdit", k);
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "ZaposlenikEdit", k) });
            }
        }
    }
}
