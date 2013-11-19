using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaLogIn
    {
        public Entidades.LogIn buscar(string usuario)
        {
            return PersistenciaOleDb.PersistenciaOleDbLogIn.getInstancia().buscar(usuario);
        }
    }
}