using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Debitos_Automaticos
{
    public partial class frmDebitosBusqueda : Form
    {
        public int idDebitoSeleccionado, mes, ano;
        private DataTable dtDebitos = new DataTable();
        private DateTime fechaUltimaPresentacion;
        private DataTable dtMeses = new DataTable();
        private DataTable dtYears = new DataTable();
        public frmDebitosBusqueda(DataTable dtDebitos)
        {
            this.dtDebitos = dtDebitos;
            InitializeComponent();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(cboYears.SelectedValue) == fechaUltimaPresentacion.Year && Convert.ToInt32(cboMeses.SelectedValue) <= fechaUltimaPresentacion.Month)
                || Convert.ToInt32(cboYears.SelectedValue) < fechaUltimaPresentacion.Year)
            {
                MessageBox.Show("La fecha ingresada tiene que ser mayor a la de la ultima presentacion de debitos", "Mensaje del sistema");
                return;
            }

            if (dgvDebitos.SelectedRows.Count > 0)
            {
                idDebitoSeleccionado = Convert.ToInt32(dgvDebitos.SelectedRows[0].Cells["id"].Value);
                mes = Convert.ToInt32(cboMeses.Text);
                ano = Convert.ToInt32(cboYears.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No ha seleccionado un débito.");
        }

        private void frmDebitosBusqueda_Load(object sender, EventArgs e)
        {
            dtMeses.Columns.Add("mes", typeof(string));
            dtMeses.Columns.Add("mes_id", typeof(int));
            dtYears.Columns.Add("year", typeof(string));
            dtYears.Columns.Add("year_id", typeof(int));
            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                    dtMeses.Rows.Add("0" + i.ToString(), i);
                else
                    dtMeses.Rows.Add(i.ToString(), i);

            }
            int cantYaears = 2;
            int actualYear = DateTime.Now.Year;

            for (int i = actualYear; i < actualYear + cantYaears; i++)
                dtYears.Rows.Add(i.ToString(), i);//el string es para lo que se ve y el int es para el valor que puede leer de la base en caso que el plastico ya exista

            cboMeses.DataSource = dtMeses;
            cboMeses.DisplayMember = "mes";
            cboMeses.ValueMember = "mes_id";
            cboYears.DataSource = dtYears;
            cboYears.DisplayMember = "year";
            cboYears.ValueMember = "year_id";
            Presentacion_Debitos oPresentacion = new Presentacion_Debitos();
            DataTable dtUltimaPresentacion = oPresentacion.ListarUltimaPresentacion();
            if(dtUltimaPresentacion.Rows.Count>0)
            {
                fechaUltimaPresentacion = Convert.ToDateTime(dtUltimaPresentacion.Rows[0]["fecha_presentacion"]);
                cboYears.SelectedValue = fechaUltimaPresentacion.Date.Year;
                cboMeses.SelectedValue = fechaUltimaPresentacion.Date.Month;

            }
          

            dgvDebitos.DataSource = dtDebitos;
            dgvDebitos.Columns["id"].Visible = false;
            dgvDebitos.Columns["numero"].HeaderText = "Número";
            dgvDebitos.Columns["titular"].HeaderText = "Titular";
            dgvDebitos.Columns["vencimiento"].HeaderText = "Vencimiento";
        }

        private void frmDebitosBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
