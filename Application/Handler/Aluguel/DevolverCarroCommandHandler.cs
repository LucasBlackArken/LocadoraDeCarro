using LocadoraDeCarro.Application.Commands.Aluguel;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Aluguel;

public class DevolverCarroCommandHandler : IRequestHandler<DevolverCarroCommand, bool>
{
	private readonly ICarroRepository _carroRepository;
	private readonly IAluguelRepository _aluguelRepository;

	public DevolverCarroCommandHandler(ICarroRepository carroRepository, IAluguelRepository aluguelRepository)
	{
		_carroRepository = carroRepository;
		_aluguelRepository = aluguelRepository;
	}

	public async Task<bool> Handle(DevolverCarroCommand request, CancellationToken cancellationToken)
	{
		var aluguel = await _aluguelRepository.GetByIdAsync(request.AluguelId);
		if (aluguel == null)
			return false;

		aluguel.Devolvido = true;

		var hoje = DateTime.UtcNow;
		if (hoje > aluguel.DataFim)
		{
			var diasAtraso = (hoje.Date - aluguel.DataFim.Date).Days;
			aluguel.TaxaAtraso = diasAtraso * 50;
		}

		aluguel.ValorTotal = CalcularValorTotal(aluguel);

		await _aluguelRepository.UpdateAsync(aluguel);

		var carro = await _carroRepository.GetByIdAsync(aluguel.CarroId);
		if (carro != null)
		{
			carro.Disponivel = true;
			await _carroRepository.UpdateAsync(carro);
		}

		return true;
	}

	private decimal CalcularValorTotal(Domain.Entities.Aluguel aluguel)
	{
		var diasAlugados = (aluguel.DataFim.Date - aluguel.DataInicio.Date).Days;
		var valorDiaria = aluguel.Carro?.ValorDiaria ?? 0;
		var total = diasAlugados * valorDiaria;

		if (aluguel.TaxaAtraso.HasValue)
			total += aluguel.TaxaAtraso.Value;

		return total;
	}
}

