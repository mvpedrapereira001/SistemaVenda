using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria ServicoCategoria;
        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria )
        {
            ServicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            Categoria Item = new Categoria()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            ServicoCategoria.Cadastrar(Item);
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
           var registro = ServicoCategoria.CarregarRegistro(codigoCategoria);
           CategoriaViewModel categoria = new CategoriaViewModel()
            { 
              Codigo = registro.Codigo,
              Descricao = registro.Descricao
            
            };

            return categoria;
        }

        public void Excluir(int id)
        {
            ServicoCategoria.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaCategoriasDropDownList()
        {

            List<SelectListItem> retorno = new List<SelectListItem>();
            var lista = this.Listagem();
            foreach(var item in lista)
            {
                SelectListItem categoria = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text  = item.Descricao
                };

                retorno.Add(categoria);

            }

            return retorno;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = ServicoCategoria.Lisagem();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();
            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new CategoriaViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };
                listaCategoria.Add(categoria);

            }

            return listaCategoria;
        }
    }
}
