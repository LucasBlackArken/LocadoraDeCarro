using LocadoraDeCarro.Application.Query.Carro;
using LocadoraDeCarro.Domain.DTO;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Carro;

public class ObterCarroPorIdQueryHandler : IRequestHandler<ObterCarroPorIdQuery, CarroDTO>
{
	private readonly ICarroRepository _repo;
	public ObterCarroPorIdQueryHandler(ICarroRepository repo) => _repo = repo;

	public async Task<CarroDTO> Handle(ObterCarroPorIdQuery request, CancellationToken cancellationToken)
	{
		var c = await _repo.GetByIdAsync(request.Id);
		if (c == null) return null;
		return new CarroDTO
		{
			Id = c.Id,
			Marca = c.Marca,
			Modelo = c.Modelo,
			Ano = c.Ano,
			ValorDiaria = c.ValorDiaria,
			Disponivel = c.Disponivel
		};
	}
}
