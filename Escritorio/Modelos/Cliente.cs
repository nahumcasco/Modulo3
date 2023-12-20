
using System;

namespace Escritorio.Modelos
{
	public class Cliente
	{
		public string Identidad { get; set; } = string.Empty;
		public string Nombre { get; set; } = string.Empty;
		public string Direccion { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		public byte[] Foto { get; set; }
		public bool EstaActivo { get; set; }

		public Cliente() { }

		public Cliente(string identidad, string nombre, string direccion, DateTime fechaNacimiento, string telefono, string correo, byte[] foto, bool estaActivo)
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
