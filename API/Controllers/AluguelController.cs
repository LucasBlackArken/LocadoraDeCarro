using LocadoraDeCarro.Application.Commands.Aluguel;
using LocadoraDeCarro.Application.Query.Aluguel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AlugueisController : ControllerBase
{
	private readonly IMediator _mediator;

	public AlugueisController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost]
	public async Task<IActionResult> Alugar([FromBody] AluguelCarroCommand command)
	{
		var aluguelId = await _mediator.Send(command);
		return CreatedAtAction(nameof(ObterPorId), new { id = aluguelId }, aluguelId);
	}

	[HttpPost("{id}/devolver")]
	public async Task<IActionResult> Devolver(int id)
	{
		await _mediator.Send(new DevolverCarroCommand { AluguelId = id });
		return NoContent();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> ObterPorId(int id)
	{
		var aluguel = await _mediator.Send(new ObterAluguelPorIdQuery { Id = id });
		if (aluguel == null)
			return NotFound();

		return Ok(aluguel);
	}

	[HttpGet]
	public async Task<IActionResult> ListarTodos()
	{
		var alugueis = await _mediator.Send(new ListarTodosAlugueisQuery());
		return Ok(alugueis);
	}
}

