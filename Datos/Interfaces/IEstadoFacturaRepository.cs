using Entidades;

namespace Datos.Interfaces
{
	public interface IEstadoFacturaRepository
	{
		Task<EstadoFactura> GetPorCodigoAsync(string codigo);
		Task<bool> NuevoAsync(EstadoFactura estadoFactura);
		Task<bool> ActualizarAsync(EstadoFactura estadoFactura);
		Task<bool> EliminarAsync(string codigo);
		Task<IEnumerable<EstadoFactura>> GetListaAsync();

	}
}
