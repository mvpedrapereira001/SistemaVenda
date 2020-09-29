﻿using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {

        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public VendaController(
             IServicoAplicacaoVenda servicoAplicacaoVenda,
             IServicoAplicacaoProduto servicoAplicacaoProduto,
             IServicoAplicacaoCliente servicoAplicacaoCliente)


        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.Listagem());
        }
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            if(id!=null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaProdutoDropDownList();

            return View();
        }


        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoVenda.Cadastrar(entidade);

            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
                entidade.ListaProdutos = ServicoAplicacaoProduto.ListaProdutoDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.Excluir(id);
            return RedirectToAction("Index");
        }
        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;

        }
    }
}
 
