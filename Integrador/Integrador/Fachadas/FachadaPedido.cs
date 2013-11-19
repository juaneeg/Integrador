using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaPedido
    {
        public Entidades.Pedido buscarXID(int id)
        {
            return PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia().buscarXID(id);
        }
    }
}