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
                if (query.UlogaFk == 1)
                {
                    
                    return RedirectToAction("Sklonista", "Admin");
                }
                else if(query.UlogaFk == 2)
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
            return RedirectToAction("Index");
        }
    }
    

    
    
}
