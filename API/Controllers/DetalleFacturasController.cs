using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetalleFacturasController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IDetalleFacturaRepository detalleFacturaRepository;

		public DetalleFacturasController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion=_dBConfiguracion;
			detalleFacturaRepository= new DetalleFacturaRepository(dBConfiguracion.CadenaConexion);
		}


		[HttpPost]
		public async Task<IActionResult> NuevaAsync(DetalleFactura detalleFactura)
		{
			bool response = false;
			response = await detalleFacturaRepository.Nuevo(detalleFactura);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}
	}
}
