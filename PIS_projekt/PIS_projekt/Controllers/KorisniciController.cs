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
        public IActionResult PrikazAdmina()
        {
            var query = ctx.Korisniks
                   .Where(k => k.UlogaFk == 1)
                   .OrderBy(k => k.Prezime)
                   .ToList();
            
            return View("Admini",query);
            
        }
        public IActionResult PrikazZaposlenika(int pg=1)
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
                    string folder = "images/";
                    folder += zus.BrojMikrocipa.ToString() + "_" + zus.Photo.FileName;
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
    }
}
