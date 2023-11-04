using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class ProveedorRepository : IProveedorRepository
	{
		private string _cadenaConexion;

		public ProveedorRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}

		public async Task<bool> ActualizarAsync(Proveedor proveedor)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE proveedor SET Nombre = @Nombre, Direccion = @Direccion, Telefono=@Telefono, ");
				sql.Append(" Correo = @Correo, FechaCreacion =@FechaCreacion, EstaActivo = @EstaActivo ");
				sql.Append(" WHERE Codigo = @Codigo; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), proveedor));
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

				string sql = "DELETE FROM proveedor WHERE Codigo = @Codigo;";

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<IEnumerable<Proveedor>> GetListaAsync()
		{
			IEnumerable<Proveedor> salida = new List<Proveedor>();

			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM proveedor;";
				salida = await _conexion.QueryAsync<Proveedor>(sql);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<Proveedor> GetPorCodigoAsync(string codigo)
		{
			Proveedor salida = new Proveedor();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM proveedor WHERE Codigo = @Codigo;";
				salida = await _conexion.QueryFirstAsync<Proveedor>(sql, new { codigo });
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> NuevoAsync(Proveedor proveedor)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO proveedor (Codigo, Nombre, Direccion, Telefono, ");
				sql.Append(" Correo, FechaCreacion, EstaActivo) ");
				sql.Append(" VALUES (@Codigo, @Nombre, @Direccion, @Telefono, ");
				sql.Append(" @Correo, @FechaCreacion, @EstaActivo) ");
				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), proveedor));
			}
			catch (Exception)
			{
			}
			return salida;
		}
	}
}
