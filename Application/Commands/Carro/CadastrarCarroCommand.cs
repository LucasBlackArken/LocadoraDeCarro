using MediatR;

namespace LocadoraDeCarro.Application.Commands.Carro;

public class CadastrarCarroCommand : IRequest<int>
{
	public string? Marca { get; set; }
	public string? Modelo { get; set; }
	public int Ano { get; set; }
	public decimal ValorDiaria { get; set; }
}
