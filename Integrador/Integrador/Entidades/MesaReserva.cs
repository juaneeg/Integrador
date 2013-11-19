using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class MesaReserva
    {
        private Persistencia.PersistenciaMesaReserva persist = null;

        public Persistencia.PersistenciaMesaReserva Persist
        {
            get { return persist; }
            set { persist = value; }
        }
        private int idMesa;

        public int IdMesa
        {
            get { return idMesa; }
            set { idMesa = value; }
        }
        private int idReserva;

        public int IdReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }

        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public string guardar(Entidades.MesaReserva mr)
        {
            return persist.guardar(mr);
        }
    }
}