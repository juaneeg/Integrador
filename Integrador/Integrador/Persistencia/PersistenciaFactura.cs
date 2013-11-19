using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaFactura
    {
        public abstract Entidades.Factura guardar(Entidades.Factura fac);
    }
}