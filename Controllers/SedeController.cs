using Spa_Personas.Clases;
using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Sede")]
    public class SedeController : ApiController
    {
        [HttpGet]
        [Route("ConsultarxId")]
        public Sede ConsultarXIdSed(int idSedes)
        {
            clsSede sed = new clsSede();
            return sed.ConsultarXIdSede(idSedes);
        }

        [HttpGet]
        [Route("ConsultarxNombre")]
        public Sede ConsultarxNombre(string NombreSede)
        {
            clsSede even = new clsSede();
            return even.ConsultarxNombre(NombreSede);
        }

        [HttpGet]
        [Route("ConsultarxDireccion")]
        public Sede ConsultarxDireccion(string Direccion)
        {
            clsSede sed = new clsSede();
            return sed.ConsultarxDireccion(Direccion);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Sede sed)
        {
            clsSede Sede = new clsSede();
            Sede.sede = sed;
            return Sede.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Sede sed)
        {
            clsSede Sede = new clsSede();
            Sede.sede = sed;
            return Sede.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Sede sed)
        {
            clsSede Sede = new clsSede();
            Sede.sede = sed;
            return Sede.Eliminar();
        }
    }
}