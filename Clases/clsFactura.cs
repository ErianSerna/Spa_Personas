using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsFactura
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Factura factura { get; set; }
        public string Insertar()
        {
            try
            {
                DBSpa.Facturas.Add(factura);
                DBSpa.SaveChanges();
                return "Factura insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar factura: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Factura fact = ConsultarPorId(factura.Id);
            if (fact == null)
            {
                return "El id no es válido";
            }
            DBSpa.Facturas.AddOrUpdate(factura);
            DBSpa.SaveChanges();
            return "Se actualizó la factura correctamente";
        }

        public Factura ConsultarPorId(int id)
        {
            Factura fact = DBSpa.Facturas.FirstOrDefault(u => u.Id == id);
            return fact;
        }

        public string Eliminar()
        {
            try
            {
                Factura fact = ConsultarPorId(factura.Id);
                if (fact == null)
                {
                    return "El id de la factura no es válida";
                }
                DBSpa.Facturas.Remove(fact);
                DBSpa.SaveChanges();
                return "Se eliminó la factura correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}