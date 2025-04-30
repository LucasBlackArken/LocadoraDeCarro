using MediatR;

namespace LocadoraDeCarro.Application.Commands.Aluguel;

public class DevolverCarroCommand : IRequest<bool>
{
	public int AluguelId { get; set; }
}
