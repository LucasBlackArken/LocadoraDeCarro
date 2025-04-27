using LocadoraDeCarro.Application.Query.Aluguel;
using LocadoraDeCarro.Domain.DTO;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Aluguel;

public class ObterAluguelPorIdQueryHandler : IRequestHandler<ObterAluguelPorIdQuery, AluguelDTO>
{
	private readonly IAluguelRepository _repo;
	public ObterAluguelPorIdQueryHandler(IAluguelRepository repo) => _repo = repo;

	public async Task<AluguelDTO> Handle(ObterAluguelPorIdQuery request, CancellationToken cancellationToken)
	{
		var a = await _repo.GetByIdAsync(request.Id);
		if (a == null) return null;
		return new AluguelDTO
		{
			Id = a.Id,
			CarroId = a.CarroId,
			MarcaCarro = a.Carro.Marca,
			ModeloCarro = a.Carro.Modelo,
			DataInicio = a.DataInicio,
			DataFim = a.DataFim,
			Devolvido = a.Devolvido,
			ValorTotal = a.ValorTotal,
			TaxaAtraso = a.TaxaAtraso
		};
	}
}
