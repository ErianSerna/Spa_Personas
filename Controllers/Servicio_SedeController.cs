using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Spa_Personas.Clases;
using Spa_Personas.Models;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Servicio_Sede")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]

    public class Servicio_SedeController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Servicio_Sede> ConsultarTodos()
        {
            clsServicio_Sede serv_sede = new clsServicio_Sede();
            return serv_sede.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Servicio_Sede ConsultarXId(int idServSede)
        {
            clsServicio_Sede serv_sede = new clsServicio_Sede();
            return (serv_sede.ConsultarPorId(idServSede));
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Servicio_Sede serv_sed)
        {
            clsServicio_Sede serv_sede = new clsServicio_Sede();
            serv_sede.Serv_sede = serv_sed;
            return serv_sede.Insertar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Servicio_Sede serv_sed)
        {
            clsServicio_Sede serv_sede = new clsServicio_Sede();
            serv_sede.Serv_sede = serv_sed;
            return serv_sede.Eliminar();
        }
    }
}