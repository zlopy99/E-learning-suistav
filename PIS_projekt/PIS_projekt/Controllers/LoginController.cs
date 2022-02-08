using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS_projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Controllers
{
    public class LoginController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        public LoginController(LutaliceInfoSustavContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            return View("Prijava");
        }
        public IActionResult Prijava(Korisnik k)
        {
            /*if (ModelState.IsValid)
            {*/
            var query = ctx.Korisniks
            .Where(q => q.Email == k.Email)
            .Where(q => q.Lozinka == k.Lozinka)
            .FirstOrDefault<Korisnik>();


            if (query != null)
            {
                HttpContext.Session.SetString("imeLogiranogKorisnika", query.Ime);
                HttpContext.Session.SetString("prezimeLogiranogKorisnika", query.Prezime);
                HttpContext.Session.SetInt32("idLogiranogKorisnika", query.KorisnikId);
                HttpContext.Session.SetInt32("idUloge", query.UlogaFk);
                if (query.UlogaFk == 1)
                {

                    return RedirectToAction("Sklonista", "Admin");
                }
                else if (query.UlogaFk == 2)
                {

                    return RedirectToAction("ZivotinjeUSklonistu", "Zivotinje");
                }
                else
                {
                    return Ok("korinisk");
                }
            }
            else
            {
                return View("Prijava", k);
            }
        }
        /*else
        {
            return View("Prijava",k);
        }*/
        public IActionResult Odjava()
        {
            HttpContext.Session.Remove("imeLogiranogKorisnika");
            HttpContext.Session.Remove("prezimeLogiranogKorisnika");
            HttpContext.Session.Remove("idLogiranogKorisnika");
            HttpContext.Session.Remove("idUloge");
            return RedirectToAction("Index");
        }
        public IActionResult ProfilZaposlenik(int id)
        {
            var query = ctx.Korisniks
                .Where(k => k.KorisnikId == id)
                .Where(k=>k.UlogaFk == 2)
                .FirstOrDefault<Korisnik>();
            return View("Profil",query);
        }
        public IActionResult ProfilAdmin(int id)
        {
            var query = ctx.Korisniks
                .Where(k => k.KorisnikId == id)
                .Where(k => k.UlogaFk == 1)
                .FirstOrDefault<Korisnik>();
            return View("ProfilAdmin", query);
        }
        public IActionResult UrediProfilZaposlenik(Korisnik k)
        {
            k.UlogaFk = 2;
            if (ModelState.IsValid)
            {
                Korisnik zaposlenik = ctx.Korisniks.Find(k.KorisnikId);
                zaposlenik.Ime = k.Ime;
                ctx.SaveChanges();
                zaposlenik.Prezime = k.Prezime;
                ctx.SaveChanges();
                zaposlenik.Email = k.Email;
                ctx.SaveChanges();
                zaposlenik.Lozinka = k.Lozinka;
                ctx.SaveChanges();
                return RedirectToAction("ZivotinjeUSklonistu", "Zivotinje");
            }
            else
            {
                return View("Profil", k);
            }
        }
        public IActionResult UrediProfilAdmin(Korisnik k)
        {
            k.UlogaFk = 1;
            if (ModelState.IsValid)
            {
                Korisnik zaposlenik = ctx.Korisniks.Find(k.KorisnikId);
                zaposlenik.Ime = k.Ime;
                ctx.SaveChanges();
                zaposlenik.Prezime = k.Prezime;
                ctx.SaveChanges();
                zaposlenik.Email = k.Email;
                ctx.SaveChanges();
                zaposlenik.Lozinka = k.Lozinka;
                ctx.SaveChanges();
                return RedirectToAction("Sklonista", "Admin");
            }
            else
            {
                return View("ProfilAdmin", k);
            }
        }
    }
    

    
    
}
