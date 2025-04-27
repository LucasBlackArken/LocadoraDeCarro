using LocadoraDeCarro.Application.Query.Carro;
using LocadoraDeCarro.Domain.DTO;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Carro;

public class ListarCarrosDisponiveisQueryHandler : IRequestHandler<ListarCarrosDisponiveisQuery, List<CarroDTO>>
{
	private readonly ICarroRepository _repo;
	public ListarCarrosDisponiveisQueryHandler(ICarroRepository repo) => _repo = repo;

	public async Task<List<CarroDTO>> Handle(ListarCarrosDisponiveisQuery request, CancellationToken cancellationToken)
	{
		var list = await _repo.ListarDisponiveisAsync();
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

