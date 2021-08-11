using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmInformePlasticosUsuariosServicios : Form
    {
        DataTable dtPlasticos = new DataTable();

        public frmInformePlasticosUsuariosServicios()
        {
            InitializeComponent();
        }

        private void TraerDatos()
        {
            dtPlasticos = new Plasticos_Usuarios().Listar(0,0);

            string[] colnames = new string[] 
            {
                "numero",
                "vencimiento",
                "forma_de_pago",
                "titular",
                "activo",
                "activo1",
                "fecha_inicio",
                "fecha_baja",
                "fecha_solicitud",
                "servicio",
                "tiposervicio",
                "fecha_fin",
                "estado",
                "codigo",
                "usuario",
                "calle",
                "altura",
                "localidad",
                "piso",
                "depto",
                "locacion"
            };

            dtPlasticos = dtPlasticos.DefaultView.ToTable(false, colnames);
            
            foreach (DataRow row in dtPlasticos.Rows)
            {
                if (Convert.ToDateTime(row["vencimiento"]) <= new DateTime(0001, 01, 01))
                    row["vencimiento"] = new DateTime(1900, 01, 01);

                if (Convert.ToDateTime(row["fecha_inicio"]) <= new DateTime(0001, 01, 01))
                    row["fecha_inicio"] = new DateTime(1900, 01, 01);

                if (Convert.ToDateTime(row["fecha_baja"]) <= new DateTime(0001, 01, 01))
                    row["fecha_baja"] = new DateTime(1900, 01, 01);

                if (Convert.ToDateTime(row["fecha_solicitud"]) <= new DateTime(0001, 01, 01))
                    row["fecha_solicitud"] = new DateTime(1900, 01, 01);

                if (Convert.ToDateTime(row["fecha_fin"]) <= new DateTime(0001, 01, 01))
                    row["fecha_fin"] = new DateTime(1900, 01, 01);

                row["vencimiento"] = Convert.ToDateTime(row["vencimiento"]).Date;
                row["fecha_inicio"] = Convert.ToDateTime(row["fecha_inicio"]).Date;
                row["fecha_baja"] = Convert.ToDateTime(row["fecha_baja"]).Date;
                row["fecha_solicitud"] = Convert.ToDateTime(row["fecha_solicitud"]).Date;
                row["fecha_fin"] = Convert.ToDateTime(row["fecha_fin"]).Date;
            }

            dgv.DataSource = dtPlasticos;

            formatearDataGridView();
        }

        private void formatearDataGridView()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["titular"].Visible = true;
            dgv.Columns["titular"].HeaderText = "Titular";
            dgv.Columns["numero"].Visible = true;
            dgv.Columns["numero"].HeaderText = "Numero";
            dgv.Columns["vencimiento"].Visible = true;
            dgv.Columns["vencimiento"].HeaderText = "Vencimiento";
            dgv.Columns["forma_de_pago"].Visible = true;
            dgv.Columns["forma_de_pago"].HeaderText = "Forma de pago";
            dgv.Columns["fecha_inicio"].Visible = true;
            dgv.Columns["fecha_inicio"].HeaderText = "Fecha inicio";
            dgv.Columns["fecha_baja"].Visible = true;
            dgv.Columns["fecha_baja"].HeaderText = "Fecha baja";
            dgv.Columns["fecha_solicitud"].Visible = true;
            dgv.Columns["fecha_solicitud"].HeaderText = "Fecha solicitud";
            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["servicio"].HeaderText = "Servicio";
            dgv.Columns["tiposervicio"].Visible = true;
            dgv.Columns["tiposervicio"].HeaderText = "Tipo de servicio";
            dgv.Columns["fecha_fin"].Visible = true;
            dgv.Columns["fecha_fin"].HeaderText = "Fecha fin";
            dgv.Columns["estado"].Visible = true;
            dgv.Columns["estado"].HeaderText = "Estado";
            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["codigo"].HeaderText = "Codigo";
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["locacion"].Visible = true;
            dgv.Columns["locacion"].HeaderText = "Locacion";
            dgv.Columns["activo"].Visible = true;
            dgv.Columns["activo"].HeaderText = "Plastico activo";
            dgv.Columns["activo1"].Visible = true;
            dgv.Columns["activo1"].HeaderText = "Plastico usuario activo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TraerDatos();
            this.Cursor = Cursors.Default;

            lblTotal.Text = String.Format("Total de Registros: {0}", dtPlasticos.Rows.Count);
        } 

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (dtPlasticos.Rows.Count > 0)
            {
                dtPlasticos.DefaultView.RowFilter = String.Format("numero like '%{0}%' or titular like '%{0}%' " +
                   "or servicio like '%{0}%' or tiposervicio like '%{0}%' or usuario like '%{0}%'" +
                   "or localidad like '%{0}%' or forma_de_pago like '%{0}%' or estado like '%{0}%'", txtBuscador.Text);

                lblTotal.Text = String.Format("Total de Registros: {0}", dtPlasticos.DefaultView.Count);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    tools.ExportDataTableToExcel(dtPlasticos.DefaultView.ToTable(), "informe", this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error el exportar a excel: {ex.Message}");
                }
                MessageBox.Show("Informe exportado correctamente", "Mensaje del sistema");
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInformePlasticosUsuariosServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
