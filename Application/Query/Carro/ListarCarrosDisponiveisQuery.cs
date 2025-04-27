using LocadoraDeCarro.Domain.DTO;
using MediatR;

namespace LocadoraDeCarro.Application.Query.Carro;

public class ListarCarrosDisponiveisQuery : IRequest<List<CarroDTO>> { }
