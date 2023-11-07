using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FormaPagosController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IFormaPagoRepository formaPagoRepository;

		public FormaPagosController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			formaPagoRepository= new FormaPagoRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<FormaPago> lista = new List<FormaPago>();

			lista = await formaPagoRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPorIdAsync(int id)
		{
			FormaPago response = new FormaPago();

			response = await formaPagoRepository.GetPorIdAsync(id);

			if (response.Id > 0)
			{
				return Ok(response);
			}
			return NotFound();
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(FormaPago formaPago)
		{
			bool response = false;

			response = await formaPagoRepository.ActualizarAsync(formaPago);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevaAsync(FormaPago formaPago)
		{
			bool response = false;
			response = await formaPagoRepository.NuevaAsync(formaPago);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(int id)
		{
			bool response = false;
			response = await formaPagoRepository.EliminarAsync(id);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

	}
}
