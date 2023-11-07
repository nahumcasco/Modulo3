using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProveedoresController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IProveedorRepository proveedorRepository;

		public ProveedoresController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			proveedorRepository = new ProveedorRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<Proveedor> lista = new List<Proveedor>();

			lista = await proveedorRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{codigo}")]
		public async Task<IActionResult> GetPorCodigoAsync(string codigo)
		{
			Proveedor response = new Proveedor();

			response = await proveedorRepository.GetPorCodigoAsync(codigo);

			if (string.IsNullOrEmpty(response.Codigo))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(Proveedor proveedor)
		{
			bool response = false;

			response = await proveedorRepository.ActualizarAsync(proveedor);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevoAsync(Proveedor proveedor)
		{
			bool response = false;
			response = await proveedorRepository.NuevoAsync(proveedor);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(string codigo)
		{
			bool response = false;
			response = await proveedorRepository.EliminarAsync(codigo);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}
	}
}
