using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsSede
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Sede sede { get; set; }
        public string Insertar()
        {
            try
            {
                DBSpa.Sedes.Add(sede);
                DBSpa.SaveChanges();
                return "Sede insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar sede: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Sede sed = ConsultarXIdSede(sede.Id);
            if (sed == null)
            {
                return "El Id de la sede no es válido";
            }
            DBSpa.Sedes.AddOrUpdate(sede);
            DBSpa.SaveChanges();
            return "Se actualizó la sede correctamente";
        }

        public Sede ConsultarXIdSede(int idSedes)
        {
            Sede sed = DBSpa.Sedes.FirstOrDefault(e => e.Id == idSedes);
            return sed;
        }

        public Sede ConsultarxNombre(string NombreSede)
        {
            Sede eve = DBSpa.Sedes.FirstOrDefault(e => e.Nombre == NombreSede);
            return eve;
        }

        public Sede ConsultarxDireccion(string DireccionSede)
        {
            Sede eve = DBSpa.Sedes.FirstOrDefault(e => e.Direccion == DireccionSede);
            return eve;
        }

        //consultar por sede por ciudad


        public string Eliminar()
        {
            try
            {
                Sede sed = ConsultarXIdSede(sede.Id);
                if (sed == null)
                {
                    return "El nombre de la sede no es válido";
                }
                DBSpa.Sedes.Remove(sed);
                DBSpa.SaveChanges();
                return "Se eliminó el sede correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}