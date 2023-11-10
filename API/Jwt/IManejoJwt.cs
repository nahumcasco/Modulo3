namespace API.Jwt
{
	public interface IManejoJwt
	{
		public string GenerarToken(string codigo, string nombre);
	}
}
