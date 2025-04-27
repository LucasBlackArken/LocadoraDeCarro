using LocadoraDeCarro.Domain.DTO;
using MediatR;

namespace LocadoraDeCarro.Application.Query.Aluguel;

public class ObterAluguelPorIdQuery : IRequest<AluguelDTO>
{
	public int Id { get; set; }
}
