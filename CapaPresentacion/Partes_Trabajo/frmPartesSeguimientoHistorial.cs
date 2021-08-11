using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartesSeguimientoHistorial : Form
    {
        public Partes oParte = new Partes();
        Personal_Areas oPersonalAreas = new Personal_Areas();
        DataTable dtHistorial = new DataTable();
        Partes_Historial oParteHistorial = new Partes_Historial();

        private void ComenzarCarga()
        {
            dtHistorial.Clear();

            dtHistorial = oParteHistorial.Listar(oParte.Id);

            if (dtHistorial.Rows.Count > 0)
            {
                dgv.DataSource = dtHistorial;


                dgv.Columns["id"].Visible = false;
                dgv.Columns["id_parte"].Visible = false;
                dgv.Columns["id_personal"].Visible = false;
                dgv.Columns["id_usuarios"].Visible = false;
                dgv.Columns["id_partes_estados"].Visible = false;
                dgv.Columns["id_area"].Visible = false;



                dgv.Columns["fecha_movimiento"].HeaderText = "Fecha";
                dgv.Columns["parte_estado"].HeaderText = "Estado";
                dgv.Columns["operador"].HeaderText = "Movimiento realizado por";
                dgv.Columns["area"].HeaderText = "Área del parte";
                dgv.Columns["detalles"].HeaderText = "Detalles";

            }
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);

        }

        public frmPartesSeguimientoHistorial()
        {
            InitializeComponent();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void frmHistorialParte_Load(object sender, EventArgs e)
        {
            lblParteSeleccionado.Text = String.Format("Parte seleccionado N°: {0}", oParte.Id);
            ComenzarCarga();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void frmHistorialParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
