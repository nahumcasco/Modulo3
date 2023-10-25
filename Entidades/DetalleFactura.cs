using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class DetalleFactura
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "El código Factura es obligatorio")]
		public string CodigoFactura { get; set; } = string.Empty;
		[Required(ErrorMessage = "El código Producto es obligatorio")]
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
