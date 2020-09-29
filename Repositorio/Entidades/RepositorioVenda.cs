using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using Repositorio.Contexto;

namespace Repositorio.Entidades
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext)
        {
             
        }
    }
}
