using LocadoraDeCarro.Application.Commands.Carro;
using LocadoraDeCarro.Application.Query.Carro;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Precisa estar autenticado via IdentityServer4
public class CarrosController : ControllerBase
{
	private readonly IMediator _mediator;

	public CarrosController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost]
	public async Task<IActionResult> CadastrarCarro([FromBody] CadastrarCarroCommand command)
	{
		var id = await _mediator.Send(command);
		return CreatedAtAction(nameof(ObterPorId), new { id }, id);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> ObterPorId(int id)
	{
		var carro = await _mediator.Send(new ObterCarroPorIdQuery { Id = id });
		if (carro == null)
			return NotFound();

		return Ok(carro);
	}

	[HttpGet("disponiveis")]
	public async Task<IActionResult> ListarDisponiveis()
	{
		var carros = await _mediator.Send(new ListarCarrosDisponiveisQuery());
		return Ok(carros);
	}

	[HttpGet("alugados")]
	public async Task<IActionResult> ListarAlugados()
	{
		var carros = await _mediator.Send(new ListarCarrosAlugadosQuery());
		return Ok(carros);
	}
}




