using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaMozo
    {
        public abstract string guardar(Entidades.Mozo mozo);
        public abstract string eliminar(string cedula);
        public abstract List<Entidades.Mozo> lista();
    }
}