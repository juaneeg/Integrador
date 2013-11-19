using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Principal : System.Web.UI.Page
    {
        Fachadas.FachadaLogIn fachadaLogIn = new Fachadas.FachadaLogIn();
        public static Entidades.LogIn log = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (log != null)
            {
                txtUsuario.Enabled = false;
                txtPass.Enabled = false;
                btnIniciar.Enabled = false;
                btnSalir.Visible = true;
                lblMensaje.Text = "Bienvenido " + log.Usuario;
            }
        }

        protected void btnIniciar_Click(object sender, ImageClickEventArgs e)
        {
            log = fachadaLogIn.buscar(txtUsuario.Text);
            if (log != null)
            {
                if (log.Password == txtPass.Text)
                {
                    lblMensaje.Text = "Bienvenido " + log.Usuario;
                    txtUsuario.Enabled = false;
                    txtUsuario.Text = "";
                    txtPass.Enabled = false;
                    btnIniciar.Enabled = false;
                    btnSalir.Visible = true;
                    cambiarMenu(log.Tipo);
                }
                else
                {
                    lblMensaje.Text = "Contraseña incorrecta";
                    txtPass.Focus();
                }
            }
        }

        public void cambiarMenu(int tipo)
        {
            Menu menu = (Menu)Master.FindControl("NavigationMenu");
            if (tipo == 0)
            {
                menu.FindItem("Mesas").Selectable = false;
                menu.FindItem("Cartas").Selectable = false;
                menu.FindItem("Platos").Selectable = false;
                menu.FindItem("Mozos").Selectable = false;
                menu.FindItem("Reservas").Selectable = false;
                menu.FindItem("Pedido").Selectable = false;
                menu.FindItem("Facturas").Selectable = false;
                menu.FindItem("Estadisticas").Selectable = false;
            }     
            else if(tipo == 1)
            {
                menu.FindItem("Mesas").Selectable = true;
                menu.FindItem("Cartas").Selectable = true;
                menu.FindItem("Platos").Selectable = true;
                menu.FindItem("Mozos").Selectable = true;
                menu.FindItem("Reservas").Selectable = true;
                menu.FindItem("Pedido").Selectable = true;
                menu.FindItem("Facturas").Selectable = true;
                menu.FindItem("Estadisticas").Selectable = true;
            }
            else if (tipo == 2)
            {
                menu.FindItem("Mesas").Selectable = true;
                menu.FindItem("Cartas").Selectable = false;
                menu.FindItem("Platos").Selectable = false;
                menu.FindItem("Mozos").Selectable = false;
                menu.FindItem("Reservas").Selectable = true;
                menu.FindItem("Pedido").Selectable = false;
                menu.FindItem("Facturas").Selectable = false;
                menu.FindItem("Estadisticas").Selectable = false;
            }
            else if (tipo == 3)
            {
                menu.FindItem("Mesas").Selectable = false;
                menu.FindItem("Cartas").Selectable = false;
                menu.FindItem("Platos").Selectable = false;
                menu.FindItem("Mozos").Selectable = false;
                menu.FindItem("Reservas").Selectable = false;
                menu.FindItem("Pedido").Selectable = false;
                menu.FindItem("Facturas").Selectable = true;
                menu.FindItem("Estadisticas").Selectable = false;
            }
            else if(tipo == 4)
            {
                menu.FindItem("Mesas").Selectable = false;
                menu.FindItem("Cartas").Selectable = false;
                menu.FindItem("Platos").Selectable = false;
                menu.FindItem("Mozos").Selectable = false;
                menu.FindItem("Reservas").Selectable = false;
                menu.FindItem("Pedido").Selectable = true;
                menu.FindItem("Facturas").Selectable = false;
                menu.FindItem("Estadisticas").Selectable = false; 
            }
        }

        protected void btnSalir_Click(object sender, ImageClickEventArgs e)
        {
            log = null;
            cambiarMenu(0);
            txtUsuario.Enabled = true;
            txtPass.Enabled = true;
            lblMensaje.Text = "";
            btnSalir.Visible = false;
            btnIniciar.Enabled = true;
        }
    }
}