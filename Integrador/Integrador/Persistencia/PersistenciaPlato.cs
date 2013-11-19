using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaPlato
    {
        public abstract string guardar(Entidades.Plato plato);
        public abstract string eliminar(Entidades.Plato plato);
        public abstract List<Entidades.Plato> lista();
    }
}