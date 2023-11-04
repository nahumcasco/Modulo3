namespace API
{
	public class DBConfiguracion
	{
		public string CadenaConexion { get; set; }

		public DBConfiguracion(string _cadenaConexion)
		{
			CadenaConexion = _cadenaConexion;
		}
	}
}
