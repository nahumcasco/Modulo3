using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class Producto
	{
		[Required(ErrorMessage = "El código es obligatorio")]
		public string Codigo { get; set; } = string.Empty;
		[Required(ErrorMessage = "La descripción es obligatoria")]
		public string Descripcion { get; set; } = string.Empty;
		public decimal Precio { get; set; }
		public int Existencia { get; set; }
		public byte[]? Foto { get; set; }
		public DateTime FechaCreacion { get; set; }
		[Required(ErrorMessage = "El código categoría es obligatoria")]
		public string CodigoCategoria { get; set; } = string.Empty;
		[Required(ErrorMessage = "El código usuario es obligatorio")]
		public string CodigoUsuario { get; set; } = string.Empty;
		public decimal ISV { get; set; }
		public bool EstaActivo { get; set; }

		public Producto()
		{
		}

		public Producto(string codigo, string descripcion, decimal precio, int existencia, byte[]? foto, DateTime fechaCreacion, string codigoCategoria, string codigoUsuario, decimal iSV, bool estaActivo)
		{
			Codigo=codigo;
			Descripcion=descripcion;
			Precio=precio;
			Existencia=existencia;
			Foto=foto;
			FechaCreacion=fechaCreacion;
			CodigoCategoria=codigoCategoria;
			CodigoUsuario=codigoUsuario;
			ISV=iSV;
			EstaActivo=estaActivo;
		}
	}
}
