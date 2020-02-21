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
    }
}