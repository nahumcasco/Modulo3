using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
	public class LoginRepository : ILoginRepository
	{
		private string _cadenaConexion;

		public LoginRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}

		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}


		public async Task<bool> ValidarUsuarioAsync(Login login)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT 1 FROM usuario WHERE Codigo = @Codigo AND Clave = @Clave;";
				salida = await _conexion.ExecuteScalarAsync<bool>(sql, login);
			}
			catch (Exception)
			{
			}
			return salida;
		}
	}
}
