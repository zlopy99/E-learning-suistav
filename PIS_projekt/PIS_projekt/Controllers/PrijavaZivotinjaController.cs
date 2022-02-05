using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS_projekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Controllers
{
    public class PrijavaZivotinjaController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PrijavaZivotinjaController(LutaliceInfoSustavContext ctx, IWebHostEnvironment webHostEnvironment)
        {
            this.ctx = ctx;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
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
            return View("UocenaLutalica");
        }
        public async Task<IActionResult> SpremiAsync(UoceneLutalice ul)
        {
            /*if (ModelState.IsValid)
            {
                string wwwRootPath = hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(ul.Slika);
                string extension = 
            }*/
            if (ModelState.IsValid)
            {
                if (ul.Photo != null)
                {
                    var guid = Guid.NewGuid().ToString();
                    var new_guid = guid.Substring(0, 5); 

                    string folder = "images/";
                    folder += new_guid + "_" + ul.Photo.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await ul.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); ;

                    var spliting = folder.Split('/');
                    ul.Slika = spliting[1];
                }

                ul.DatumPrijave = DateTime.Now;
                ctx.UoceneLutalices.Add(ul);
                ctx.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View("UocenaLutalica", ul);
            }
            
        }
        public IActionResult IzgubljenLjubimac()
        {
            var spolovi = ctx.Spols
                .Select(s => new
                {
                    s.SpolId,
                    s.NazivSpola
                })
                .ToList();
            ViewBag.Spolovi = new SelectList(spolovi, nameof(Spol.SpolId), nameof(Spol.NazivSpola));

            var gradovi = ctx.Grads
                .OrderBy(g => g.NazivGrada)
                .Select(g => new
                {
                    g.GradId,
                    g.NazivGrada

                })
                .ToList();
            ViewBag.Gradovi = new SelectList(gradovi, nameof(Grad.GradId), nameof(Grad.NazivGrada));

            var kastrat = ctx.Kastrats
                    .Select(k => new
                    {
                        k.KastratId,
                        k.JeLiKastrat
                    })
                    .ToList();
            ViewBag.Kastrat = new SelectList(kastrat, nameof(Kastrat.KastratId), nameof(Kastrat.JeLiKastrat));

            var pasmine = ctx.Pasminas
                .OrderBy(p=>p.NazivPasmine)
                .Select(p => new
                {
                    p.PasminaId,
                    p.NazivPasmine
                })
                .ToList();
            ViewBag.Pasmine = new SelectList(pasmine, nameof(Pasmina.PasminaId), nameof(Pasmina.NazivPasmine));

            var vrste = ctx.VrstaZivotinjes
                .OrderBy(v => v.NazivVrste)
                .Select(v => new
                {
                    v.VrstaZivotinjeId,
                    v.NazivVrste
                })
                .ToList();
            ViewBag.Vrste = new SelectList(vrste, nameof(VrstaZivotinje.VrstaZivotinjeId), nameof(VrstaZivotinje.NazivVrste));
            return View("IzgubiliSteLjubimca");
        }
        public async Task<IActionResult> SpremiPrijavuAsync(IzgubljeneZivotinje iz)
        {
            if (ModelState.IsValid)
            {
                if (iz.Photo != null)
                {
                    var guid = Guid.NewGuid().ToString();
                    var new_guid = guid.Substring(0, 5);

                    string folder = "images/";
                    folder += new_guid + "_" + iz.Photo.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await iz.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); ;

                    var spliting = folder.Split('/');
                    iz.Slika = spliting[1];
                }

                iz.DatumPrijave = DateTime.Now;
                ctx.IzgubljeneZivotinjes.Add(iz);
                ctx.SaveChanges();
                Console.WriteLine("ok");
                return RedirectToAction("Izgubljene", "Zivotinje");
            }
            else
            {
                return View("IzgubiliSteLjubimca", iz);
            }
        }
        public IActionResult Prijavljene()
        {
            var zaposlenik = ctx.Korisniks
                .Where(k => k.UlogaFk == 2)
                .Where(k => k.KorisnikId == HttpContext.Session.GetInt32("idLogiranogKorisnika"))
                .FirstOrDefault<Korisnik>();
            var query = ctx.UoceneLutalices
                 .Where(u => u.GradId == zaposlenik.Skloniste.GradId)
                 .ToList();
            return Ok("Ok");

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
