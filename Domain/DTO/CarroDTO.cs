namespace LocadoraDeCarro.Domain.DTO;

public class CarroDTO
{
	public int Id { get; set; }
	public string? Marca { get; set; }
	public string? Modelo { get; set; }
	public int Ano { get; set; }
	public decimal ValorDiaria { get; set; }
	public bool Disponivel { get; set; }
}
