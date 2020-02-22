using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudEnfermeiros.Models;
using CrudEnfermeiros.Models.ViewModel;
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

            try
            {
                await _hospitalService.InsertAsync(hospital);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
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

            var obj = await _hospitalService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não informado" }); ;
            }

            var obj = await _hospitalService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não encontrado" }); ;
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Hospital obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if(id != obj.Id)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Incompatibilidade de id" }); ;
            }

            try
            {
                await _hospitalService.UpdateAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { messagem = e.Message }); ;
            }
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não informado" }); ;
            }

            var obj = await _hospitalService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id não encontrado" }); ;
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _hospitalService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { messagem = e.Message }); ;
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