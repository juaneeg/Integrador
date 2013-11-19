using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaReserva
    {
        public abstract string guardar(Entidades.Reserva res);
        public abstract List<Entidades.Reserva> lista();
    }
}