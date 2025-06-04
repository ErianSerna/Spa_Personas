using Spa_Personas.Clases;
using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Servicio")]
    [EnableCors(origins: "http://localhost:3886", headers: "*", methods: "*")]
    [Authorize]

    public class ServicioController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Servicio> ConsultarTodos()
        {
            clsServicio serv = new clsServicio();
            return serv.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxId")]
        public Servicio ConsultarxId(int Id)
        {
            clsServicio serv = new clsServicio();
            return (serv.ConsultarPorId(Id));

        }

        [Route("Insertar")]
        public string Insertar([FromBody] Servicio serv)
        {
            clsServicio Servicio = new clsServicio();
            Servicio.servicio = serv;
            return Servicio.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Servicio serv)
        {
            clsServicio Servicio = new clsServicio();
            Servicio.servicio = serv;
            return Servicio.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Servicio serv)
        {
            clsServicio Servicio = new clsServicio();
            Servicio.servicio = serv;
            return Servicio.Eliminar();
        }
    }
}