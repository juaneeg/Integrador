using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaCartaPlato
    {
        public abstract Entidades.CartaPlatos guardar(Entidades.CartaPlatos carta);
    }
}