using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaMesaPedido
    {
        public abstract Entidades.MesaPedido guardar(Entidades.MesaPedido mp);
    }
}