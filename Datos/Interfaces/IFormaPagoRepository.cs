using Entidades;

namespace Datos.Interfaces
{
	public interface IFormaPagoRepository
	{
		Task<FormaPago> GetPorIdAsync(int id);
		Task<bool> NuevaAsync(FormaPago formaPago);
		Task<bool> ActualizarAsync(FormaPago formaPago);
		Task<bool> EliminarAsync(int id);
		Task<IEnumerable<FormaPago>> GetListaAsync();
	}
}
