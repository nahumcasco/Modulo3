using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class Proveedor
	{
		[Required(ErrorMessage = "El código es obligatorio")]
		public string Codigo { get; set; } = string.Empty;
		[Required(ErrorMessage = "El Nombre es obligatorio")]
		public string Nombre { get; set; } = string.Empty;
		public string? Direccion { get; set; }
		public string? Telefono { get; set; }
		public string? Correo { get; set; }
		public DateTime FechaCreacion { get; set; }
		public bool EstaActivo { get; set; }

		public Proveedor()
		{
		}

		public Proveedor(string codigo, string nombre, string? direccion, string? telefono, string? correo, DateTime fechaCreacion, bool estaActivo)
		{
			Codigo=codigo;
			Nombre=nombre;
			Direccion=direccion;
			Telefono=telefono;
			Correo=correo;
			FechaCreacion=fechaCreacion;
			EstaActivo=estaActivo;
		}
	}
}
