using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spa_Personas.Models;
using static Spa_Personas.Models.libLogin;

namespace Spa_Personas.Clases
{
	public class clsLogin
	{
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try
            {
                //Se lee el usuario de la bd 
                Administrador administrador = DBSpa.Administradors.FirstOrDefault(u => u.userName == login.Usuario);
                if (administrador == null)
                {
                    //El usuario no exist, se retorna error
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Administrador no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        private bool ValidarClave()
        {
            try
            {
                Administrador administrador = DBSpa.Administradors.FirstOrDefault(u => u.userName == login.Usuario && u.Clave == login.Clave);
                if (administrador == null)
                {
                    //La clave no es igual
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in DBSpa.Set<Administrador>()
                       where U.userName == login.Usuario &&
                               U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.userName,
                           Autenticado = true,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}