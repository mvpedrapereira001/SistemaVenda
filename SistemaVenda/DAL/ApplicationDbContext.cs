using Microsoft.EntityFrameworkCore;
using SistemaVenda.Entidades;

namespace SistemaVenda.DAL
{
    public class ApplicationDbContext: DbContext 
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendasProdutos> VendasProdutos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VendasProdutos>().HasKey(x => new { x.CodigoDaVenda, x.CodigoProduto });

            builder.Entity<VendasProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.CodigoDaVenda);

            builder.Entity<VendasProdutos>()
               .HasOne(x => x.Produto)
               .WithMany(y => y.Vendas)
               .HasForeignKey(x => x.CodigoProduto);

        }

    }
}
