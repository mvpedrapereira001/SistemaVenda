﻿using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class ClienteController : Controller
    {
        
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
          
            return View(ServicoAplicacaoCliente.Listagem());
        }
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();
            if(id!=null)
            {
                viewModel = ServicoAplicacaoCliente.CarregarRegistro((int)id);
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCliente.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoCliente.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
 
