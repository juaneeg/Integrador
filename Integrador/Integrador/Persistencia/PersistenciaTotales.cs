using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaTotales
    {
        public abstract List<Entidades.Ranking> ranking();
        public abstract List<Entidades.Totales> totales(string filtro,DateTime fechaIni, DateTime fechaFin);
    }
}