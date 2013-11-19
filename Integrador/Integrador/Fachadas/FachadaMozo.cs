using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Fachadas
{
    public class FachadaMozo
    {
        public string guardar(string nombre, string apellido, string cedula,string pass, string tel, string dir, string email, int activo)
        {
            Entidades.Mozo mozo = new Entidades.Mozo();
            mozo.Nombre = nombre;
            mozo.Apellido = apellido;
            mozo.Cedula = cedula;
            mozo.Telefono = tel;
            mozo.Direccion = dir;
            mozo.Email = email;
            mozo.Activo = activo;
            Entidades.LogIn log = new Entidades.LogIn();
            log.Usuario = cedula;
            log.Password = pass;
            log.Tipo = 4;
            log.Persist = PersistenciaOleDb.PersistenciaOleDbLogIn.getInstancia();
            log.guardar(log);
            return PersistenciaOleDb.PersistenciaOleDbMozo.getInstancia().guardar(mozo);
        }

        public string eliminar(string cedula)
        {
            return PersistenciaOleDb.PersistenciaOleDbMozo.getInstancia().eliminar(cedula);
        }

        public Entidades.Mozo buscarXCedula(string cedula)
        {
            Entidades.Mozo m = new Entidades.Mozo();
            foreach (Entidades.Mozo mozo in PersistenciaOleDb.PersistenciaOleDbMozo.getInstancia().lista())
            {
                if (mozo.Cedula == cedula)
                {
                    m = mozo;
                    break;
                }
            }
            return m;
        }

        public List<Entidades.Mozo> lista()
        {
            return PersistenciaOleDb.PersistenciaOleDbMozo.getInstancia().lista();
        }
    }
}