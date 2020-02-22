using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudEnfermeiros.Models;
using CrudEnfermeiros.Models.ViewModel;
using CrudEnfermeiros.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudEnfermeiros.Controllers
{
    public class EnfermeirosController : Controller
    {
        public EnfermeiroService _enfermeiroService { get; set; }
        public HospitalService _hospitalService { get; set; }

        public EnfermeirosController(EnfermeiroService enfermeiroService, HospitalService hospitalService)
        {
            _enfermeiroService = enfermeiroService;
            _hospitalService = hospitalService;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _enfermeiroService.FindAllAsync();
            return View(obj);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Enfermeiro obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            try
            {
                await _enfermeiroService.InsertAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { messagem = e.Message });
            }
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não informado" });
            }

            var obj = await _enfermeiroService.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não informado" });
            }

            var obj = await _enfermeiroService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _enfermeiroService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { messagem = e.Message });
            }
        }

        public IActionResult Error(string messagem)
        {
            var viewModel = new ErrorViewModel
            {
                Message = messagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}