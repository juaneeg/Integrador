using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class Reserva
    {
        private Persistencia.PersistenciaReserva persist = new PersistenciaOleDb.PersistenciaOleDbReserva();

        public Persistencia.PersistenciaReserva Persist
        {
            get { return persist; }
            set { persist = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int turno;

        public int Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private List<Entidades.Mesa> mesas = new List<Mesa>();

        public List<Entidades.Mesa> Mesas
        {
            get { return mesas; }
            set { mesas = value; }
        }

        public string guardar(Reserva res)
        {
            return persist.guardar(res);
        }
    }
}