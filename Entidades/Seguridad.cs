using System.Text;

namespace Entidades
{
	public static class Seguridad
	{
		private static string llave = "hjs283298*/5";

		public static string Encriptar(string clave)
		{
			if (string.IsNullOrEmpty(clave)) return "";

			clave += llave;

			var passwordBytes = Encoding.UTF8.GetBytes(clave);
			return Convert.ToBase64String(passwordBytes);
		}

		public static string Desencriptar(string claveEncriptada)
		{
			if (string.IsNullOrEmpty(claveEncriptada)) return "";

			var base64EncodeBytes = Convert.FromBase64String(claveEncriptada);
			var result = Encoding.UTF8.GetString(base64EncodeBytes);
			result = result.Substring(0, result.Length - llave.Length);
			return result;
		}
	}
}
