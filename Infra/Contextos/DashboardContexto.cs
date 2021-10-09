using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contextos
{
    public class DashboardContexto : DbContext
    {
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Dashboard.db;");
            optionsBuilder.UseLazyLoadingProxies(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabelas
            modelBuilder.Entity<Encomenda>().ToTable("Encomendas").HasKey(x => x.Id);
            modelBuilder.Entity<Equipe>().ToTable("Equipes").HasKey(x => x.Id);
            modelBuilder.Entity<Pedido>().ToTable("Pedidos").HasKey(x => x.Id);
            modelBuilder.Entity<PedidoProduto>().ToTable("PedidosProdutos").HasKey(x => x.Id);
            modelBuilder.Entity<Produto>().ToTable("Produtos").HasKey(x => x.Id);

            // Relacionamentos
            modelBuilder.Entity<Encomenda>().HasOne(x => x.Pedido).WithMany(y => y.Encomendas).HasForeignKey(x => x.IdPedido);
            modelBuilder.Entity<Encomenda>().HasOne(x => x.Equipe).WithMany(y => y.Encomendas).HasForeignKey(x => x.IdEquipe);

            base.OnModelCreating(modelBuilder);
        }

        public bool Commit()
        {
            return SaveChanges() > 0;
        }
    }
}
