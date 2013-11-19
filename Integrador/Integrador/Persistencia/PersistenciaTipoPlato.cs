using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaTipoPlato
    {
        public abstract string guardar(Entidades.TipoPlato tipo);
        //public abstract string eliminar(Entidades.TipoPlato tipo);
    }
}