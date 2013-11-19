using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaMesa
    {
        public abstract string guardar(Entidades.Mesa mesa);
        public abstract List<Entidades.Mesa> lista();
    }
}