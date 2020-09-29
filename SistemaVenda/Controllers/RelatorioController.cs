using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SistemaVenda.DAL;
using SistemaVenda.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected ApplicationDbContext mContext;

        public RelatorioController(ApplicationDbContext context)
        {
            mContext = context;
        }
        public IActionResult Grafico()
        {
            var lista = mContext.VendasProdutos
                .GroupBy(x => x.CodigoProduto)
                .Select(y => new GraficoViewModel
                {
                  CodigoProduto = y.First().CodigoProduto,
                  Descricao = y.First().Produto.Descricao,
                  TotalVendido = y.Sum(z=> z.Quantidade)

                }).ToList();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var ramdom = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", ramdom.Next(0x10000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;


            return View();
        }
    }
}
