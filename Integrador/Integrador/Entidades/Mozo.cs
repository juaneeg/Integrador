using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class Mozo
    {
        private Persistencia.PersistenciaMozo persist = null;

        public Persistencia.PersistenciaMozo Persist
        {
            get { return persist; }
            set { persist = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string cedula;

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int activo;

        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string guardar(Mozo mozo)
        {
            return persist.guardar(mozo);
        }

        public override string ToString()
        {
            return nombre + " " + apellido + " " + cedula + " " + telefono + " " + direccion + " " + email;
        }
    }
}