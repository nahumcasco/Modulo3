using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class EstadoFactura
	{
		[Required(ErrorMessage = "El código es obligatorio")]
		public string Codigo { get; set; } = string.Empty;
		[Required(ErrorMessage = "El Nombre es obligatorio")]
		public string Nombre { get; set; } = string.Empty;

		public EstadoFactura()
		{
		}

		public EstadoFactura(string codigo, string nombre)
		{
			Codigo=codigo;
			Nombre=nombre;
		}
	}
}
