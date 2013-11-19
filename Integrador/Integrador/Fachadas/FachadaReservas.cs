using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaReservas
    {
        public List<Entidades.Reserva> lista()
        {
            return PersistenciaOleDb.PersistenciaOleDbReserva.getInstancia().lista();
        }
    }
}