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
    [RoutePrefix("api/Proveedor_Producto")]
    public class Proveedor_ProductoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXProveedor")]
        public Proveedor_Producto ConsultarXProveedor(int id)
        {
            clsProveedor_Producto prov_prod = new clsProveedor_Producto();
            return (prov_prod.ConsultarXProveedor(id));
        }

        [HttpGet]
        [Route("ConsultarXProducto")]
        public Proveedor_Producto ConsultarXProducto(int id)
        {
            clsProveedor_Producto prov_prod = new clsProveedor_Producto();
            return (prov_prod.ConsultarXProducto(id));
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Proveedor_Producto prov_pro)
        {
            clsProveedor_Producto prov_prod = new clsProveedor_Producto();
            prov_prod.prov_prod = prov_pro;
            return prov_prod.Insertar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Proveedor_Producto prov_pro)
        {
            clsProveedor_Producto prov_prod = new clsProveedor_Producto();
            prov_prod.prov_prod = prov_pro;
            return prov_prod.Eliminar();
        }
    }
}