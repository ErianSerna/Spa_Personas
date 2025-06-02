using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsProveedor_Producto
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Proveedor_Producto prov_prod { get; set; }

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

        public Proveedor_Producto ConsultarXProveedor(int id)
        {
            Proveedor_Producto prov_producto = DBSpa.Proveedor_Producto.FirstOrDefault(u => u.Id_Proveedor == id);
            return prov_producto;
        }

        public Proveedor_Producto ConsultarXId(int id)
        {
            Proveedor_Producto prov_producto = DBSpa.Proveedor_Producto.FirstOrDefault(u => u.Id == id);
            return prov_producto;
        }

        public Proveedor_Producto ConsultarXProducto(int id)
        {
            Proveedor_Producto prov_producto = DBSpa.Proveedor_Producto.FirstOrDefault(u => u.Id_Producto == id);
            return prov_producto;
        }

        public string Insertar()
        {
            try
            {
                DBSpa.Proveedor_Producto.Add(prov_prod);
                DBSpa.SaveChanges();
                return "Proveedor_Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar Proveedor_Producto: " + ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                Proveedor_Producto prov_produc = ConsultarXId(prov_prod.Id);
                if (prov_produc == null)
                {
                    return "El id del Proveedor_Producto no es válido";
                }
                DBSpa.Proveedor_Producto.Remove(prov_produc);
                DBSpa.SaveChanges();
                return "Se eliminó el Proveedor_Producto correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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