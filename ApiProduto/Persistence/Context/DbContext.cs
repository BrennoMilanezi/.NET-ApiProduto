using Microsoft.EntityFrameworkCore;
using ApiProduto.Entities;
using ApiProduto.Persistence.ModelConfig;

namespace ApiProduto.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProdutoConfig());
    }
}