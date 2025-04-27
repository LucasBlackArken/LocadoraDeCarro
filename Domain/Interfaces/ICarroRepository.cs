using LocadoraDeCarro.Domain.Entities;

namespace LocadoraDeCarro.Domain.Interfaces;

public interface ICarroRepository
{
	Task<Carro> GetByIdAsync(int id);
	Task<IEnumerable<Carro>> ListarDisponiveisAsync();
	Task<IEnumerable<Carro>> ListarAlugadosAsync();
	Task AddAsync(Carro carro);
	Task UpdateAsync(Carro carro);
}
