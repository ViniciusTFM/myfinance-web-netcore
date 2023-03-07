using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Domain.Services.Interfaces;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(
            ILogger<PlanoContaController> logger,
            IPlanoContaService planoContaService
        )
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            /* ViewBag - Envia dados para a action */
            ViewBag.ListaPlanoConta = _planoContaService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            if (id != null)
            {
                var registro = _planoContaService.RetornarRegistro((int)id);
                return View(registro);
            }
            return View();
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(PlanoContaModel PlanoConta)
        {
            _planoContaService.Salvar(PlanoConta);
            return RedirectToAction("Index");
        }
    }
}
