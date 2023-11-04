using Entidades;

namespace Datos.Interfaces
{
	public interface IConfiguracionRepository
	{
		Task<Configuracion> GetAsync();
		Task<bool> GuardarAsync(Configuracion categoria);
		Task<bool> ActualizarAsync(Configuracion categoria);
	}
}
