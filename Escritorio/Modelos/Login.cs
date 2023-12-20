
namespace Escritorio.Modelos
{
	public class Login
	{
		public string Codigo { get; set; } = string.Empty;
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
