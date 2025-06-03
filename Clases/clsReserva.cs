using Spa_Personas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Spa_Personas.Clases
{
	public class clsReserva
	{
        private DBSpaPersonasEntities DBSpa = new DBSpaPersonasEntities();
        public Reserva reserva { get; set; }
        public string Insertar()
        {
            try
            {
                DBSpa.Reservas.Add(reserva);
                DBSpa.SaveChanges();
                return "Reserva insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar reserva: " + ex.Message;
            }
        }

        public List<Reserva> ConsultarTodos()
        {
            return DBSpa.Reservas
                .OrderBy(e => e.Id)
                .ToList();
        }

        public string Actualizar()
        {
            Reserva reserv = ConsultarPorId(reserva.Id);
            if (reserv == null)
            {
                return "El id no es válido";
            }
            DBSpa.Reservas.AddOrUpdate(reserva);
            DBSpa.SaveChanges();
            return "Se actualizó la reserva correctamente";
        }

        public Reserva ConsultarPorId(int id)
        {
            Reserva reserv = DBSpa.Reservas.FirstOrDefault(u => u.Id == id);
            return reserv;
        }

        public Reserva ConsultarPorCodigoReserva(string codigoReserva)
        {
            Reserva reserv = DBSpa.Reservas.FirstOrDefault(u => u.Codigo == codigoReserva);
            return reserv;
        }

        public string Eliminar()
        {
            try
            {
                Reserva reserv = ConsultarPorCodigoReserva(reserva.Codigo);
                if (reserv == null)
                {
                    return "El codigo de la reserva no es válido";
                }
                DBSpa.Reservas.Remove(reserv);
                DBSpa.SaveChanges();
                return "Se eliminó la reserva correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}