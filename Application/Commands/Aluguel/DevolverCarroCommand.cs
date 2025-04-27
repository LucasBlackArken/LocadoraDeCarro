using MediatR;

namespace LocadoraDeCarro.Application.Commands.Aluguel;

public class DevolverCarroCommand : IRequest
{
	public int AluguelId { get; set; }
}
