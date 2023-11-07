using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		ICategoriaRepository categoriaRepository;

		public CategoriasController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			categoriaRepository = new CategoriaRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<Categoria> lista = new List<Categoria>();

			lista = await categoriaRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{codigo}")]
		public async Task<IActionResult> GetPorCodigoAsync(string codigo)
		{
			Categoria response = new Categoria();

			response = await categoriaRepository.GetPorCodigoAsync(codigo);

			if (string.IsNullOrEmpty(response.Codigo))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(Categoria categoria)
		{
			bool response = false;

			response = await categoriaRepository.ActualizarAsync(categoria);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevaAsync(Categoria categoria)
		{
			bool response = false;
			response = await categoriaRepository.NuevaAsync(categoria);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(string codigo)
		{
			bool response = false;
			response = await categoriaRepository.EliminarAsync(codigo);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}
	}
}
