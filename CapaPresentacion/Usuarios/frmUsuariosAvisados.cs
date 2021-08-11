using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmUsuariosAvisados : Form
    {
        #region PROPIEDADES
        private Usuarios_Avisos oUsuAvisos = new Usuarios_Avisos();
        private DataTable dtAvisos = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        private bool todoSeleccionado = false;

        #endregion
        #region metodos
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtAvisos = oUsuAvisos.Listar();
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dtAvisos.Columns.Add("colSeleccion", typeof(bool));
            dgvPartes.DataSource = dtAvisos;
            dgvPartes.ReadOnly = false;
            foreach (DataGridViewColumn item in dgvPartes.Columns)
                item.Visible = false;
            foreach (DataGridViewRow item in dgvPartes.Rows)
                item.Height = 30;
            dgvPartes.Columns["fecha"].Visible = true;
            dgvPartes.Columns["fecha"].HeaderText = "Fecha";
            dgvPartes.Columns["servicio"].Visible = true;
            dgvPartes.Columns["servicio"].HeaderText = "Servicio";
            dgvPartes.Columns["usuario"].Visible = true;
            dgvPartes.Columns["usuario"].HeaderText = "Usuario";
            dgvPartes.Columns["localidad"].Visible = true;
            dgvPartes.Columns["localidad"].HeaderText = "Localidad";
            dgvPartes.Columns["calle"].Visible = true;
            dgvPartes.Columns["calle"].HeaderText = "Calle";
            dgvPartes.Columns["altura"].Visible = true;
            dgvPartes.Columns["altura"].HeaderText = "Altura";
            dgvPartes.Columns["depto"].Visible = true;
            dgvPartes.Columns["depto"].HeaderText = "Depto";
            dgvPartes.Columns["piso"].Visible = true;
            dgvPartes.Columns["piso"].HeaderText = "Piso";
            dgvPartes.Columns["importe"].Visible = true;
            dgvPartes.Columns["importe"].HeaderText = "Importe";
            dgvPartes.Columns["correo_electronico"].Visible = true;
            dgvPartes.Columns["correo_electronico"].HeaderText = "Correo";
            dgvPartes.Columns["codigo"].Visible = true;
            dgvPartes.Columns["codigo"].HeaderText = "Codigo";
            dgvPartes.Columns["colSeleccion"].HeaderText = "Seleccionar";
            dgvPartes.Columns["colSeleccion"].Visible = true;
            dgvPartes.Columns["colSeleccion"].ReadOnly = false;

            lblTotal.Text = String.Format("Total de Registros: {0}", dtAvisos.Rows.Count);
        }
        #endregion
        public frmUsuariosAvisados()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosAvisados_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgvPartes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvPartes.Columns.Count - 1)
            {
                foreach (DataRow item in dtAvisos.Rows)
                {

                    if (todoSeleccionado)
                        item["colSeleccion"] = true;
                    else
                        item["colSeleccion"] = false;

                }
                todoSeleccionado = !todoSeleccionado;
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dtAvisosElegidos = new DataTable();
            DataView dvAvisos = dtAvisos.DefaultView;
            dvAvisos.RowFilter = "colSeleccion = true";
            dtAvisosElegidos = dvAvisos.ToTable();
            if(dtAvisosElegidos.Rows.Count>0)
            {
                Impresion oImprimir = new Impresion();
                oImprimir.ImprimirAviso2(dtAvisosElegidos);
            }
            dvAvisos.RowFilter = "";
        }

        private void frmUsuariosAvisados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataTable dtAvisosElegidos = new DataTable();
            DataView dvAvisos = dtAvisos.DefaultView;
            dvAvisos.RowFilter = "colSeleccion = true";
            dtAvisosElegidos = dvAvisos.ToTable();
            FolderBrowserDialog oSave = new FolderBrowserDialog();
            oSave.Description = "Seleccionar carpeta";
            string rutaElegida;
            Impresion oImprimir = new Impresion();
            if (dtAvisosElegidos.Rows.Count > 0)
            {
                if(oSave.ShowDialog() == DialogResult.OK)
                {
                    oImprimir.ImprimirAviso2(dtAvisosElegidos/*,true,oSave.SelectedPath*/);

                }
            }
            else
            {
                MessageBox.Show("No hay avisos seleccionado.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dvAvisos.RowFilter = "";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPartes.SelectedRows.Count > 0)
            {
                
                if(MessageBox.Show("¿Desea eliminar los avisos seleccionados?","Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataView dv = dtAvisos.DefaultView;
                    dv.RowFilter= "colSeleccion = true";
                    DataTable dtSeleccionados = dv.ToTable();
                    string salida = "";
                    int idAviso = 0;
                    foreach (DataRow item in dtSeleccionados.Rows)
                    {
                        idAviso = Convert.ToInt32(item["id"]);
                        oUsuAvisos.Eliminar(idAviso, out salida);
                    }
                    if (salida != "")
                        MessageBox.Show("Hubo errores al eliminar avisos: " + salida,"Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Avisos eliminados correctamente: ","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ComenzarCarga();
                }
            }
        }
    }
}
