
using System;

namespace Escritorio.Modelos
{
	public class Configuracion
	{
		public int Id { get; set; }
		public string RazonSocial { get; set; } = string.Empty;
		public string NombreComercial { get; set; } = string.Empty;
		public string RTN { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		public byte[] Logo { get; set; }
		public char Establecimiento { get; set; }
		public char PuntoEmision { get; set; }
		public char TipoDocumento { get; set; }
		public string RangoInicial { get; set; }
		public string RangoFinal { get; set; }
		public DateTime FechaLimiteEmision { get; set; }
		public string CAI { get; set; }

		public Configuracion() { }

		public Configuracion(int id, string razonSocial, string nombreComercial, string rTN, string direccion, string telefono, string correo, byte[] logo, char establecimiento, char puntoEmision, char tipoDocumento, string rangoInicial, string rangoFinal, DateTime fechaLimiteEmision, string cAI)
		{
			Id=id;
			RazonSocial=razonSocial;
			NombreComercial=nombreComercial;
			RTN=rTN;
			Direccion=direccion;
			Telefono=telefono;
			Correo=correo;
			Logo=logo;
			Establecimiento=establecimiento;
			PuntoEmision=puntoEmision;
			TipoDocumento=tipoDocumento;
			RangoInicial=rangoInicial;
			RangoFinal=rangoFinal;
			FechaLimiteEmision=fechaLimiteEmision;
			CAI=cAI;
		}
	}
}
