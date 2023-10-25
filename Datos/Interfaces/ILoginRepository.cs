using Entidades;

namespace Datos.Interfaces
{
	public interface ILoginRepository
	{
		Task<bool> ValidarUsuarioAsync(Login login);
	}
}
