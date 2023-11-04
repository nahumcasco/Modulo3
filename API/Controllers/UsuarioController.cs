using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IUsuarioRepository _usuarioRepository;

		public UsuarioController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			_usuarioRepository = new UsuarioRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<Usuario> lista = new List<Usuario>();

			lista = await _usuarioRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{codigo}")]
		public async Task<IActionResult> GetPorCodigoAsync(string codigo)
		{
			Usuario response = new Usuario();

			response = await _usuarioRepository.GetPorCodigoAsync(codigo);

			if (string.IsNullOrEmpty(response.Codigo))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(Usuario usuario)
		{
			bool response = false;

			response = await _usuarioRepository.ActualizarAsync(usuario);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevoAsync(Usuario usuario)
		{
			bool response = false;
			response = await _usuarioRepository.NuevoAsync(usuario);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(string codigo)
		{
			bool response = false;
			response = await _usuarioRepository.EliminarAsync(codigo);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}


	}
}
