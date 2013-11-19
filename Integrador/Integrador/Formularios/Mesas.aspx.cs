using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Mesas : System.Web.UI.Page
    {
        Fachadas.FachadaMesas fachadaMesas = new Fachadas.FachadaMesas();
        protected void Page_Load(object sender, EventArgs e)
        {
            renovar();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = fachadaMesas.guardar(Convert.ToInt32(txtID.Text),txtDescripcion.Text, Convert.ToInt32(txtCapacidad.Text), ddlEstado.SelectedValue);
            limpiarPantalla();
        }

        private void limpiarPantalla()
        {
            txtDescripcion.Text = "";
            txtCapacidad.Text = "";
            txtID.Text = "0";
            ddlEstado.SelectedIndex = 0;
            renovar();
        }

        public void renovar()
        {
            grillaMesas.DataSource = fachadaMesas.lista();
            grillaMesas.DataBind();
        }

        protected void grillaMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = grillaMesas.SelectedRow.Cells[1].Text;
            txtDescripcion.Text = grillaMesas.SelectedRow.Cells[2].Text;
            txtCapacidad.Text = grillaMesas.SelectedRow.Cells[3].Text;
            ddlEstado.SelectedValue = grillaMesas.SelectedRow.Cells[4].Text;
        }
    }
}