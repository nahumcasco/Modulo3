using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class EstadoFacturaRepository : IEstadoFacturaRepository
	{
		private string _cadenaConexion;

		public EstadoFacturaRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}

		public async Task<bool> ActualizarAsync(EstadoFactura estadoFactura)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE estadofactura SET Nombre = @Nombre ");
				sql.Append(" WHERE Codigo = @Codigo; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), estadoFactura));
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

				string sql = "DELETE FROM estadofactura WHERE Codigo = @Codigo;";

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<IEnumerable<EstadoFactura>> GetListaAsync()
		{
			IEnumerable<EstadoFactura> salida = new List<EstadoFactura>();

			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM estadofactura;";
				salida = await _conexion.QueryAsync<EstadoFactura>(sql);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<EstadoFactura> GetPorCodigoAsync(string codigo)
		{
			EstadoFactura salida = new EstadoFactura();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM estadofactura WHERE Codigo = @Codigo;";
				salida = await _conexion.QueryFirstAsync<EstadoFactura>(sql, new { codigo });
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> NuevoAsync(EstadoFactura estadoFactura)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO estadofactura (Codigo, Nombre) ");
				sql.Append(" VALUES (@Codigo, @Nombre) ");
				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), estadoFactura));
			}
			catch (Exception)
			{
			}
			return salida;
		}
	}
}
