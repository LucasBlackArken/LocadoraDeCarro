using LocadoraDeCarro.Application.Query.Aluguel;
using LocadoraDeCarro.Domain.DTO;
using LocadoraDeCarro.Domain.Interfaces;
using MediatR;

namespace LocadoraDeCarro.Application.Handler.Aluguel;

public class ListarTodosAlugueisQueryHandler : IRequestHandler<ListarTodosAlugueisQuery, List<AluguelDTO>>
{
    private readonly IAluguelRepository _repo;
    public ListarTodosAlugueisQueryHandler(IAluguelRepository repo) => _repo = repo;

    public async Task<List<AluguelDTO>> Handle(ListarTodosAlugueisQuery request, CancellationToken cancellationToken)
    {
        var list = await _repo.ListarTodosAsync();
        return list.Select(a => new AluguelDTO
        {
            Id = a.Id,
            CarroId = a.CarroId,
            MarcaCarro = a.Carro.Marca,
            ModeloCarro = a.Carro.Modelo,
            DataInicio = a.DataInicio,
            DataFim = a.DataFim,
            Devolvido = a.Devolvido,
            ValorTotal = a.ValorTotal,
            TaxaAtraso = a.TaxaAtraso
        }).ToList();
    }
}
