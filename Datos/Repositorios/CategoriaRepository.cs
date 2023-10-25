using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class CategoriaRepository : ICategoriaRepository
	{
		private string _cadenaConexion;

		public CategoriaRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}


		public async Task<bool> ActualizarAsync(Categoria categoria)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE categoria SET Nombre = @Nombre, EstaActivo = @EstaActivo ");
				sql.Append(" WHERE Codigo = @Codigo; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), categoria));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> EliminarAsync(string codigo)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				string sql = "DELETE FROM categoria WHERE Codigo = @Codigo;";

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<IEnumerable<Categoria>> GetListaAsync()
		{
			IEnumerable<Categoria> salida = new List<Categoria>();

			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM categoria;";
				salida = await _conexion.QueryAsync<Categoria>(sql);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<Categoria> GetPorCodigoAsync(string codigo)
		{
			Categoria salida = new Categoria();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM categoria WHERE Codigo = @Codigo;";
				salida = await _conexion.QueryFirstAsync<Categoria>(sql, new { codigo });
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> NuevaAsync(Categoria categoria)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO categoria (Codigo, Nombre, EstaActivo) ");
				sql.Append(" VALUES (@Codigo, @Nombre, @EstaActivo) ");
				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), categoria));
			}
			catch (Exception)
			{
			}
			return salida;
		}



	}
}
