using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
	public class DetalleFacturaRepository : IDetalleFacturaRepository
	{
		private string _cadenaConexion;

		public DetalleFacturaRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}
		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}

		public async Task<bool> Nuevo(DetalleFactura detalleFactura)
		{
			bool salida = false;
			try
			{
				using MySqlConnection conexion = Conexion();
				await conexion.OpenAsync();
				string sql = @"INSERT INTO detallefactura (CodigoFactura, CodigoProducto, Cantidad, Precio, Total) 
                               VALUES (@CodigoFactura, @CodigoProducto, @Cantidad, @Precio, @Total) ;";
				salida = Convert.ToBoolean(await conexion.ExecuteAsync(sql, detalleFactura));
			}
			catch (Exception ex)
			{
			}
			return salida;
		}
	}
}
