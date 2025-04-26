using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarro.API.Controllers;

public class AluguelController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
