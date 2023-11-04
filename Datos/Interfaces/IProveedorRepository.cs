using Entidades;

namespace Datos.Interfaces
{
	public interface IProveedorRepository
	{
		Task<Proveedor> GetPorCodigoAsync(string codigo);
		Task<bool> NuevoAsync(Proveedor proveedor);
		Task<bool> ActualizarAsync(Proveedor proveedor);
		Task<bool> EliminarAsync(string codigo);
		Task<IEnumerable<Proveedor>> GetListaAsync();
	}
}
