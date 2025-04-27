using MediatR;

namespace LocadoraDeCarro.Application.Commands.Aluguel;

public class AluguelCarroCommand : IRequest<int>
{
	public int CarroId { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }
}
