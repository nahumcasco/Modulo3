using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientesController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IClienteRepository clienteRepository;
		public ClientesController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			clienteRepository = new ClienteRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<Cliente> lista = new List<Cliente>();

			lista = await clienteRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{identidad}")]
		public async Task<IActionResult> GetPorIdentidadAsync(string identidad)
		{
			Cliente response = new Cliente();

			response = await clienteRepository.GetPorIdentidadAsync(identidad);

			if (string.IsNullOrEmpty(response.Identidad))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(Cliente cliente)
		{
			bool response = false;

			response = await clienteRepository.ActualizarAsync(cliente);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevoAsync(Cliente cliente)
		{
			bool response = false;
			response = await clienteRepository.NuevoAsync(cliente);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(string identidad)
		{
			bool response = false;
			response = await clienteRepository.EliminarAsync(identidad);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

	}
}
