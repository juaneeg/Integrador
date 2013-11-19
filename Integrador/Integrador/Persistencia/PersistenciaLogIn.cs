using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Persistencia
{
    public abstract class PersistenciaLogIn
    {
        public abstract string guardar(Entidades.LogIn log);
        public abstract Entidades.LogIn buscar(string usuario);
    }
}