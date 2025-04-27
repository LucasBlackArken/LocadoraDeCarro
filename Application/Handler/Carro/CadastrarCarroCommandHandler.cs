using LocadoraDeCarro.Application.Commands.Carro;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Carro;

public class CadastrarCarroCommandHandler : IRequestHandler<CadastrarCarroCommand, int>
{
	private readonly ICarroRepository _repository;

	public CadastrarCarroCommandHandler(ICarroRepository repository)
	{
		_repository = repository;
	}

	public async Task<int> Handle(CadastrarCarroCommand request, CancellationToken cancellationToken)
	{
		var carro = new Domain.Entities.Carro
		{
			Marca = request.Marca,
			Modelo = request.Modelo,
			Ano = request.Ano,
			ValorDiaria = request.ValorDiaria,
			Disponivel = true
		};

		await _repository.AddAsync(carro);
		return carro.Id;
	}
}
