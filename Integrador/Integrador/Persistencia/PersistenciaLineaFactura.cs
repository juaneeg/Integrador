using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaLineaFactura
    {
        public abstract string guardar(Entidades.LineaFactura linea);
    }
}