using Spa_Personas.Clases;
using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Factura")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FacturaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXId")]
        public Factura ConsultarXId(int idFactura)
        {
            clsFactura fact = new clsFactura();
            return (fact.ConsultarPorId(idFactura));
        }

        [Route("Insertar")]
        public string Insertar([FromBody] Factura fact)
        {
            clsFactura Factura = new clsFactura();
            Factura.factura = fact;
            return Factura.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Factura fact)
        {
            clsFactura Factura = new clsFactura();
            Factura.factura = fact;
            return Factura.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Factura fact)
        {
            clsFactura Factura = new clsFactura();
            Factura.factura = fact;
            return Factura.Eliminar();
        }
    }
}