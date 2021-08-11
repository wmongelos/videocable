using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmFacturaManual : Form
    {
        private DataTable dt = new DataTable();
        private DataTable dtFinal = new DataTable();
        private DataTable dtRespuestaCompAFactura = new DataTable();
        private DataTable dtDatosUsuarioLoc = new DataTable();
        private DataRow drDatosUsuario;
        private int idUsuarioLocacion;
        private int idUsuario;
        private Comprobantes oComprobantes = new Comprobantes();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();

        public frmFacturaManual(int idUsuario, int idUsuarioLocacion)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idUsuarioLocacion = idUsuarioLocacion;
        }

        private void frmFacturaManual_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            cboServUnicos.DataSource = new Servicios().ListarPorModalidad(Servicios._Modalidad.UNICO);
            cboServUnicos.DisplayMember = "descripcion";
            cboServUnicos.ValueMember = "id";
            cboServUnicos.SelectedIndexChanged += new EventHandler(this.cboServUnicos_SelectedIndexChanged);
            cboServUnicos.SelectedIndex = 0;

            dtDatosUsuarioLoc = new Usuarios_Locaciones().ListarDatosLocacion(idUsuarioLocacion);
            drDatosUsuario = new Usuarios().getDatos(idUsuario);

            dt.Columns.Add(new DataColumn("descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("precio", typeof(decimal)));
            dt.Columns.Add(new DataColumn("cantidad", typeof(decimal)));

            dgv.DataSource = dt;

            FormatearDGV();
            ActualizarCabecera();
        }

        private void FormatearDGV()
        {
            dgv.Columns["descripcion"].HeaderText = "Descripcion";
            dgv.Columns["precio"].HeaderText = "Precio unitario";
            dgv.Columns["precio"].DefaultCellStyle.Format = "C2";
            dgv.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["cantidad"].HeaderText = "Cantidad";
            dgv.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewLinkColumn linkCol = new DataGridViewLinkColumn()
            {
                Text = "Quitar",
                DataPropertyName = "Quitar",
                Name = "quitar",
                LinkColor = Color.Red,
                VisitedLinkColor = Color.Red,
                UseColumnTextForLinkValue = true,
                HeaderText = "Quitar"
            };
            linkCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(linkCol);
        }

        private void ActualizarCabecera()
        {
            lblUsuario.Text = $"Usuario: {drDatosUsuario["apellido"]}, {drDatosUsuario["nombre"]}[{drDatosUsuario["codigo"]}]";
            lblUsuarioLoc.Text = $"Locacion: {dtDatosUsuarioLoc.Rows[0]["localidad"]}, Calle:{dtDatosUsuarioLoc.Rows[0]["calle"]}, Altura:{dtDatosUsuarioLoc.Rows[0]["altura"]}";
        }

        private void AsignarItem()
        {
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Es necesario introducir una descripcion", "Mensaje del sistema");
                txtDescripcion.Focus();
                return;
            }

            if (!String.IsNullOrEmpty(txtPrecioUnitario.Text.Trim()) && !Decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precio))
            {
                MessageBox.Show("El campo del precio unitario debe estar vacio o ser un numero", "Mensaje del sistema");
                txtPrecioUnitario.Focus();
                return;
            }
            
            if (!String.IsNullOrEmpty(txtCantidad.Text.Trim()) && !Decimal.TryParse(txtCantidad.Text.Trim(), out decimal cantidad))
            {
                MessageBox.Show("El campo de la cantidad debe estar vacio o ser un numero", "Mensaje del sistema");
                txtCantidad.Focus();
                return;
            }

            DataRow dr = dt.NewRow();
            dr["descripcion"] = txtDescripcion.Text.Trim();
            dr["precio"] = String.IsNullOrEmpty(txtPrecioUnitario.Text) ? 0 : Convert.ToDecimal(txtPrecioUnitario.Text);
            dr["cantidad"] = String.IsNullOrEmpty(txtCantidad.Text) ? 0 : Convert.ToDecimal(txtCantidad.Text);
            dt.Rows.Add(dr);

            dgv.Rows[dt.Rows.Count - 1].Cells["Quitar"].Value = "quitar";

            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";

            lblTotal.Text = $"Total de Registros: {dgv.Rows.Count}";
        }

        private void CrearYGuardarComprobante()
        {
            DataRow drDatosComprobanteVenta = new Comprobantes_Tipo().GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
            int nComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);

            if (nComprobante > 0)
                new Comprobantes_Tipo().SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), nComprobante);

            oComprobantes.Id_Usuarios = idUsuario;
            oComprobantes.Fecha = DateTime.Today;
            oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
            oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
            oComprobantes.Numero = nComprobante;
            oComprobantes.Importe = 0;

            foreach (DataRow detalle in dt.Rows)
                oComprobantes.Importe += Convert.ToDecimal(detalle["precio"]) * Convert.ToDecimal(detalle["cantidad"]);

            oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(idUsuarioLocacion);
            oComprobantes.Id_Personal = Personal.Id_Login;
            oComprobantes.Id = oComprobantes.Guardar(oComprobantes);
        }

        private void CrearYGuardarCtaCteYCtaCteDet()
        {
            oUsuariosCtaCte.Id_Usuarios = oComprobantes.Id_Usuarios;
            oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
            oUsuariosCtaCte.Fecha_Movimiento = DateTime.Today;
            oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
            oUsuariosCtaCte.Fecha_Desde = DateTime.Now; //ver
            oUsuariosCtaCte.Fecha_Hasta = DateTime.Now; //ver
            string muestra;
            char pad = '0';
            muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(oComprobantes.Punto_Venta).ToString().PadLeft(4, pad) + "-" + oUsuariosCtaCte.Numero.ToString().PadLeft(8, pad);
            oUsuariosCtaCte.Descripcion = muestra;
            oUsuariosCtaCte.Importe_Original = oComprobantes.Importe;
            oUsuariosCtaCte.Importe_Punitorio = 0;
            oUsuariosCtaCte.Importe_Bonificacion = 0;
            oUsuariosCtaCte.Importe_Final = oComprobantes.Importe;
            oUsuariosCtaCte.Importe_Saldo = oUsuariosCtaCte.Importe_Final;
            oUsuariosCtaCte.Id_Usuarios_Locacion = oComprobantes.Id_Usuarios_Locaciones;
            oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
            oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
            oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
            oUsuariosCtaCte.Id_Facturacion = 0;
            oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
            oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
            oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.COMPROBANTE_DETALLADO;
            oUsuariosCtaCte.Percepcion = 1;
            oUsuariosCtaCte.Guardar(oUsuariosCtaCte);

            foreach (DataRow dr in dt.Rows)
            {
                Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
                oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                oUsuariosCtaCteDet.Id_Usuarios_Locaciones = oUsuariosCtaCte.Id_Usuarios_Locacion;
                oUsuariosCtaCteDet.Id_Zonas = 0; //ver
                oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(cboServUnicos.SelectedValue.ToString());
                oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(cboSubservicios.SelectedValue.ToString());
                oUsuariosCtaCteDet.Tipo = "S"; //Unico
                oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(dr["precio"]) * Convert.ToDecimal(dr["cantidad"]);
                oUsuariosCtaCteDet.Importe_Punitorio = 0;
                oUsuariosCtaCteDet.Importe_Saldo = Convert.ToDecimal(dr["precio"]) * Convert.ToDecimal(dr["cantidad"]);
                oUsuariosCtaCteDet.Importe_Final = Convert.ToDecimal(dr["precio"]) * Convert.ToDecimal(dr["cantidad"]);
                oUsuariosCtaCteDet.Importe_Bonificacion = 0;
                oUsuariosCtaCteDet.Id_Usuarios_Servicios = 0;
                oUsuariosCtaCteDet.Id_Velocidades_Tip = 0;
                oUsuariosCtaCteDet.Id_Velocidades = 0;
                oUsuariosCtaCteDet.Requiere_IP = 0;
                oUsuariosCtaCteDet.Cantidad_Periodos = 0;
                oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = 0;
                oUsuariosCtaCteDet.Fecha_Desde = DateTime.Now;
                oUsuariosCtaCteDet.Fecha_Hasta = DateTime.Now;
                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE;
                oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                oUsuariosCtaCteDet.Nombre_Bonificacion = "";
                oUsuariosCtaCteDet.Periodo_Mes = DateTime.Now.Month;
                oUsuariosCtaCteDet.Periodo_Ano = DateTime.Now.Year;
                oUsuariosCtaCteDet.Detalles = dr["descripcion"].ToString();
                oUsuariosCtaCteDet.Cantidad = Convert.ToDecimal(dr["cantidad"]);
                oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);
            }
        }

        private void LimpiarObjetos()
        {
            dt.Reset();
            dtFinal.Reset();
            dtDatosUsuarioLoc.Reset();
            dtRespuestaCompAFactura = new DataTable();
            oComprobantes = new Comprobantes();
            oUsuariosCtaCte = new Usuarios_CtaCte();

            CargarDatos();
        }

        private void Guardar()
        {
            CrearYGuardarComprobante();
            CrearYGuardarCtaCteYCtaCteDet();
            MessageBox.Show("Se genero el comprobante correctamente", "Mensaje del sistema");
            LimpiarObjetos();
        }

        private void btnAgregarAGrilla_Click(object sender, EventArgs e)
        {
            AsignarItem();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Guardar();
            }
            else
            {
                MessageBox.Show("Debe haber al menos un registro", "Mensaje del sistema");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Columns[e.ColumnIndex].Name == "quitar")
            {
                dt.Rows.Remove(dt.Rows[e.RowIndex]);

                lblTotal.Text = $"Total de Registros: {dgv.Rows.Count}";
            }
        }

        private void cboServUnicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSubservicios.DataSource = new Servicios_Sub().ListarPorServicio(Convert.ToInt32(cboServUnicos.SelectedValue));
            cboSubservicios.DisplayMember = "descripcion";
            cboSubservicios.ValueMember = "id";
        }

        private void frmFacturaManual_Shown(object sender, EventArgs e)
        {
            try
            {
                cboSubservicios.DataSource = new Servicios_Sub().ListarPorServicio(Convert.ToInt32(cboServUnicos.SelectedValue));
                cboSubservicios.DisplayMember = "descripcion";
                cboSubservicios.ValueMember = "id";
            }
            catch {}
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacturaManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
