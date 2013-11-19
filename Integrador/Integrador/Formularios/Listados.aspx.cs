using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Listados : System.Web.UI.Page
    {
        Fachadas.FachadaTotales fachadaTotales = new Fachadas.FachadaTotales();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvRanking.DataSource = fachadaTotales.ranking();
            gvRanking.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "1")
            {
                lblFiltro.Visible = false;
                ddlFiltro.Visible = false;
                lblInicial.Visible = false;
                lblFinal.Visible = false;
                txtFechaIni.Visible = false;
                txtFechaFin.Visible = false;
                btnActualizar.Visible = false;
                gvRanking.DataSource = fachadaTotales.ranking();
                gvRanking.DataBind();
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                gvRanking.DataSource = "";
                gvRanking.DataBind();
                txtFechaIni.Text = "";
                txtFechaFin.Text = "";
                ddlFiltro.SelectedIndex = 0;
                lblFiltro.Visible = true;
                ddlFiltro.Visible = true;
                lblInicial.Visible = true;
                lblFinal.Visible = true;
                txtFechaIni.Visible = true;
                txtFechaFin.Visible = true;
                btnActualizar.Visible = true;
            }
        }

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            gvRanking.DataSource = fachadaTotales.totales(ddlFiltro.SelectedValue,DateTime.Parse(txtFechaIni.Text),DateTime.Parse(txtFechaFin.Text));
            gvRanking.DataBind();
        }
    }
}