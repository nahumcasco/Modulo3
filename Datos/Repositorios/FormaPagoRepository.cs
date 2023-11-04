using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class FormaPagoRepository : IFormaPagoRepository
	{
		private string _cadenaConexion;

		public FormaPagoRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}

		public async Task<bool> ActualizarAsync(FormaPago formaPago)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE formapago SET Nombre = @Nombre, EstaActivo = @EstaActivo ");
				sql.Append(" WHERE Id = @Id; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), formaPago));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> EliminarAsync(int id)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				string sql = "DELETE FROM formapago WHERE Id = @Id;";

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { id }));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<IEnumerable<FormaPago>> GetListaAsync()
		{
			IEnumerable<FormaPago> salida = new List<FormaPago>();

			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM formapago;";
				salida = await _conexion.QueryAsync<FormaPago>(sql);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<FormaPago> GetPorIdAsync(int id)
		{
			FormaPago salida = new FormaPago();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM formapago WHERE Id = @Id;";
				salida = await _conexion.QueryFirstAsync<FormaPago>(sql, new { id });
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> NuevaAsync(FormaPago formaPago)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO formapago (Nombre, EstaActivo) ");
				sql.Append(" VALUES (@Nombre, @EstaActivo) ");
				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), formaPago));
			}
			catch (Exception)
			{
			}
			return salida;
		}
	}
}
