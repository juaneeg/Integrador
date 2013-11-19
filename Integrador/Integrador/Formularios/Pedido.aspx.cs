using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integrador.Formularios
{
    public partial class Pedido : System.Web.UI.Page
    {
        Fachadas.FachadaTipoPlato fachadaTipos = new Fachadas.FachadaTipoPlato();
        Fachadas.FachadaPlatos fachadaPlatos = new Fachadas.FachadaPlatos();
        Fachadas.FachadaMesas fachadaMesas = new Fachadas.FachadaMesas();
        Fachadas.FachadaMozo fachadaMozos = new Fachadas.FachadaMozo();
        Fachadas.FachadaPedido fachadaPedidos = new Fachadas.FachadaPedido();
        Fachadas.FachadaReservas fachadaReservas = new Fachadas.FachadaReservas();
        Fachadas.FachadaMesaReserva fachadaMesaReserva = new Fachadas.FachadaMesaReserva();
        static Entidades.Pedido pd = new Entidades.Pedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMozos();
                cargarTipos();
            }
        }

        public void cargarMesas()
        {
            ddlMesa.Items.Clear();
            ListItem it1 = new ListItem();
            it1.Value = "Seleccione";
            it1.Text = "Seleccione";
            ddlMesa.Items.Add(it1);
            foreach (Entidades.Mesa m in fachadaMesas.mesasLibresXFecha(DateTime.Now.Date,Convert.ToInt32(ddlTurno.SelectedValue)))
            {
                ListItem it = new ListItem();
                it.Value = m.Id.ToString();
                it.Text = m.Descripcion;
                ddlMesa.Items.Add(it);
            }
        }

        public void cargarMozos()
        {
            if (Formularios.Principal.log.Tipo == 4)
            {
                foreach (Entidades.Mozo mozo in fachadaMozos.lista())
                {
                    if (mozo.Cedula == Formularios.Principal.log.Usuario)
                    {
                        ListItem it = new ListItem();
                        it.Value = mozo.Id.ToString();
                        it.Text = mozo.Apellido + "," + mozo.Nombre;
                        ddlMozo.Items.Add(it);
                        ddlMozo.SelectedIndex = 1;
                        break;
                    }
                }
            }
            else
            {
                foreach (Entidades.Mozo mozo in fachadaMozos.lista())
                {
                        ListItem it = new ListItem();
                        it.Value = mozo.Id.ToString();
                        it.Text = mozo.Apellido + "," + mozo.Nombre;
                        ddlMozo.Items.Add(it);
                }
            }
            
        }

        public void cargarTipos()
        {
            foreach (Entidades.TipoPlato tp in fachadaTipos.listaParaCombos())
            {
                ListItem it = new ListItem();
                it.Value = tp.Id.ToString();
                it.Text = tp.Descrip;
                ddlTipo.Items.Add(it);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProducto.Items.Clear();
            ListItem it1 = new ListItem();
            it1.Value = "Seleccione";
            it1.Text = "Seleccione";
            ddlProducto.Items.Add(it1);
            foreach(Entidades.Plato p in fachadaPlatos.listaXTipo(Convert.ToInt32(ddlTipo.SelectedValue)))
            {
                ListItem it = new ListItem();
                it.Value = p.Id.ToString();
                it.Text = p.Descripcion;
                ddlProducto.Items.Add(it);
            }
        }


        private void crearPedido()
        {
            //pd = new Entidades.Pedido();
            pd.Persist = PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia();
            List<Entidades.Mesa> listaMesas = new List<Entidades.Mesa>();
            foreach (ListItem it in lblMesas.Items)
            {
                Entidades.Mesa m = PersistenciaOleDb.PersistenciaOleDbMesa.getInstancia().buscarXDescrip(it.Text);
                listaMesas.Add(m);
            }
            pd.Mesas = listaMesas;
            pd.Mozo = Convert.ToInt32(ddlMozo.SelectedValue);
            pd.Cliente = txtCliente.Text;
            pd.Activo = 1;
            pd.Fecha = DateTime.Now.Date;
            pd.Turno = Convert.ToInt32(ddlTurno.SelectedValue);
            pd.SubTotal = 0;
            pd.Total = 0;
            //pd.ListaProductos;
            pd = pd.guardar(pd);
            txtID.Text = pd.Id.ToString();
            if (RadioButtonList1.SelectedValue == "Reserva")
            {
                Entidades.Reserva res = PersistenciaOleDb.PersistenciaOleDbReserva.getInstancia().buscarXID(Convert.ToInt32(ddlReserva.SelectedValue));
                foreach (Entidades.MesaReserva mr in fachadaMesaReserva.listaXReserva(res.Id))
                {
                    mr.Activo = 0;
                    mr.Persist = PersistenciaOleDb.PersistenciaOleDbMesaReserva.getInstancia();
                    mr.guardar(mr);
                }
                res.Activo = 0;
                res.Persist = PersistenciaOleDb.PersistenciaOleDbReserva.getInstancia();
                res.guardar(res);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pd.Persist = PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia();
            pd.SubTotal = Convert.ToDouble(lblSubTotal.Text);
            pd.Total = Convert.ToDouble(lblTotal.Text);
            pd = pd.guardar(pd);
            limpiarPantalla();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (RadioButtonList1.SelectedValue == "Nuevo")
            {
                lblReserva.Visible = false;
                ddlReserva.Visible = false;
                ddlMesa.Enabled = true;
                btnAgregarMesa.Enabled = true;
                lblPedido.Visible = false;
                ddlPedido.Visible = false;
                ddlMozo.Enabled = true;
                btnCrear.Enabled = true;
                ddlTurno.Enabled = true;
            }
            else if (RadioButtonList1.SelectedValue == "Reserva")
            {
                lblReserva.Visible = true;
                ddlReserva.Visible = true;
                ddlReserva.Items.Clear();
                ddlMesa.Enabled = false;
                btnAgregarMesa.Enabled = false;
                lblPedido.Visible = false;
                ddlPedido.Visible = false;
                ddlMozo.Enabled = true;
                ddlTurno.Enabled = false;
                btnCrear.Enabled = true;
                ListItem it1 = new ListItem();
                it1.Value = "Seleccione";
                it1.Text = "Seleccione";
                ddlReserva.Items.Add(it1);
                foreach (Entidades.Reserva r in fachadaReservas.lista())
                {
                    ListItem it = new ListItem();
                    it.Value = r.Id.ToString();
                    it.Text = r.Cliente;
                    ddlReserva.Items.Add(it);
                }
            }
            else
            {
                lblPedido.Visible = true;
                ddlPedido.Visible = true;
                lblReserva.Visible = false;
                ddlReserva.Visible = false;
                ddlMesa.Enabled = false;
                btnAgregarMesa.Enabled = false;
                ddlMozo.Enabled = false;
                btnCrear.Enabled = false;
                ddlTurno.Enabled = false;
                ddlPedido.Items.Clear();
                ListItem it1 = new ListItem();
                it1.Value = "Seleccione";
                it1.Text = "Seleccione";
                ddlPedido.Items.Add(it1);
                if (Formularios.Principal.log.Tipo == 4)
                {
                    foreach (Entidades.Pedido p in PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia().lista())
                    {
                        if (p.Mozo == fachadaMozos.buscarXCedula(Formularios.Principal.log.Usuario).Id)
                        {
                            ListItem it = new ListItem();
                            it.Value = p.Id.ToString();
                            it.Text = p.Cliente;
                            ddlPedido.Items.Add(it);
                        }
                    }
                }
                else
                {
                    foreach (Entidades.Pedido p in PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia().lista())
                    {
                      ListItem it = new ListItem();
                      it.Value = p.Id.ToString();
                      it.Text = p.Cliente;
                      ddlPedido.Items.Add(it);
                    }
                }
            }
            limpiarPantalla();
        }

        protected void ddlReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMesas.Items.Clear();
            Entidades.Reserva res = PersistenciaOleDb.PersistenciaOleDbReserva.getInstancia().buscarXID(Convert.ToInt32(ddlReserva.SelectedValue));
            foreach (Entidades.Mesa m in res.Mesas)
            {
                lblMesas.Items.Add(m.Descripcion);
            }
            txtCliente.Text = res.Cliente;
            ddlTurno.SelectedValue = res.Turno.ToString();
        }

        private void limpiarPantalla()
        {
            ddlMesa.SelectedIndex = 0;
            lblMesas.Items.Clear();
            ddlMozo.SelectedIndex = 0;
            ddlProducto.SelectedIndex = 0;
            ddlReserva.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            txtCantidad.Text = "1";
            txtID.Text = "0";
            lbProductos.Items.Clear();
            lblSubTotal.Text = "0";
            lblTotal.Text = "0";
            txtCliente.Text = "";
            ddlTurno.SelectedIndex = 0;
            pd.Id = 0;
        }

        protected void ddlPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMesas.Items.Clear();
            lbProductos.Items.Clear();
            Entidades.Pedido pedido = PersistenciaOleDb.PersistenciaOleDbPedido.getInstancia().buscarXID(Convert.ToInt32(ddlPedido.SelectedValue));
            //pd = new Entidades.Pedido();
            pd.Id = pedido.Id;
            pd.Activo = pedido.Activo;
            pd.Cliente = pedido.Cliente;
            pd.Fecha = pedido.Fecha;
            pd.Turno = pedido.Turno;
            pd.ListaProductos = pedido.ListaProductos;
            pd.Mesas = pedido.Mesas;
            pd.Mozo = pedido.Mozo;
            pd.SubTotal = pedido.SubTotal;
            pd.Total = pedido.Total;
            txtCliente.Text = pedido.Cliente;
            ddlMozo.SelectedValue = pedido.Mozo.ToString();
            ddlTurno.SelectedValue = pedido.Turno.ToString();
            foreach (Entidades.Mesa m in pedido.Mesas)
            {
                lblMesas.Items.Add(m.Descripcion);
            }
            foreach(Entidades.LineaPedido lp in PersistenciaOleDb.PersistenciaOleDbLineaPedido.getInstancia().buscarXPedido(pedido.Id))
            {
                Entidades.Plato p = fachadaPlatos.buscarXID(lp.IdProducto);
                lbProductos.Items.Add("Producto: " + p.Descripcion + " " + "Cantidad: " + lp.Cantidad + " " + "SubTotal: " + p.Precio + " " + "Total: " + (lp.Cantidad * p.Precio).ToString());
                lblSubTotal.Text = pedido.SubTotal.ToString();
                lblTotal.Text = pedido.Total.ToString(); 
            }
        }

        protected void btnAgregarMesa_Click1(object sender, ImageClickEventArgs e)
        {
            lblMesas.Items.Add(ddlMesa.SelectedItem.Text);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            crearPedido();
        }

        protected void btnAgregar_Click1(object sender, ImageClickEventArgs e)
        {
            Entidades.Plato plato = fachadaPlatos.buscarXID(Convert.ToInt32(ddlProducto.SelectedValue));
            Entidades.LineaPedido lp = new Entidades.LineaPedido();
            lp.IdProducto = plato.Id;
            lp.IdPedido = pd.Id;
            lp.Cantidad = Convert.ToInt32(txtCantidad.Text);
            lp.Activo = 1;
            lp.Persist = PersistenciaOleDb.PersistenciaOleDbLineaPedido.getInstancia();
            lp.guardar(lp);
            pd.ListaProductos.Add(plato);
            lbProductos.Items.Add("Producto: " + plato.Descripcion + " " + "Cantidad: " + txtCantidad.Text + " " + "SubTotal: " + plato.Precio + " " + "Total: " + (Convert.ToInt32(txtCantidad.Text) * plato.Precio).ToString());
            lblSubTotal.Text = (Convert.ToDouble(lblSubTotal.Text) + plato.Precio).ToString();
            lblTotal.Text = (Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(lblSubTotal.Text) * Convert.ToInt32(txtCantidad.Text))).ToString();
        }

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            cargarMesas();
        }

    }
}