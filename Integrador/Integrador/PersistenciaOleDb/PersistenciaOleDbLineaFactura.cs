using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.PersistenciaOleDb
{
    public class PersistenciaOleDbLineaFactura : Persistencia.PersistenciaLineaFactura 
    {
        private static PersistenciaOleDbLineaFactura instancia = null;

        public PersistenciaOleDbLineaFactura getInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaOleDbLineaFactura();
            return instancia;
        }

        public override string guardar(Entidades.LineaFactura linea)
        {
            throw new NotImplementedException();
        }
    }
}