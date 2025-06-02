using Spa_Personas.Clases;
using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spa_Personas.Controllers
{
    [RoutePrefix("api/Detalle_Factura")]
    public class Detalle_FacturaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXId")]
        public Detalle_factura ConsultarXId(int idDetFact)
        {
            clsDetalle_Factura det_fact = new clsDetalle_Factura();
            return (det_fact.ConsultarPorId(idDetFact));
        }

        //[Route("Insertar")]
        //public string Insertar([FromBody] Detalle_factura Det_Fat)
        //{
        //    clsDetalle_Factura Det_Fact = new clsDetalle_Factura();
        //    Det_Fact. = prod;
        //    return Producto.Insertar();
        //}

        //[HttpDelete]
        //[Route("Eliminar")]
        //public string Eliminar([FromBody] Detalle_factura Det_Fat)
        //{
        //    clsDetalle_Factura Det_Fact = new clsDetalle_Factura();
        //    Det_Fact.producto = prod;
        //    return Producto.Eliminar();
        //}
    }
}