
namespace Escritorio.Modelos
{
	public class FormaPago
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public bool EstaActivo { get; set; }

		public FormaPago()
		{
		}

		public FormaPago(int id, string nombre, bool estaActivo)
		{
			Id=id;
			Nombre=nombre;
			EstaActivo=estaActivo;
		}
	}
}
