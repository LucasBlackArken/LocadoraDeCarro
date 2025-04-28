using LocadoraDeCarro.Domain.DTO;
using MediatR;

namespace LocadoraDeCarro.Application.Query.Aluguel;

public class ListarTodosAlugueisQuery : IRequest<List<AluguelDTO>> { }
