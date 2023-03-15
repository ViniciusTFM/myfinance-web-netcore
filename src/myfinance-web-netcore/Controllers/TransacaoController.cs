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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;

        public TransacaoController(
            ILogger<TransacaoController> logger,
            ITransacaoService transacaoService,
            IPlanoContaService planoContaService
        )
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListaTransacao = _transacaoService.ListarRegistros();

            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            var model = new TransacaoModel();

            if (id != null)
            {
                model = _transacaoService.RetornarRegistro((int)id);
            }

            var lista = _planoContaService.ListarRegistros();
            model.PlanoConta = new SelectList(lista, "Id", "Descricao");

            return View(model);
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(TransacaoModel Transacao)
        {
            _transacaoService.Salvar(Transacao);
            return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _transacaoService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
