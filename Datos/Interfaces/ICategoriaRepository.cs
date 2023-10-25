using Entidades;

namespace Datos.Interfaces
{
	public interface ICategoriaRepository
	{
		Task<Categoria> GetPorCodigoAsync(string codigo);
		Task<bool> NuevaAsync(Categoria categoria);
		Task<bool> ActualizarAsync(Categoria categoria);
		Task<bool> EliminarAsync(string codigo);
		Task<IEnumerable<Categoria>> GetListaAsync();
	}
}
