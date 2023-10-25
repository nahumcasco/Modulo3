using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class FormaPago
	{
		[Required(ErrorMessage = "El Id es obligatorio")]
		public int Id { get; set; }
		[Required(ErrorMessage = "El Nombre es obligatorio")]
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
