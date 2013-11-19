using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaPedido
    {
        public abstract Entidades.Pedido guardar(Entidades.Pedido pedido);
        public abstract List<Entidades.Pedido> lista();
    }
}