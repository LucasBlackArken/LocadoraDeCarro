using LocadoraDeCarro.Domain.Entities;
using LocadoraDeCarro.Domain.Interfaces;
using LocadoraDeCarro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarro.Domain.Repository;

public class AluguelRepository : IAluguelRepository
{
	private readonly AppDbContext _context;

	public AluguelRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task AddAsync(Aluguel aluguel)
	{
		try
		{
			await _context.Alugueis.AddAsync(aluguel);
			await _context.SaveChangesAsync();
		}
		catch
		{
			throw new Exception("Erro ao alugar Carro");
		}
	}

	public async Task<Aluguel> GetByIdAsync(int id)
	{
		return await _context.Alugueis.Include(a => a.Carro).FirstOrDefaultAsync(a => a.Id == id);
	}

	public async Task<IEnumerable<Aluguel>> ListarTodosAsync()
	{
		return await _context.Alugueis.Include(a => a.Carro).ToListAsync();
	}

	public async Task UpdateAsync(Aluguel aluguel)
	{
		try
		{
			_context.Alugueis.Update(aluguel);
			await _context.SaveChangesAsync();
		}
		catch
		{
			throw new Exception("Erro ao atualizar Aluguel do Carro");
		}
	}
}

