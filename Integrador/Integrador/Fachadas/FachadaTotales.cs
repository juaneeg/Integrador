using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Integrador.Fachadas
{
    public class FachadaTotales
    {
        public List<Entidades.Ranking> ranking()
        {
            return PersistenciaOleDb.PersistenciaOleDbTotales.getInstancia().ranking();
        }

        public List<Entidades.Totales> totales(string filtro, DateTime fechaIni, DateTime fechaFin)
        {
            return PersistenciaOleDb.PersistenciaOleDbTotales.getInstancia().totales(filtro, fechaIni, fechaFin);
        }
    }
}