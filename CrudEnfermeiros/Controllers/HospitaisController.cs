using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudEnfermeiros.Models;
using CrudEnfermeiros.Services;
using CrudEnfermeiros.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CrudEnfermeiros.Controllers
{
    public class HospitaisController : Controller
    {
        public HospitalService _hospitalService;

        public HospitaisController(HospitalService service)
        {
            _hospitalService = service;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _hospitalService.FindAllAsync());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return View(hospital);
            }

            await _hospitalService.Insert(hospital);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = await _hospitalService.FindByIdasync(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}