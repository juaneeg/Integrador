using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaTipoPlato
    {
        public Entidades.TipoPlato buscarXID(int id)
        {
           return PersistenciaOleDb.PersistenciaOleDbTipoPlato.getInstancia().buscarXID(id);
        }

        public List<Entidades.TipoPlato> listaParaCombos()
        {
            return PersistenciaOleDb.PersistenciaOleDbTipoPlato.getInstancia().lista();
        }
    }
}