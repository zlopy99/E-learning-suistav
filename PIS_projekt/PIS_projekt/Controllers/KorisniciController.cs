using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS_projekt.Models;
using PIS_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace PIS_projekt.Controllers
{
    public class KorisniciController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public KorisniciController(LutaliceInfoSustavContext ctx, IWebHostEnvironment webHostEnvironment)
        {
            this.ctx = ctx;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult PrikazAdmina(string sortOrder)
        {
            var query = ctx.Korisniks
                   .Where(k => k.UlogaFk == 1)
                   .OrderBy(k => k.Prezime)
                   .ToList();

            ViewData["PrezimeOrder"] = string.IsNullOrEmpty(sortOrder) ? "Prezime_desc" : "";
            ViewData["ImeOrder"] = sortOrder == "Ime" ? "Ime_desc" : "Ime";

            switch (sortOrder)
            {
                case "Ime":
                    query = ctx.Korisniks
                       .Where(k => k.UlogaFk == 1)
                       .OrderBy(k => k.Ime)
                       .ToList();
                    break;
                case "Ime_desc":
                    query = ctx.Korisniks
                       .Where(k => k.UlogaFk == 1)
                       .OrderByDescending(k => k.Ime)
                       .ToList();
                    break;
                case "Prezime_desc":
                    query = ctx.Korisniks
                       .Where(k => k.UlogaFk == 1)
                       .OrderByDescending(k => k.Prezime)
                       .ToList();
                    break;
                default:
                    query = ctx.Korisniks
                       .Where(k => k.UlogaFk == 1)
                       .OrderBy(k => k.Prezime)
                       .ToList();
                    break;
            }
            return View("Admini",query);
            
        }
        public IActionResult PrikazZaposlenika(string sortOrder,int pg=1)
        {
            var query = ctx.Korisniks
                .Where(k => k.UlogaFk == 2)
                .Select(k => new ZaposleniciViewModel
                {
                    KorisnikId = k.KorisnikId,
                    SklonisteId = (int)k.SklonisteFk,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    Email = k.Email,
                    Lozinka = k.Lozinka,
                    NazivSklonista = k.Skloniste.NazivSklonista,
                    Grad = k.Skloniste.Grad.NazivGrada

                })
                .OrderBy(k=>k.Prezime)
                .ToList();

            ViewData["NazivSklonistaOrder"] = string.IsNullOrEmpty(sortOrder) ? "NazivSklonista_desc" : "";
            ViewData["GradOrder"] = sortOrder == "Grad" ? "Grad_desc" : "Grad";
            ViewData["ImeOrder"] = sortOrder == "Ime" ? "Ime_desc" : "Ime";
            ViewData["PrezimeOrder"] = sortOrder == "Prezime" ? "Prezime_desc" : "Prezime";

            switch (sortOrder)
            {
                case "Prezime":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderBy(k => k.Prezime)
                        .ToList();
                    ViewBag.CurrentSort = "Prezime";
                    break;
                case "Prezime_desc":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderByDescending(k => k.Prezime)
                        .ToList();
                    ViewBag.CurrentSort = "Prezime_desc";
                    break;

                case "Ime":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderBy(k => k.Ime)
                        .ToList();
                    ViewBag.CurrentSort = "Ime";
                    break;
                case "Ime_desc":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderByDescending(k => k.Ime)
                        .ToList();
                    ViewBag.CurrentSort = "Ime_desc";
                    break;

                case "Grad":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderBy(k => k.Grad)
                        .ToList();
                    ViewBag.CurrentSort = "Grad";
                    break;
                case "Grad_desc":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderByDescending(k => k.Grad)
                        .ToList();
                    ViewBag.CurrentSort = "Grad_desc";
                    break;

                case "NazivSklonista_desc":
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderByDescending(k => k.NazivSklonista)
                        .ToList();
                    ViewBag.CurrentSort = "NazivSklonista_desc";
                    break;
                default:
                    query = ctx.Korisniks
                        .Where(k => k.UlogaFk == 2)
                        .Select(k => new ZaposleniciViewModel
                        {
                            KorisnikId = k.KorisnikId,
                            SklonisteId = (int)k.SklonisteFk,
                            Ime = k.Ime,
                            Prezime = k.Prezime,
                            Email = k.Email,
                            Lozinka = k.Lozinka,
                            NazivSklonista = k.Skloniste.NazivSklonista,
                            Grad = k.Skloniste.Grad.NazivGrada

                        })
                        .OrderBy(k => k.NazivSklonista)
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

            

            var model = new ZaposleniciVM
            {
                zaposlenici = data
            };
            this.ViewBag.Pager = pager;

            return View("Korisnici", model);
            
        }
       public IActionResult DodajZaposlenika()
        {
            var query = ctx.Sklonistes
                      .OrderBy(s => s.NazivSklonista)
                      .Select(s => new
                      {
                          s.SklonisteId,
                          s.NazivSklonista
                      })
                      .ToList();
            ViewBag.Sklonista = new SelectList(query, nameof(Skloniste.SklonisteId), nameof(Skloniste.NazivSklonista));
            return View("DodajKorisnika");
        }
        public IActionResult Add(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                k.UlogaFk = 2;
                ctx.Korisniks.Add(k);
                ctx.SaveChanges();
                return RedirectToAction("PrikazZaposlenika","Korisnici");
            }
            else
            {
                return View("DodajKorisnika",k);
            }
            

        }
        public IActionResult DodavanjeZivotinje()
        {
            var pasmina = ctx.Pasminas
                      .OrderBy(s => s.NazivPasmine)
                      .Select(s => new
                      {
                          s.PasminaId,
                          s.NazivPasmine
                      })
                      .ToList();
            ViewBag.Pasmine = new SelectList(pasmina, nameof(Pasmina.PasminaId), nameof(Pasmina.NazivPasmine));
            var spolovi = ctx.Spols
                .Select(s => new
                {
                    s.SpolId,
                    s.NazivSpola
                })
                .ToList();
            ViewBag.Spolovi = new SelectList(spolovi, nameof(Spol.SpolId), nameof(Spol.NazivSpola));

            var udomljavanje = ctx.Udomljavanjes
                .OrderBy(g => g.JeLiZaUdomljavanje)
                .Select(g => new
                {
                    g.UdomljavanjeId,
                    g.JeLiZaUdomljavanje

                })
                .ToList();
            ViewBag.Udomljavanje = new SelectList(udomljavanje, nameof(Udomljavanje.UdomljavanjeId), nameof(Udomljavanje.JeLiZaUdomljavanje));

            var kastrat = ctx.Kastrats
                    .Select(k => new
                    {
                        k.KastratId,
                        k.JeLiKastrat
                    })
                    .ToList();
            ViewBag.Kastrat = new SelectList(kastrat, nameof(Kastrat.KastratId), nameof(Kastrat.JeLiKastrat));
            return View("DodavanjeZivotinje");
        }
        /*public IActionResult DodajZivotinju(ZivotinjaUSklonistu zus)*/
        /*public async Task<IActionResult> DodajZivotinjuAsync(ZivotinjaUSklonistu zus)*/
        public async Task<IActionResult> DodajZivotinjuAsync(ZivotinjaUSklonistu zus)
        {
            var zaposlenik = ctx.Korisniks
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .FirstOrDefault<Korisnik>();
            zus.SklonisteId = (int)zaposlenik.SklonisteFk;
            
            /*  Photo upload  */
            //  Guid.NewGuid().ToString() --> Random generira neki niz brojeva i slova,
            //  uglavnom ovo se može stavit kod slike da budu sve različite
            if (ModelState.IsValid)
            {
                if(zus.Photo != null)
                {
                    var guid = Guid.NewGuid().ToString();
                    var new_guid = guid.Substring(0, 5);

                    string folder = "images/";
                    folder += new_guid + "_" + zus.Photo.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await zus.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); ;

                    var spliting = folder.Split('/');
                    zus.Slika = spliting[1];
                }
                ctx.ZivotinjaUSklonistus.Add(zus);
                ctx.SaveChanges();
                return RedirectToAction("ZivotinjeUSklonistu", "Zivotinje");
            }
            else
            {
                return View("DodavanjeZivotinje", zus);
            }
        }
        public IActionResult IzbrisiZivotinju(int id)
        {
            var zaposlenik = ctx.Korisniks
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .FirstOrDefault<Korisnik>();

            var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.ZivotinjaUSklonistuId == id)
                .Where(z => z.SklonisteId == zaposlenik.SklonisteFk)
                .FirstOrDefault<ZivotinjaUSklonistu>();
            ctx.ZivotinjaUSklonistus.Remove(query);
            ctx.SaveChanges();
            return RedirectToAction("ZivotinjeUSklonistu", "Zivotinje");
        }
        public IActionResult Uredi(int id)
        {
            var query = ctx.ZivotinjaUSklonistus
                .Where(z => z.ZivotinjaUSklonistuId == id)
                .FirstOrDefault<ZivotinjaUSklonistu>();

            var pasmina = ctx.Pasminas
                      .OrderBy(s => s.NazivPasmine)
                      .Select(s => new
                      {
                          s.PasminaId,
                          s.NazivPasmine
                      })
                      .ToList();
            ViewBag.Pasmine = new SelectList(pasmina, nameof(Pasmina.PasminaId), nameof(Pasmina.NazivPasmine));
            var spolovi = ctx.Spols
                .Select(s => new
                {
                    s.SpolId,
                    s.NazivSpola
                })
                .ToList();
            ViewBag.Spolovi = new SelectList(spolovi, nameof(Spol.SpolId), nameof(Spol.NazivSpola));

            var udomljavanje = ctx.Udomljavanjes
                .OrderBy(g => g.JeLiZaUdomljavanje)
                .Select(g => new
                {
                    g.UdomljavanjeId,
                    g.JeLiZaUdomljavanje

                })
                .ToList();
            ViewBag.Udomljavanje = new SelectList(udomljavanje, nameof(Udomljavanje.UdomljavanjeId), nameof(Udomljavanje.JeLiZaUdomljavanje));

            var kastrat = ctx.Kastrats
                    .Select(k => new
                    {
                        k.KastratId,
                        k.JeLiKastrat
                    })
                    .ToList();
            ViewBag.Kastrat = new SelectList(kastrat, nameof(Kastrat.KastratId), nameof(Kastrat.JeLiKastrat));

            return View("EditZivotinje",query);
        }
        public IActionResult UrediZivotinju(ZivotinjaUSklonistu zuv)
        {
            var zaposlenik = ctx.Korisniks
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .Where(k=>k.UlogaFk==2)
                .FirstOrDefault<Korisnik>();
            zuv.SklonisteId = (int)zaposlenik.SklonisteFk;
            if (ModelState.IsValid)
            {
                ZivotinjaUSklonistu zuvEdit = ctx.ZivotinjaUSklonistus.Find(zuv.ZivotinjaUSklonistuId);
                zuvEdit.BrojMikrocipa = zuv.BrojMikrocipa;
                ctx.SaveChanges();
                zuvEdit.ImeZivotinje = zuv.ImeZivotinje;
                ctx.SaveChanges();
                zuvEdit.PasminaId = zuv.PasminaId;
                ctx.SaveChanges();
                zuvEdit.SpolId = zuv.SpolId;
                ctx.SaveChanges();
                zuvEdit.KastratId = zuv.KastratId;
                ctx.SaveChanges();
                zuvEdit.UdomljavanjeId = zuv.UdomljavanjeId;
                ctx.SaveChanges();
                zuvEdit.DatumStenjenja = zuv.DatumStenjenja;
                ctx.SaveChanges();
                zuvEdit.Slika = zuv.Slika;
                ctx.SaveChanges();
                zuvEdit.DatumPronalaska = zuv.DatumPronalaska;
                ctx.SaveChanges();
                zuvEdit.AdresaPronalaska = zuv.AdresaPronalaska;
                ctx.SaveChanges();
                zuvEdit.Opis = zuv.Opis;
                ctx.SaveChanges();
                return RedirectToAction("ZivotinjeUSklonistu", "Zivotinje");
            }
            else
            {
                return View("EditZivotinje", zuv);
            }
        }
        public IActionResult IzbrisiUocenuLutalicu(int id)
        {
            var query = ctx.UoceneLutalices
                .Where(ul => ul.UoceneLutaliceId == id)
                .FirstOrDefault<UoceneLutalice>();
            ctx.UoceneLutalices.Remove(query);
            ctx.SaveChanges();
            return RedirectToAction("UoceneLutalice", "Zivotinje");
        }


    }
}
