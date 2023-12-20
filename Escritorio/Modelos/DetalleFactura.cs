
namespace Escritorio.Modelos
{
	public class DetalleFactura
	{
		public int Id { get; set; }
		public string CodigoFactura { get; set; } = string.Empty;
		public string CodigoProducto { get; set; } = string.Empty;
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Total { get; set; }

		public DetalleFactura() { }

		public DetalleFactura(int id, string codigoFactura, string codigoProducto, int cantidad, decimal precio, decimal total)
		{
			Id=id;
			CodigoFactura=codigoFactura;
			CodigoProducto=codigoProducto;
			Cantidad=cantidad;
			Precio=precio;
			Total=total;
		}
	}
}
