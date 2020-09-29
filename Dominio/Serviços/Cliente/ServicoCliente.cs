using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ServicoCliente : IServicoCliente
    {
        IRepositorioCliente RepositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            RepositorioCliente = repositorioCliente;
        }
        public void Cadastrar(Cliente cliente)
        {
            RepositorioCliente.Create(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return RepositorioCliente.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioCliente.Delete(id);
        }

        public IEnumerable<Cliente> Lisagem()
        {
            return RepositorioCliente.Read();
        }
    }
}
