

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_projekt.Models;
using PIS_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly LutaliceInfoSustavContext ctx;
        public HomeController(LutaliceInfoSustavContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
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
            var model = new SklonisteVM
            {
                skloniste = query
            };
            return View("Index", model);
            // return Ok(query);
        }
    }
}
