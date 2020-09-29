﻿using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ServicoProduto : IServicoProduto
    {
        IRepositorioProduto RepositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            RepositorioProduto = repositorioProduto;
        }
        public void Cadastrar(Produto produto)
        {
            RepositorioProduto.Create(produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return RepositorioProduto.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioProduto.Delete(id);
        }

        public IEnumerable<Produto> Lisagem()
        {
            return RepositorioProduto.Read();
        }
    }
}
