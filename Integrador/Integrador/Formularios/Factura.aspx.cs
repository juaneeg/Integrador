using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Factura : System.Web.UI.Page
    {
        Fachadas.FachadaMesas fachadaMesas = new Fachadas.FachadaMesas();
        Fachadas.FachadaPedido fachadaPedido = new Fachadas.FachadaPedido();
        Fachadas.FachadaMozo fachadaMozo = new Fachadas.FachadaMozo();
        Fachadas.FachadaPlatos fachadaPlatos = new Fachadas.FachadaPlatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPedidos();
            }
        }

        public void cargarPedidos()
        {
            foreach (Entidades.Pedido p in PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia().lista())
            {
                ListItem it = new ListItem();
                it.Value = p.Id.ToString();
                it.Text = p.Cliente;
                ddlPedido.Items.Add(it);
            }
        }

        protected void ddlMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Entidades.Pedido p = fachadaPedido.buscarXID(Convert.ToInt32(ddlMesa.SelectedValue));
            Entidades.Pedido p = PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia().buscarXID(Convert.ToInt32(ddlPedido.SelectedValue));
            Entidades.Mozo m = PersistenciaOleDb.PersistenciaOleDbMozo.getInstancia().buscarXID(p.Mozo);
            foreach(Entidades.LineaPedido lp in PersistenciaOleDb.PersistenciaOleDbLineaPedido.getInstancia().buscarXPedido(p.Id))
            {
                Entidades.Plato plato = fachadaPlatos.buscarXID(lp.IdProducto);
                lblProductos.Items.Add("Producto: " + plato.Descripcion + " Precio $" + plato.Precio.ToString());
            }
            lblMozo.Text =m.Apellido + "," +m.Nombre;
            lbSubTotal.Text = p.Total.ToString();
            lbTotal.Text = (p.Total * 1.22).ToString();
            txtIDPedido.Text = p.Id.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Entidades.Factura factura = new Entidades.Factura();
            Entidades.Pedido pedido = fachadaPedido.buscarXID(Convert.ToInt32(txtIDPedido.Text));
            factura.Id = 0;
            factura.Monto = pedido.Total;
            factura.Total = (pedido.Total * 1.22);
            factura.Pedido = pedido.Id;
            factura.Fecha = DateTime.Now.Date;
            factura.Activo = 1;
            factura.Persist = PersistenciaOleDb.PersistenciaOleDbFactura.getInstancia();
            factura = factura.guardar(factura);
            pedido.Activo = 0;
            pedido.Persist = PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia();
            foreach (Entidades.MesaPedido mp in PersistenciaOleDb.PersistenciaOleDbMesaPedido.getInstancia().buscarXPedido(pedido.Id))
            {
                mp.Estado = 0;
                mp.IdMesa = mp.IdMesa;
                mp.IdPedido = mp.IdPedido;
                PersistenciaOleDb.PersistenciaOleDbMesaPedido.getInstancia().guardar(mp);
            }
            foreach (Entidades.LineaPedido lineas in PersistenciaOleDb.PersistenciaOleDbLineaPedido.getInstancia().buscarXPedido(pedido.Id))
            {
                lineas.Activo = 0;
                lineas.Persist = PersistenciaOleDb.PersistenciaOleDbLineaPedido.getInstancia();
                lineas.guardar(lineas);
            }
            pedido.guardar(pedido);
            limpiarPantalla();
        }

        public void limpiarPantalla()
        {
            ddlPedido.SelectedIndex = 0;
            lblMozo.Text = "";
            lblProductos.Items.Clear();
            lbSubTotal.Text = "";
            lbTotal.Text = "";
        }
    }
}