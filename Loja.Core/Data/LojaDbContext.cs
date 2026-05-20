using Loja.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Core.Data
{
    public class LojaDbContext : DbContext
    {
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Produto> Produtos => Set<Produto>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                Environment.GetEnvironmentVariable(
                    "ConnectionStrings__DefaultConnection"
                    )
            );

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCategoria = modelBuilder.Entity<Categoria>();
            var modelProduto = modelBuilder.Entity<Produto>();

            modelCategoria.ToTable("categorias");

            modelCategoria.Property(e => e.Id).HasColumnName("id");
            modelCategoria.Property(e => e.Nome).HasColumnName("nome");
            modelCategoria.HasKey(e => e.Id);

            modelProduto.ToTable("produtos");
            modelProduto.Property(e => e.Id).HasColumnName("id");
            modelProduto.Property(e => e.Nome).HasColumnName("nome");
            modelProduto.Property(e => e.Preco).HasColumnName("preco");
            modelProduto
                .HasOne(e => e.Categoria)
                .WithMany()
                .HasForeignKey("categoriaid");
            modelProduto.HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
