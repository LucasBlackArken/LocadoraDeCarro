using LocadoraDeCarro.Application.Query.Carro;
using LocadoraDeCarro.Domain.DTO;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Carro;

public class ListarCarrosAlugadosQueryHandler : IRequestHandler<ListarCarrosAlugadosQuery, List<CarroDTO>>
{
	private readonly ICarroRepository _repo;
	public ListarCarrosAlugadosQueryHandler(ICarroRepository repo) => _repo = repo;

	public async Task<List<CarroDTO>> Handle(ListarCarrosAlugadosQuery request, CancellationToken cancellationToken)
	{
		var list = await _repo.ListarAlugadosAsync();
		return list.Select(c => new CarroDTO
		{
			Id = c.Id,
			Marca = c.Marca,
			Modelo = c.Modelo,
			Ano = c.Ano,
			ValorDiaria = c.ValorDiaria,
			Disponivel = c.Disponivel
		}).ToList();
	}
}
