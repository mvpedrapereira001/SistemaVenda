using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Newtonsoft.Json;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda ServicoVenda;
        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel venda)
        {
            Venda Item = new Venda()
            {
                Codigo = venda.Codigo,
                Data = (DateTime) venda.Data,
                CodigoCliente = (int)venda.CodigoCliente,
                Total = venda.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendasProdutos>>(venda.JsonProdutos)
            };

            ServicoVenda.Cadastrar(Item);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
           var registro = ServicoVenda.CarregarRegistro(codigoVenda);
            VendaViewModel venda = new VendaViewModel()
            {
                Codigo = registro.Codigo,
                Data = (DateTime)registro.Data,
                CodigoCliente = (int)registro.CodigoCliente,
                Total = registro.Total

            };

            return venda;
        }

        public void Excluir(int id)
        {
            ServicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            var lista = ServicoVenda.Lisagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();


            foreach (var item in lista)
            {
                VendaViewModel venda = new VendaViewModel()
                {
                    Codigo = item.Codigo,
                    Data = (DateTime)item.Data,
                    CodigoCliente = (int)item.CodigoCliente,
                    Total = item.Total

                };
                listaVenda.Add(venda);
            }
            return listaVenda;
        }
    }
}
