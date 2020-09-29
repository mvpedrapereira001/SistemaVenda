using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class ProdutoViewModel
    {
        
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe Descrição do produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Quanditade em Estoque do Produto")]
        public decimal Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o valor unitário do produto")]
         
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe a catogoria do produto")]
        public int? CodigoCategoria { get; set; }

        public Categoria Categoria { get; set; }
        public IEnumerable<SelectListItem> ListaCategoria { get; set; }

        public  string DescricaoCategoria { get; set; }

    }
}
