using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsCiudad
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Ciudad ciudad { get; set; }

        //public string Insertar()
        //{
        //    try
        //    {
        //        DBNati.Eventos.Add(evento);
        //        DBNati.SaveChanges();
        //        return "Evento insertado correctamente";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error al insertar evento: " + ex.Message;
        //    }
        //}

        //public string Actualizar()
        //{
        //    Evento eve = ConsultarPorIdEvento(evento.idEventos);
        //    if (eve == null)
        //    {
        //        return "El Id del evento no es válido";
        //    }
        //    DBNati.Eventos.AddOrUpdate(evento);
        //    DBNati.SaveChanges();
        //    return "Se actualizó el evento correctamente";
        //}

        public Ciudad ConsultarCiudades(string nombreCiudad)
        {
            Ciudad ciu = DBSpa.Ciudads.FirstOrDefault(c => c.Nombre == nombreCiudad);
            return ciu;
        }

        //public Evento ConsultarxNombre(string NombreEvento)
        //{
        //    Evento eve = DBNati.Eventos.FirstOrDefault(e => e.NombreEvento == NombreEvento);
        //    return eve;
        //}

        //public Evento ConsultarxFecha(DateTime Fecha)
        //{
        //    Evento eve = DBNati.Eventos.FirstOrDefault(e => e.FechaEvento == Fecha);
        //    return eve;
        //}

        //public Evento ConsultarxTipo(string tipo)
        //{
        //    Evento eve = DBNati.Eventos.FirstOrDefault(e => e.TipoEvento == tipo);
        //    return eve;
        //}
        //public string Eliminar()
        //{
        //    try
        //    {
        //        Evento even = ConsultarxNombre(evento.NombreEvento);
        //        if (even == null)
        //        {
        //            return "El nombre del evento no es válido";
        //        }
        //        DBNati.Eventos.Remove(even);
        //        DBNati.SaveChanges();
        //        return "Se eliminó el evento correctamente";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}