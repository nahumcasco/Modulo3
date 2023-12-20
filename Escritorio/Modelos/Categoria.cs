
namespace Escritorio.Modelos
{
	public class Categoria
	{
		public string Codigo { get; set; } = string.Empty;
		public string Nombre { get; set; } = string.Empty;
		public bool EstaActivo { get; set; }

		public Categoria() { }

		public Categoria(string codigo, string nombre, bool estaActivo)
		{
			Codigo=codigo;
			Nombre=nombre;
			EstaActivo=estaActivo;
		}
	}
}
