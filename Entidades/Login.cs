using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class Login
	{
		[Required(ErrorMessage = "Ingrese el usuario")]
		public string Codigo { get; set; } = string.Empty;
		[Required(ErrorMessage = "Ingrese la contraseña")]
		public string Clave { get; set; } = string.Empty;

		public Login()
		{
		}

		public Login(string codigo, string clave)
		{
			Codigo=codigo;
			Clave=clave;
		}
	}
}
