using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsDetalle_Factura
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Detalle_factura det_fact { get; set; }

        //public string Insertar()
        //{
        //    try
        //    {
        //        DBSpa.Productoes.Add(producto);
        //        DBSpa.SaveChanges();
        //        return "Producto insertado correctamente";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error al insertar Producto: " + ex.Message;
        //    }
        //}

        //public string Actualizar()
        //{
        //    Producto prod = ConsultarPorId(producto.Id);
        //    if (prod == null)
        //    {
        //        return "El id no es válido";
        //    }
        //    DBSpa.Productoes.AddOrUpdate(producto);
        //    DBSpa.SaveChanges();
        //    return "Se actualizó el producto correctamente";
        //}

        public Detalle_factura ConsultarPorId(int id)
        {
            Detalle_factura deta_fact = DBSpa.Detalle_factura.FirstOrDefault(u => u.Id == id);
            return deta_fact;
        }

        //public string Eliminar()
        //{
        //    try
        //    {
        //        Producto prod = ConsultarPorId(producto.Id);
        //        if (prod == null)
        //        {
        //            return "El id del producto no es válido";
        //        }
        //        DBSpa.Productoes.Remove(prod);
        //        DBSpa.SaveChanges();
        //        return "Se eliminó el producto correctamente";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}