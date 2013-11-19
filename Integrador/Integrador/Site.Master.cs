using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.LogIn log = Formularios.Principal.log;
            if(log != null)
            cambiarMenu(Formularios.Principal.log.Tipo);
        }

        public void cambiarMenu(int tipo)
        {
            if (tipo == 1)
            {
                NavigationMenu.FindItem("Mesas").Selectable = true;
                NavigationMenu.FindItem("Cartas").Selectable = true;
                NavigationMenu.FindItem("Platos").Selectable = true;
                NavigationMenu.FindItem("Mozos").Selectable = true;
                NavigationMenu.FindItem("Reservas").Selectable = true;
                NavigationMenu.FindItem("Pedido").Selectable = true;
                NavigationMenu.FindItem("Facturas").Selectable = true;
                NavigationMenu.FindItem("Estadisticas").Selectable = true;
            }
            else if (tipo == 2)
            {
                NavigationMenu.FindItem("Mesas").Selectable = true;
                NavigationMenu.FindItem("Cartas").Selectable = false;
                NavigationMenu.FindItem("Platos").Selectable = false;
                NavigationMenu.FindItem("Mozos").Selectable = false;
                NavigationMenu.FindItem("Reservas").Selectable = true;
                NavigationMenu.FindItem("Pedido").Selectable = false;
                NavigationMenu.FindItem("Facturas").Selectable = false;
                NavigationMenu.FindItem("Estadisticas").Selectable = false;
            }
            else if (tipo == 3)
            {
                NavigationMenu.FindItem("Mesas").Selectable = false;
                NavigationMenu.FindItem("Cartas").Selectable = false;
                NavigationMenu.FindItem("Platos").Selectable = false;
                NavigationMenu.FindItem("Mozos").Selectable = false;
                NavigationMenu.FindItem("Reservas").Selectable = false;
                NavigationMenu.FindItem("Pedido").Selectable = false;
                NavigationMenu.FindItem("Facturas").Selectable = true;
                NavigationMenu.FindItem("Estadisticas").Selectable = false;
            }
            else if (tipo == 4)
            {
                NavigationMenu.FindItem("Mesas").Selectable = false;
                NavigationMenu.FindItem("Cartas").Selectable = false;
                NavigationMenu.FindItem("Platos").Selectable = false;
                NavigationMenu.FindItem("Mozos").Selectable = false;
                NavigationMenu.FindItem("Reservas").Selectable = false;
                NavigationMenu.FindItem("Pedido").Selectable = true;
                NavigationMenu.FindItem("Facturas").Selectable = false;
                NavigationMenu.FindItem("Estadisticas").Selectable = false;
            }
        }
    }
}
