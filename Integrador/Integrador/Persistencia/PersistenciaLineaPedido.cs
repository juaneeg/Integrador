using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract  class PersistenciaLineaPedido
    {
        public abstract string guardar(Entidades.LineaPedido linea);
    }
}