using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class Cliente
	{
		[Required(ErrorMessage = "La identidad es obligatorio")]
		public string Identidad { get; set; } = string.Empty;
		[Required(ErrorMessage = "El Nombre es obligatorio")]
		public string Nombre { get; set; } = string.Empty;
		public string? Direccion { get; set; }
		public DateOnly FechaNacimiento { get; set; }
		public string? Telefono { get; set; }
		public string? Correo { get; set; }
		public byte[]? Foto { get; set; }
		public bool EstaActivo { get; set; }

		public Cliente() { }

		public Cliente(string identidad, string nombre, string? direccion, DateOnly fechaNacimiento, string? telefono, string? correo, byte[]? foto, bool estaActivo)
		{
			Identidad=identidad;
			Nombre=nombre;
			Direccion=direccion;
			FechaNacimiento=fechaNacimiento;
			Telefono=telefono;
			Correo=correo;
			Foto=foto;
			EstaActivo=estaActivo;
		}
	}
}
