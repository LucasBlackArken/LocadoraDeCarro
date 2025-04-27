namespace LocadoraDeCarro.Domain.DTO;

public class AluguelDTO
{
	public int Id { get; set; }
	public int CarroId { get; set; }
	public string? MarcaCarro { get; set; }
	public string? ModeloCarro { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }
	public bool Devolvido { get; set; }
	public decimal? ValorTotal { get; set; }
	public decimal? TaxaAtraso { get; set; }
}
