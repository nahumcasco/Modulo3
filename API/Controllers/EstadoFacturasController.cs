using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstadoFacturasController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IEstadoFacturaRepository estadoFacturaRepository;

		public EstadoFacturasController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			estadoFacturaRepository = new EstadoFacturaRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<EstadoFactura> lista = new List<EstadoFactura>();

			lista = await estadoFacturaRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{codigo}")]
		public async Task<IActionResult> GetPorCodigoAsync(string codigo)
		{
			EstadoFactura response = new EstadoFactura();

			response = await estadoFacturaRepository.GetPorCodigoAsync(codigo);

			if (string.IsNullOrEmpty(response.Codigo))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(EstadoFactura estadoFactura)
		{
			bool response = false;

			response = await estadoFacturaRepository.ActualizarAsync(estadoFactura);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevaAsync(EstadoFactura estadoFactura)
		{
			bool response = false;
			response = await estadoFacturaRepository.NuevoAsync(estadoFactura);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(string codigo)
		{
			bool response = false;
			response = await estadoFacturaRepository.EliminarAsync(codigo);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

	}
}
