using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class LogIn
    {
        private Persistencia.PersistenciaLogIn persist = null;

        public Persistencia.PersistenciaLogIn Persist
        {
            get { return persist; }
            set { persist = value; }
        }
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string guardar(LogIn log)
        {
            return persist.guardar(log);
        }

        public LogIn buscar(string usuario)
        {
            return persist.buscar(usuario);
        }
    }
}