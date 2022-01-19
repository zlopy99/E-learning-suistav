using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment hostingEnvironment;

        public PrijavaZivotinjaController(LutaliceInfoSustavContext ctx, IHostingEnvironment environment)
        {
            this.ctx = ctx;
            hostingEnvironment = environment;
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
        public IActionResult Spremi(UoceneLutalice ul)
        {
            /*if (ModelState.IsValid)
            {
                string wwwRootPath = hostingEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(ul.Slika);
                string extension = 
            }*/
            
            ul.DatumPrijave = DateTime.Now;
            ctx.UoceneLutalices.Add(ul);
            ctx.SaveChanges();
            return Ok(ul.Slika);

        }
    }
}
