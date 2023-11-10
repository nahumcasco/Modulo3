using API.Jwt;
using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly DBConfiguracion dBConfiguracion;
		private IManejoJwt manejoJwt;
		private ILoginRepository loginRepository;
		private IUsuarioRepository usuariosRepository;

		public LoginController(IManejoJwt _manejoJwt, DBConfiguracion _dBConfiguracion)
		{
			dBConfiguracion = _dBConfiguracion;
			manejoJwt = _manejoJwt;
			loginRepository = new LoginRepository(dBConfiguracion.CadenaConexion);
			usuariosRepository = new UsuarioRepository(dBConfiguracion.CadenaConexion);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Autenticar(Login login)
		{
			LoginMS response = new LoginMS();

			bool usuarioValido = await loginRepository.ValidarUsuarioAsync(login);

			if (usuarioValido)
			{
				Usuario usuario = await usuariosRepository.GetPorCodigoAsync(login.Codigo);

				if (usuario.EstaActivo)
				{
					var token = manejoJwt.GenerarToken(usuario.Codigo, usuario.Nombre);

					response.Codigo = usuario.Codigo;
					response.Nombre = usuario.Nombre;
					response.Rol = usuario.Rol;
					response.Token = token;
					return Ok(response);
				}
				else
				{
					return BadRequest("El usuario esta inactivo");
				}
			}
			else
			{
				return BadRequest("Los datos de usuario no son válidos");
			}
		}

	}
}
