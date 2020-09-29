using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto ServicoProduto;
        public ServicoAplicacaoProduto(IServicoProduto servicoProduto )
        {
            ServicoProduto = servicoProduto;
        }

        public void Cadastrar(ProdutoViewModel produto)
        {
            Produto Item = new Produto()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor = produto.Valor,
                CodigoCategoria = (int)produto.CodigoCategoria

            };

            ServicoProduto.Cadastrar(Item);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
           var registro = ServicoProduto.CarregarRegistro(codigoProduto);
            ProdutoViewModel produto = new ProdutoViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = registro.Valor,
                CodigoCategoria = (int)registro.CodigoCategoria 

            };

            return produto;
        }

        public void Excluir(int id)
        {
            ServicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = ServicoProduto.Lisagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();
            foreach (var item in lista)
            {
                ProdutoViewModel categoria = new ProdutoViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    Valor = item.Valor,
                    CodigoCategoria = (int)item.CodigoCategoria,
                    DescricaoCategoria = item.Categoria.Descricao
                   
                };
                listaProduto.Add(categoria);

            }

            return listaProduto;
        }
        public IEnumerable<SelectListItem> ListaProdutoDropDownList()
        {

            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };

                retorno.Add(produto);

            }

            return retorno;
        }
    }
}
