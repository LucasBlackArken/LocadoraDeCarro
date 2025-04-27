using LocadoraDeCarro.Application.Commands.Aluguel;
using LocadoraDeCarro.Domain.Entities;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Aluguel;

public class AluguelCarroCommandHandler : IRequestHandler<AluguelCarroCommand, int>
{
	private readonly ICarroRepository _carroRepository;
	private readonly IAluguelRepository _aluguelRepository;

	public AluguelCarroCommandHandler(ICarroRepository carroRepository, IAluguelRepository aluguelRepository)
	{
		_carroRepository = carroRepository;
		_aluguelRepository = aluguelRepository;
	}

	public async Task<int> Handle(AluguelCarroCommand request, CancellationToken cancellationToken)
	{
		var carro = await _carroRepository.GetByIdAsync(request.CarroId);

		if (carro == null || !carro.Disponivel)
			throw new Exception("Carro indisponível para aluguel.");

		var aluguel = new Domain.Entities.Aluguel
		{
			CarroId = request.CarroId,
			DataInicio = request.DataInicio,
			DataFim = request.DataFim,
			Devolvido = false
		};

		// Atualiza disponibilidade do carro
		carro.Disponivel = false;
		await _carroRepository.UpdateAsync(carro);

		await _aluguelRepository.AddAsync(aluguel);

		return aluguel.Id;
	}
}
