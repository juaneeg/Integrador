using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Entidades
{
    public class Totales
    {
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private double totalProduccion;

        public double TotalProduccion
        {
            get { return totalProduccion; }
            set { totalProduccion = value; }
        }
        private double totalCobrado;

        public double TotalCobrado
        {
            get { return totalCobrado; }
            set { totalCobrado = value; }
        }
    }
}