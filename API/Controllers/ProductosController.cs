using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IProductoRepository productoRepository;

		public ProductosController(DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion=_dBConfiguracion;
			productoRepository = new ProductoRepository(dBConfiguracion.CadenaConexion);
		}

		[HttpGet]
		public async Task<IActionResult> GetListaAsync()
		{
			IEnumerable<Producto> lista = new List<Producto>();

			lista = await productoRepository.GetListaAsync();
			if (lista.Count() == 0)
				return NotFound();
			return Ok(lista);
		}

		[HttpGet("{codigo}")]
		public async Task<IActionResult> GetPorCodigoAsync(string codigo)
		{
			Producto response = new Producto();

			response = await productoRepository.GetPorCodigoAsync(codigo);

			if (string.IsNullOrEmpty(response.Codigo))
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> ActualizarAsync(Producto producto)
		{
			bool response = false;

			response = await productoRepository.ActualizarAsync(producto);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> NuevoAsync(Producto producto)
		{
			bool response = false;
			response = await productoRepository.NuevoAsync(producto);
			if (response)
				return Created("", response);
			else
				return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> Eliminar(string codigo)
		{
			bool response = false;
			response = await productoRepository.EliminarAsync(codigo);
			if (response)
				return Ok(response);
			else
				return BadRequest();
		}

	}
}
