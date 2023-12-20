
namespace Entidades
{
	public class EstadoFactura
	{
		public string Codigo { get; set; } = string.Empty;
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
