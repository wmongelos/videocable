using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class FrmUsuariosCtaCteDetalles : Form
    {
        #region [PROPIEDADES]
        public Int32 idViene;
        public String tipoViene, lb1, datosUsuarios, datosLocacion;
        public DateTime fechaDesde, fechaHasta;
        private Thread hilo;
        private delegate void myDel();
        private frmUsuariosCtacteDetExtras oFrmExtras;
        private frmPopUp oPop;
        private Servicios oServicios = new Servicios();
        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuCtaCteDet = new Usuarios_CtaCte_Det();
        private Usuarios_CtaCte Ousuarios_CtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det Ousuarios_CtaCte_Det = new Usuarios_CtaCte_Det();
        private Usuarios_CtaCte_Recibos Ousuarios_CtaCte_Recibos = new Usuarios_CtaCte_Recibos();
        private Int32 id;
        private string tipo;
        private Decimal total;
        private DataTable dtdetallefacturas, dtctacterelacion, dtdetallerecibos, dtDatosServicio;
        #endregion

        #region [METODOS]
        private void Comenzarcagra()
        {
            dgvDetalles.DataSource = null;
            dgvRelacion.DataSource = null;

            pgCircular.Start();

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                switch (tipoViene)
                {
                    case "F":
                        dtdetallefacturas = Ousuarios_CtaCte_Det.ListarDetalle(this.idViene);

                        DataView dv = dtdetallefacturas.DefaultView;
                        dv.Sort = "id_servicios desc";
                        dtdetallefacturas = dv.ToTable();

                        dtctacterelacion = Ousuarios_CtaCte_Recibos.ListarCtaCteRelacion(this.idViene, 0, 0);
                        break;
                    case "R":
                        dtdetallerecibos = Ousuarios_CtaCte_Recibos.ListarCtaCteRecibosdet(this.idViene, "ID");
                        dtctacterelacion = Ousuarios_CtaCte_Recibos.ListarCtaCteRelacion(0, this.idViene, 0);
                        break;
                    default:
                        break;
                }

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch { }
        }

        private void AsignarDatos()
        {
            switch (tipoViene)
            {
                case "F":
                    Facturas();
                    break;
                case "R":
                    Recibos();
                    break;
                default:
                    break;
            }


            lblocalidad.Text = datosLocacion;
            lblUsuario.Text = datosUsuarios;
            lbtexto1.Text = this.lb1;
            lbtexto1.Location = new System.Drawing.Point(this.Size.Width - lbtexto1.Width, lbtexto1.Location.Y);
            lblFechaDesdeDato.Text = fechaDesde.ToShortDateString();
            lblFechaHastaDato.Text = fechaHasta.ToShortDateString();

            lblTotalDato.Location = new System.Drawing.Point(this.Width - lblTotalDato.Width, lblTotalDato.Location.Y);
            lblTotal.Location = new System.Drawing.Point(this.Width - lblTotalDato.Width - lblTotal.Width, lblTotal.Location.Y);
        }

        private void Facturas()
        {
            lbtexto2.Text = "CANCELADOS CON RECIBOS";
            lbtexto2.Location = new System.Drawing.Point(this.Size.Width - lbtexto2.Width, lbtexto2.Location.Y);

            DataColumn clmTotal = new DataColumn("total", typeof(Decimal));
            dtdetallefacturas.Columns.Add(clmTotal);

            foreach (DataRow item in dtdetallefacturas.Rows)
            {
                int idServicio = Convert.ToInt32(item["id_servicios"]);

                dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);

                if (dtDatosServicio.Rows.Count > 0)
                {
                    string requiereVelocidad = dtDatosServicio.Rows[0]["requiere_velocidad"].ToString();

                    if (requiereVelocidad == "SI")
                        if (item["velocidad"].ToString().Equals(""))
                            item["servicio"] = item["servicio"].ToString();
                        else
                            item["servicio"] = item["servicio"].ToString() + " " + item["velocidad"].ToString() + " MB " + item["velocidad_tipo"].ToString();

                }
                item["total"] = Convert.ToDecimal(item["Importe_original"]) + Convert.ToDecimal(item["importe_punitorio"]) - Convert.ToDecimal(item["Importe_bonificacion"]) + Convert.ToDecimal(item["Importe_provincial"]);
                total = total + Convert.ToDecimal(item["total"]);
            }

            lblTotalDato.Text = total.ToString("c");
            dgvDetalles.DataSource = dtdetallefacturas;

            for (int i = 0; i < dtdetallefacturas.Columns.Count; i++)
                dgvDetalles.Columns[i].Visible = false;


            dgvDetalles.Columns["servicio"].Visible = true;
            dgvDetalles.Columns["servicio"].HeaderText = "SERVICIO";
            dgvDetalles.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvDetalles.Columns["sub_servicio"].Visible = true;
            dgvDetalles.Columns["sub_servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalles.Columns["sub_servicio"].HeaderText = "SUBSERVICIO";

            dgvDetalles.Columns["Importe_original"].Visible = true;
            dgvDetalles.Columns["Importe_original"].DefaultCellStyle.Format = "c2";
            dgvDetalles.Columns["Importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["Importe_original"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalles.Columns["Importe_original"].HeaderText = "IMPORTE ORIGINAL";

            dgvDetalles.Columns["importe_punitorio"].Visible = true;
            dgvDetalles.Columns["importe_punitorio"].DefaultCellStyle.Format = "c2";
            dgvDetalles.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe_punitorio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDetalles.Columns["importe_punitorio"].HeaderText = "IMPORTE PUNITORIO";

            dgvDetalles.Columns["Importe_bonificacion"].Visible = true;
            dgvDetalles.Columns["Importe_bonificacion"].DefaultCellStyle.Format = "c2";
            dgvDetalles.Columns["Importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["Importe_bonificacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDetalles.Columns["Importe_bonificacion"].HeaderText = "IMPORTE BONIFICACION";


            dgvDetalles.Columns["Importe_provincial"].Visible = true;
            dgvDetalles.Columns["Importe_provincial"].DefaultCellStyle.Format = "c2";
            dgvDetalles.Columns["Importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["Importe_provincial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalles.Columns["Importe_provincial"].HeaderText = "IMPORTE PROVINCIAL";

            dgvDetalles.Columns["total"].Visible = true;
            dgvDetalles.Columns["total"].DefaultCellStyle.Format = "c2";
            dgvDetalles.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalles.Columns["total"].HeaderText = "IMPORTE TOTAL";

            dgvDetalles.Columns["fecha_desde"].HeaderText = "DESDE";
            dgvDetalles.Columns["fecha_desde"].Visible = true;
            dgvDetalles.Columns["fecha_desde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvDetalles.Columns["fecha_hasta"].HeaderText = "HASTA";
            dgvDetalles.Columns["fecha_hasta"].Visible = true;
            dgvDetalles.Columns["fecha_hasta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvDetalles.Columns["detalles"].HeaderText = "DETALLE";
            dgvDetalles.Columns["detalles"].Visible = true;
            dgvDetalles.Columns["detalles"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvDetalles.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            dgvRelacion.DataSource = dtctacterelacion;

            for (int i = 0; i < dtctacterelacion.Columns.Count; i++)
                dgvRelacion.Columns[i].Visible = false;

            dgvRelacion.Columns["recibo"].Visible = true;
            dgvRelacion.Columns["recibo"].Width = 100;
            dgvRelacion.Columns["recibo"].HeaderText = "COMPROBANTE";

            dgvRelacion.Columns["fecha"].Visible = true;
            dgvRelacion.Columns["fecha"].Width = 100;
            dgvRelacion.Columns["fecha"].HeaderText = "FECHA";
            dgvRelacion.Columns["fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvRelacion.Columns["Importe"].Visible = true;
            dgvRelacion.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvRelacion.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRelacion.Columns["importe"].Width = 100;
            dgvRelacion.Columns["Importe"].HeaderText = "IMPORTE";

        }

        private void Recibos()
        {
            lbtexto2.Text = "COMPROBANTES CANCELADOS";
            lbtexto2.Location = new System.Drawing.Point(this.Size.Width - lbtexto2.Width, lbtexto2.Location.Y);

            foreach (DataRow item in dtdetallerecibos.Rows)
                total = total + Convert.ToDecimal(item["Importe"]);

            lblTotalDato.Text = total.ToString("c");

            dgvDetalles.DataSource = dtdetallerecibos;

            for (int i = 0; i < dtdetallerecibos.Columns.Count; i++)
                dgvDetalles.Columns[i].Visible = false;

            dgvDetalles.Columns["descripcion"].Visible = true;
            dgvDetalles.Columns["descripcion"].Width = 150;
            dgvDetalles.Columns["descripcion"].HeaderText = "TIPO DE PAGO";

            dgvDetalles.Columns["Importe"].Visible = true;
            dgvDetalles.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvDetalles.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe"].Width = 100;
            dgvDetalles.Columns["Importe"].HeaderText = "IMPORTE";

            dgvDetalles.Columns["numero"].Visible = true;
            dgvDetalles.Columns["numero"].Width = 100;
            dgvDetalles.Columns["numero"].HeaderText = "NUMERO";
            dgvDetalles.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvRelacion.DataSource = dtctacterelacion;

            for (int i = 0; i < dtctacterelacion.Columns.Count; i++)
                dgvRelacion.Columns[i].Visible = false;

            dgvRelacion.Columns["descripcion"].Visible = true;
            dgvRelacion.Columns["descripcion"].Width = 100;
            dgvRelacion.Columns["descripcion"].HeaderText = "COMPROBANTE";

            dgvRelacion.Columns["servicio"].Visible = true;
            dgvRelacion.Columns["servicio"].Width = 100;
            dgvRelacion.Columns["servicio"].HeaderText = "SERVICIO";

            dgvRelacion.Columns["Importe_imputa"].Visible = true;
            dgvRelacion.Columns["Importe_imputa"].DefaultCellStyle.Format = "c2";
            dgvRelacion.Columns["Importe_imputa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRelacion.Columns["importe_imputa"].Width = 100;
            dgvRelacion.Columns["Importe_imputa"].HeaderText = "IMPORTE";
        }
        #endregion

        public FrmUsuariosCtaCteDetalles()
        {
            InitializeComponent();

            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.Rows.Count > 0)
            {
                int idDet = Convert.ToInt32(dgvDetalles.SelectedRows[0].Cells["id"].Value);
                oFrmExtras = new frmUsuariosCtacteDetExtras(false);
                oFrmExtras.idUsuarioCtaCteDetExtra = idDet;
                oPop = new frmPopUp();
                oPop.Formulario = oFrmExtras;
                oPop.Maximizar = true;
                oPop.ShowDialog();

            }
        }

        private void ImgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUsuariosCtaCteDetalles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FrmUsuariosCtaCteDetalles_Load(object sender, EventArgs e)
        {
            Comenzarcagra();
        }
    }
}
