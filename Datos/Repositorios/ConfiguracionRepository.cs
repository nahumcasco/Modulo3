using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class ConfiguracionRepository : IConfiguracionRepository
	{
		private string _cadenaConexion;

		public ConfiguracionRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}

		public async Task<bool> ActualizarAsync(Configuracion configuracion)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE configuracion SET RazonSocial = @RazonSocial, NombreComercial = @NombreComercial ");
				sql.Append(" RTN = @RTN, Direccion = @Direccion, Telefono = @Telefono, Correo = @Correo, Logo = @Logo, ");
				sql.Append(" Establecimiento = @Establecimiento, PuntoEmision = @PuntoEmision, TipoDocumento = @TipoDocumento, ");
				sql.Append(" RangoInicial = @RangoInicial, RangoFinal = @RangoFinal, FechaLimiteEmision = @FechaLimiteEmision, CAI = @CAI ");
				sql.Append(" WHERE Id = @Id; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), configuracion));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<Configuracion> GetAsync()
		{
			Configuracion salida = new Configuracion();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM configuracion;";
				salida = await _conexion.QueryFirstAsync<Configuracion>(sql);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> GuardarAsync(Configuracion configuracion)
		{
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO configuracion (RazonSocial, NombreComercial, RTN, Direccion, Telefono, Correo, ");
				sql.Append(" Logo, Establecimiento, PuntoEmision, TipoDocumento, RangoInicial, RangoFinal, FechaLimiteEmision, CAI) ");
				sql.Append(" VALUES (@RazonSocial, @NombreComercial, @RTN, @Direccion, @Telefono, @Correo, ");
				sql.Append(" @Logo, @Establecimiento, @PuntoEmision, @TipoDocumento, @RangoInicial, @RangoFinal, @FechaLimiteEmision, @CAI) ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), configuracion));
			}
			catch (Exception)
			{
			}
			return salida;
		}
	}
}
