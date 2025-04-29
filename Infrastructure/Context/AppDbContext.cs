using LocadoraDeCarro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarro.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Aluguel> Alugueis { get; set; }
    public DbSet<Carro> Carros { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da entidade Carro
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.ToTable("Carros");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Marca)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.Modelo)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.Ano)
                  .IsRequired();

            entity.Property(c => c.ValorDiaria)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)"); // Compatível com SQL Server

            entity.Property(c => c.Disponivel)
                  .IsRequired();

            entity.HasMany(c => c.Alugueis)
                  .WithOne(a => a.Carro)
                  .HasForeignKey(a => a.CarroId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuração da entidade Aluguel
        modelBuilder.Entity<Aluguel>(entity =>
        {
            entity.ToTable("Alugueis");

            entity.HasKey(a => a.Id);

            entity.Property(a => a.DataInicio)
                  .IsRequired();

            entity.Property(a => a.DataFim)
                  .IsRequired();

            entity.Property(a => a.Devolvido)
                  .IsRequired();

            entity.Property(a => a.ValorTotal)
                  .HasColumnType("decimal(18,2)");

            entity.Property(a => a.TaxaAtraso)
                  .HasColumnType("decimal(18,2)");
        });
    }
}
