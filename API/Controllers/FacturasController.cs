using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacturasController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IFacturaRepository facturaRepository;
		public FacturasController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			facturaRepository = new FacturaRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpPost]
		public async Task<IActionResult> NuevaAsync(Factura factura)
		{
			string response = "";
			response = await facturaRepository.Nueva(factura);
			if (!string.IsNullOrEmpty(response))
				return Created("", response);
			else
				return BadRequest();
		}

	}
}
