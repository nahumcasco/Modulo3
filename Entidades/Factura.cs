using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class Factura
	{
		[Required(ErrorMessage = "El código es obligatorio")]
		public string Codigo { get; set; } = string.Empty;
		public DateTime Fecha { get; set; }
		[Required(ErrorMessage = "La identidad Cliente es obligatoria")]
		public string IdentidadCliente { get; set; } = string.Empty;
		[Required(ErrorMessage = "El código usuario es obligatorio")]
		public string CodigoUsuario { get; set; } = string.Empty;
		[Required(ErrorMessage = "El código estado es obligatorio")]
		public string CodigoEstado { get; set; } = string.Empty;
		public decimal SubTotal { get; set; }
		public decimal ISV { get; set; }
		public decimal Descuento { get; set; }
		public decimal Total { get; set; }

		public Factura()
		{
		}

		public Factura(string codigo, DateTime fecha, string identidadCliente, string codigoUsuario, string codigoEstado, decimal subTotal, decimal iSV, decimal descuento, decimal total)
		{
			Codigo=codigo;
			Fecha=fecha;
			IdentidadCliente=identidadCliente;
			CodigoUsuario=codigoUsuario;
			CodigoEstado=codigoEstado;
			SubTotal=subTotal;
			ISV=iSV;
			Descuento=descuento;
			Total=total;
		}
	}
}
