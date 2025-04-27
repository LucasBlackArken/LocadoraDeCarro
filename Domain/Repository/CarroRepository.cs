using LocadoraDeCarro.Domain.Entities;
using LocadoraDeCarro.Domain.Interfaces;
using LocadoraDeCarro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarro.Domain.Repository;

public class CarroRepository : ICarroRepository
{
	private readonly AppDbContext _context;

	public CarroRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task AddAsync(Carro carro)
	{
		try
		{
			await _context.Carros.AddAsync(carro);
			await _context.SaveChangesAsync();
		}
		catch
		{
			throw new Exception("Erro ao adicionar o novo Carro");
		}
	}

	public async Task<Carro> GetByIdAsync(int id)
	{
		return await _context.Carros.FindAsync(id);
	}

	public async Task<IEnumerable<Carro>> ListarDisponiveisAsync()
	{
		return await _context.Carros.Where(c => c.Disponivel).ToListAsync();
	}

	public async Task<IEnumerable<Carro>> ListarAlugadosAsync()
	{
		return await _context.Carros.Where(c => !c.Disponivel).ToListAsync();
	}

	public async Task UpdateAsync(Carro carro)
	{
		try
		{
			_context.Carros.Update(carro);
			await _context.SaveChangesAsync();
		}
		catch
		{
			throw new Exception("Erro ao atualizar o cadastro de Carro");
		}
	}
}

