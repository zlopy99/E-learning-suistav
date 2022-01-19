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
    }
}
