using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using Repositorio.Contexto;

namespace Repositorio.Entidades
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDbContext dbContext) : base(dbContext)
        {
             
        }
    }
}
