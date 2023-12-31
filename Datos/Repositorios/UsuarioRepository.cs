﻿using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos.Repositorios
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private string _cadenaConexion;

		public UsuarioRepository(string cadenaConexion)
		{
			_cadenaConexion=cadenaConexion;
		}

		private MySqlConnection Conexion()
		{
			return new MySqlConnection(_cadenaConexion);
		}


		public async Task<bool> ActualizarAsync(Usuario usuario)
		{
			Usuario usu = usuario;
			usu.Clave = Seguridad.Encriptar(usuario.Clave);

			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" UPDATE usuario SET Nombre = @Nombre, Correo = @Correo, Clave = @Clave, ");
				sql.Append(" Foto = @Foto, Rol = @Rol, EstaActivo = @EstaActivo ");
				sql.Append(" WHERE Codigo = @Codigo; ");

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), usu));
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

				string sql = "DELETE FROM usuario WHERE Codigo = @Codigo;";

				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<IEnumerable<Usuario>> GetListaAsync()
		{
			List<Usuario> salida = new List<Usuario>();
			IEnumerable<Usuario> listaPrevia = new List<Usuario>();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM usuario;";
				listaPrevia = await _conexion.QueryAsync<Usuario>(sql);

				foreach (var item in listaPrevia)
				{
					salida.Add(new Usuario(item.Codigo, item.Nombre, item.Correo, Seguridad.Desencriptar(item.Clave), item.Foto, item.Rol, item.EstaActivo));
				}
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<Usuario> GetPorCodigoAsync(string codigo)
		{
			Usuario salida = new Usuario();
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();
				string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo;";
				salida = await _conexion.QueryFirstAsync<Usuario>(sql, new { codigo });
				salida.Clave = Seguridad.Desencriptar(salida.Clave);
			}
			catch (Exception)
			{
			}
			return salida;
		}

		public async Task<bool> NuevoAsync(Usuario usuario)
		{
			Usuario usu = usuario;
			usu.Clave = Seguridad.Encriptar(usuario.Clave);
			bool salida = false;
			try
			{
				using MySqlConnection _conexion = Conexion();
				await _conexion.OpenAsync();

				StringBuilder sql = new StringBuilder();
				sql.Append(" INSERT INTO usuario (Codigo, Nombre, Correo, Clave, Foto, Rol, EstaActivo) ");
				sql.Append(" VALUES (@Codigo, @Nombre, @Correo, @Clave, @Foto, @Rol, @EstaActivo) ");
				salida = Convert.ToBoolean(await _conexion.ExecuteAsync(sql.ToString(), usu));
			}
			catch (Exception)
			{
			}
			return salida;
		}



	}
}
