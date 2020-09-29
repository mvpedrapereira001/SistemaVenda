using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaVenda.Entidades
{
    public class VendasProdutos  
    {
        public int CodigoDaVenda { get; set; }
        public int CodigoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }


    }
}
