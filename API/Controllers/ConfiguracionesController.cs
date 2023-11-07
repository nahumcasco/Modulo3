using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConfiguracionesController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		IConfiguracionRepository configuracionRepository;
		public ConfiguracionesController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion=_dBConfiguracion;
			configuracionRepository = new ConfiguracionRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			Configuracion response = new Configuracion();

			response = await configuracionRepository.GetAsync();

			if (string.IsNullOrEmpty(response.Id.ToString()))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(Configuracion configuracion)
		{
			bool response = false;

			response = await configuracionRepository.ActualizarAsync(configuracion);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> GuardarAsync(Configuracion configuracion)
		{
			bool response = false;
			response = await configuracionRepository.GuardarAsync(configuracion);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}
	}
}
