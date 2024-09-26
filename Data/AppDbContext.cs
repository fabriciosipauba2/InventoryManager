using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18, 2)"); // Define a precisão e escala do decimal

            base.OnModelCreating(modelBuilder);
        }
    }

}
