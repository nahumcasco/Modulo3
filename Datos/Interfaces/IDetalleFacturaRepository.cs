using Entidades;

namespace Datos.Interfaces
{
	public interface IDetalleFacturaRepository
	{
		Task<bool> Nuevo(DetalleFactura detalleFactura);
	}
}
