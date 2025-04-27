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

		//// Configuração da entidade Aluguel
		//modelBuilder.Entity<Aluguel>(entity =>
		//{
		//	entity.ToTable("Aluguel"); // Nome da tabela
		//	entity.HasKey(a => a.IdAluguel); // Define a chave primária
		//	entity.Property(a => a.ValorAluguel).HasColumnType("decimal(18,2)"); // Configura o tipo decimal
		//	entity.Property(a => a.DataRetirada).IsRequired(); // Define que a DataRetirada é obrigatória
		//	entity.Property(a => a.DataEntrega).IsRequired(); // Define que a DataEntrega é obrigatória
		//	entity.Property(a => a.Atraso).IsRequired(); // Define que o campo Atraso é obrigatório
		//	entity.Property(a => a.TaxaAtraso).HasColumnType("decimal(18,2)"); // Configura o tipo decimal
		//});

		//// Configuração da entidade Carro
		//modelBuilder.Entity<Carro>(entity =>
		//{
		//	entity.ToTable("Carros"); // Nome da tabela
		//	entity.HasKey(c => c.IdCarro); // Define a chave primária
		//	entity.Property(c => c.Marca).HasMaxLength(50); // Limite de 50 caracteres para a marca
		//	entity.Property(c => c.Modelo).HasMaxLength(50); // Limite de 50 caracteres para o modelo
		//	entity.Property(c => c.Placa).HasMaxLength(8); // Limite de 8 caracteres para a placa
		//	entity.Property(c => c.Ano).IsRequired(); // Define que o campo Ano é obrigatório
		//	entity.Property(c => c.Disponivel).IsRequired(); // Define que o campo Disponivel é obrigatório
		//});

		// Relacionamento entre Aluguel e Carro
		modelBuilder.Entity<Aluguel>()
				.HasOne<Carro>()
				.WithMany()
				.HasForeignKey("IdCarro") // Define a chave estrangeira na tabela Alugueis
				.OnDelete(DeleteBehavior.Cascade); // Define que ao excluir um carro, os alugueis relacionados serão excluídos
	}
}

