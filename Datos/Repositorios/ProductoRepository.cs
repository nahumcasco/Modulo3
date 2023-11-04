using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class ProductoRepository : IProductoRepository
	{
		private string _cadenaConexion;

		public ProductoRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}

		public async Task<bool> ActualizarAsync(Producto producto)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE producto SET Descripcion = @Descripcion, Precio = @Precio, Existencia=@Existencia, ");
				sql.Append(" Foto=@Foto, FechaCreacion=@FechaCreacion, CodigoCategoria=@CodigoCategoria,CodigoUsuario=@CodigoUsuario, ");
				sql.Append(" ISV = @ISV, EstaActivo =@EstaActivo ");
				sql.Append(" WHERE Codigo = @Codigo; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), producto));
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

				string sql = "DELETE FROM producto WHERE Codigo = @Codigo;";

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<IEnumerable<Producto>> GetListaAsync()
		{
			IEnumerable<Producto> salida = new List<Producto>();

			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM producto;";
				salida = await _conexion.QueryAsync<Producto>(sql);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<Producto> GetPorCodigoAsync(string codigo)
		{
			Producto salida = new Producto();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM producto WHERE Codigo = @Codigo;";
				salida = await _conexion.QueryFirstAsync<Producto>(sql, new { codigo });
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> NuevoAsync(Producto producto)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO producto (Codigo, Descripcion, Precio, Existencia, Foto, ");
				sql.Append(" FechaCreacion, CodigoCategoria, CodigoUsuario, ISV, EstaActivo) ");

				sql.Append(" VALUES (@Codigo, @Descripcion, @Precio, @Existencia, @Foto, ");
				sql.Append(" @FechaCreacion, @CodigoCategoria, @CodigoUsuario, @ISV, @EstaActivo) ");
				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), producto));
			}
			catch (Exception)
			{
			}
			return salida;
		}
	}
}
