using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}