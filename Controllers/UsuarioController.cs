using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Spa_Personas.Clases;
using Spa_Personas.Models;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Usuario")]
    [EnableCors(origins: "http://localhost:3886", headers: "*", methods: "*")]
    [Authorize]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public List<Usuario> Listar()
        {
            clsUsuario usu = new clsUsuario();
            return usu.Listar();
        }
                        
        [HttpGet]
        [Route("ConsultarxCedula")]
        public Usuario ConsultarxCedula(string Cedula)
        {
            clsUsuario usu = new clsUsuario();
            return usu.ConsultarPorCedula(Cedula);
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Usuario ConsultarXId(int Id)
        {
            clsUsuario usu = new clsUsuario();
            return usu.ConsultarXId(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Usuario usu)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.usuario = usu;
            return Usuario.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Usuario usu)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.usuario = usu;
            return Usuario.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Usuario usu)
        {
            clsUsuario Usuario = new clsUsuario();
            Usuario.usuario = usu;
            return Usuario.Eliminar();
        }
    }
}
