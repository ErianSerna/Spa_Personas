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
    [RoutePrefix("api/Detalle_Factura")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Detalle_FacturaController : ApiController
    {

        // Consultar todos los proveedores
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Detalle_factura> ConsultarTodos()
        {
            //Se crea un objeto de la clase clsEmpleado
            clsDetalle_Factura det_fact = new clsDetalle_Factura();          
            return det_fact.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Detalle_factura ConsultarXId(int idDetFact)
        {
            clsDetalle_Factura det_fact = new clsDetalle_Factura();
            return (det_fact.ConsultarPorId(idDetFact));
        }

        //[Route("Insertar")]
        //public string Insertar([FromBody] Producto prod)
        //{
        //    clsProducto Producto = new clsProducto();
        //    Producto.producto = prod;
        //    return Producto.Insertar();
        //}

        //[HttpPut]
        //[Route("Actualizar")]
        //public string Actualizar([FromBody] Producto prod)
        //{
        //    clsProducto Producto = new clsProducto();
        //    Producto.producto = prod;
        //    return Producto.Actualizar();
        //}

        //[HttpDelete]
        //[Route("Eliminar")]
        //public string Eliminar([FromBody] Producto prod)
        //{
        //    clsProducto Producto = new clsProducto();
        //    Producto.producto = prod;
        //    return Producto.Eliminar();
        //}
    }
}