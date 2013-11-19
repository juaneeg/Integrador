using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaMesaReserva
    {
        public abstract string guardar(Entidades.MesaReserva mr);
        public abstract List<Entidades.MesaReserva> lista();
        public abstract string eliminar(int idMesa, int idReserva);
    }
}