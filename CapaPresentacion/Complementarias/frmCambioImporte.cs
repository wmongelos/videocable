using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmCambioImporte : Form
    {
        //ESTE FORMULARIO RECIBE UN ARRAY DE TIPOS DE OPERACIONES Y DEVUELVE UN ARRAY DEL MISMO TIPO PERO CON DATOS ACTUAIZADOS
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        //DATATABLES
        private DataTable dtInterna = new DataTable();
        //INT
        public int auxFlag = 0;
        //DECIMAL
        private decimal importeIndividual = 0;
        //DATAROW
        public DataRow[] filasSubServicios;
        public DataRow[] filasSubServiciosActualizos;
        #endregion

        public frmCambioImporte()
        {
            InitializeComponent();
        }
        private void frmCambio_Importe_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
        private void frmCambio_Importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }
        private void CargarDatos()
        {
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
        }
        private void AsignarDatos()
        {
            dtInterna.Columns.Add("Id", typeof(Int32));
            dtInterna.Columns.Add("subId", typeof(Int16));
            dtInterna.Columns.Add("Tipo", typeof(Int16));
            dtInterna.Columns.Add("SubTipo", typeof(Int16));
            dtInterna.Columns.Add("Id_Sub", typeof(Int16));
            dtInterna.Columns.Add("Nombre_Sub", typeof(String));
            dtInterna.Columns.Add("Tarifa", typeof(decimal));
            dtInterna.Columns.Add("Id_Velocidad", typeof(Int16));
            dtInterna.Columns.Add("Id_Velocidad_Tipo", typeof(decimal));
            dtInterna.Columns.Add("NumBoca", typeof(Int16));
            dtInterna.Columns.Add("Id_Tipo_Sub", typeof(Int16));
            dtInterna.Columns.Add("Id_Ip", typeof(Int16));
            dtInterna.Columns.Add("TarifaProrrateada", typeof(decimal));
            dtInterna.Columns.Add("Desde", typeof(DateTime));
            dtInterna.Columns.Add("Hasta", typeof(DateTime));

            for (int i = 0; i < filasSubServicios.Length; i++)
            {
                DataRow drNueva = dtInterna.NewRow();
                drNueva["Id"] = filasSubServicios[i]["Id"];
                drNueva["subId"] = filasSubServicios[i]["subId"];
                drNueva["Tipo"] = filasSubServicios[i]["Tipo"];
                drNueva["SubTipo"] = filasSubServicios[i]["SubTipo"];
                drNueva["Nombre_Sub"] = filasSubServicios[i]["Nombre_Sub"];
                drNueva["Tarifa"] = filasSubServicios[i]["Tarifa"];
                drNueva["Id_Sub"] = filasSubServicios[i]["Id_Sub"];
                drNueva["Id_Velocidad"] = filasSubServicios[i]["Id_Velocidad"];
                drNueva["Id_Velocidad_Tipo"] = filasSubServicios[i]["Id_Velocidad_Tipo"];
                drNueva["NumBoca"] = filasSubServicios[i]["NumBoca"];
                drNueva["Id_Tipo_Sub"] = filasSubServicios[i]["Id_Tipo_Sub"];
                drNueva["Id_Ip"] = filasSubServicios[i]["Id_Ip"];
                drNueva["TarifaProrrateada"] = filasSubServicios[i]["TarifaProrrateada"];
                drNueva["Desde"] = filasSubServicios[i]["Desde"];
                drNueva["Hasta"] = filasSubServicios[i]["Hasta"];
                dtInterna.Rows.Add(drNueva);
            }
            dgvSubServicios.DataSource = dtInterna;

            foreach (DataGridViewColumn itemColumna in dgvSubServicios.Columns)
            {
                if ((itemColumna.Name == "Nombre_Sub") || (itemColumna.Name == "TarifaProrrateada") || (itemColumna.Name == "Desde") || (itemColumna.Name == "Hasta"))
                    itemColumna.Visible = true;
                else
                    itemColumna.Visible = false;
            }
            dgvSubServicios.Columns["Nombre_Sub"].HeaderText = "SubServicio";
            dgvSubServicios.Columns["TarifaProrrateada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            auxFlag = 1;
        }
        private void dgvSubServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (auxFlag == 1)
                txtImporte.Text = dgvSubServicios.SelectedRows[0].Cells["TarifaProrrateada"].Value.ToString();
        }
        private void dgvSubServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (auxFlag == 1)
                txtImporte.Text = dgvSubServicios.SelectedRows[0].Cells["TarifaProrrateada"].Value.ToString();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtImporte.Text.Length > 0)
            {
                importeIndividual = Convert.ToDecimal(txtImporte.Text);
                dgvSubServicios.SelectedRows[0].Cells["TarifaProrrateada"].Value = importeIndividual;
            }
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            dtInterna = dgvSubServicios.DataSource as DataTable;
            filasSubServiciosActualizos = dtInterna.Select("Tipo>0");
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
