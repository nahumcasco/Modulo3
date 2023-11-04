using Entidades;

namespace Datos.Interfaces
{
	public interface IFacturaRepository
	{
		Task<string> Nueva(Factura factura);
	}
}
