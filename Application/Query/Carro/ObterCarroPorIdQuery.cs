using LocadoraDeCarro.Domain.DTO;
using MediatR;

namespace LocadoraDeCarro.Application.Query.Carro;

public class ObterCarroPorIdQuery : IRequest<CarroDTO>
{
	public int Id { get; set; }
}
