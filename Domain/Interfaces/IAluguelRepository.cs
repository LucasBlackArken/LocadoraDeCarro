using LocadoraDeCarro.Domain.Entities;

namespace LocadoraDeCarro.Domain.Interfaces;

public interface IAluguelRepository
{
	Task<Aluguel> GetByIdAsync(int id);
	Task<IEnumerable<Aluguel>> ListarTodosAsync();
	Task AddAsync(Aluguel aluguel);
	Task UpdateAsync(Aluguel aluguel);
}