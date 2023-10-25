using Entidades;

namespace Datos.Interfaces
{
	public interface IUsuarioRepository
	{
		Task<Usuario> GetPorCodigoAsync(string codigo);
		Task<bool> NuevoAsync(Usuario usuario);
		Task<bool> ActualizarAsync(Usuario usuario);
		Task<bool> EliminarAsync(string codigo);
		Task<IEnumerable<Usuario>> GetListaAsync();

	}
}
