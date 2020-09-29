using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using Repositorio.Contexto;

namespace Repositorio.Entidades
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext dbContext) : base(dbContext)
        {
             
        }
    }
}
