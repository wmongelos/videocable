using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Tecnologias : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtTipos, dtTecnologias_Tipos;
        Equipos_Tipos oEquiTipo = new Equipos_Tipos();
        Tecnologias_Tipos oTecnoTipo = new Tecnologias_Tipos();
        Servicios oServi = new Servicios();
        Tecnologias_Tipos.TIPO TipoTecnologiaSeleccionado;
        string tipo = string.Empty;
        #endregion

        #region METODOS
        public ABMEquipos_Tecnologias()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            dgvTipoEquipos.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                if (chkEquipo.Checked == true)
                {
                    dtTipos = oEquiTipo.Listar();
                    TipoTecnologiaSeleccionado = Tecnologias_Tipos.TIPO.TIPO_EQUIPO;
                }
                else
                {
                    dtTipos = oServi.Listar();
                    TipoTecnologiaSeleccionado = Tecnologias_Tipos.TIPO.SERVICIO;
                }

                dtTecnologias_Tipos = oTecnoTipo.ListarRelacionEquipoTecnologia();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { }); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgvTipoEquipos.Columns.Clear();

            dgvTipoEquipos.DataSource = dtTipos;
            for (int i = 0; i < dgvTipoEquipos.ColumnCount; i++)
                dgvTipoEquipos.Columns[i].Visible = false;

            dgvTipoEquipos.Columns[TipoTecnologiaSeleccionado == Tecnologias_Tipos.TIPO.SERVICIO ? "Descripcion" : "Nombre"].Visible = true;
            dgvTipoEquipos.Columns[TipoTecnologiaSeleccionado == Tecnologias_Tipos.TIPO.SERVICIO ? "Descripcion" : "Nombre"].HeaderText = "Descripcion";


            cboTecnologias.DataSource = oTecnoTipo.Listar();
            cboTecnologias.ValueMember = "idRelacion";
            cboTecnologias.DisplayMember = "Tecnologia";
            setearDgvTecnologias();
        }

        private void agregarRegistro()
        {
            int id_tipo = Convert.ToInt32(dgvTipoEquipos.SelectedRows[0].Cells["id"].Value);
            int id_tecno = Convert.ToInt32(cboTecnologias.SelectedValue);
            if (TipoTecnologiaSeleccionado == Tecnologias_Tipos.TIPO.SERVICIO)
                tipo = "S";
            else
                tipo = "E";
            oTecnoTipo.GuardarRelacionEquipoTecnologia(id_tipo, id_tecno, tipo);
        }

        private void setearDgvTecnologias()
        {
            try
            {
                int Id = Convert.ToInt32(dgvTipoEquipos.CurrentRow.Cells["Id"].Value);
                if (TipoTecnologiaSeleccionado == Tecnologias_Tipos.TIPO.TIPO_EQUIPO)
                {
                    txtTipoEquipo.Text = dgvTipoEquipos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtTipoEquipo.Tag = dgvTipoEquipos.CurrentRow.Cells["Nombre"].Value.ToString();
                }
                else
                {
                    txtTipoEquipo.Text = dgvTipoEquipos.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtTipoEquipo.Tag = dgvTipoEquipos.CurrentRow.Cells["Descripcion"].Value.ToString();
                }


                if (dtTecnologias_Tipos.Rows.Count > 0)
                {
                    if (TipoTecnologiaSeleccionado == Tecnologias_Tipos.TIPO.SERVICIO)
                    {
                        dtTecnologias_Tipos.DefaultView.RowFilter = String.Format("Id_Tipo = {0} and Tipo = '{1}'", dgvTipoEquipos.CurrentRow.Cells["Id"].Value.ToString(), 'S');
                    }
                    else
                    {
                        dtTecnologias_Tipos.DefaultView.RowFilter = String.Format("Id_Tipo = {0} and Tipo = '{1}'", dgvTipoEquipos.CurrentRow.Cells["Id"].Value.ToString(), 'E');
                    }
                }

                dgvTipoTecnologia.DataSource = dtTecnologias_Tipos;
                for (int i = 0; i < dgvTipoTecnologia.ColumnCount; i++)
                    dgvTipoTecnologia.Columns[i].Visible = false;

               dgvTipoTecnologia.Columns["Tecnologia"].Visible = true;
               dgvTipoTecnologia.Columns["Tecnologia"].HeaderText = "Tecnologia";
               dgvTipoTecnologia.Columns["Acceso"].Visible = true;
               dgvTipoTecnologia.Columns["Acceso"].HeaderText = "Acceso";
            }
            catch
            { }
        }
        #endregion

        #region EVENTOS
        private void ABMEquiposTecnologias_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvTipoEquipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setearDgvTecnologias();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idTipoAcceso = Convert.ToInt32(dgvTipoTecnologia.SelectedRows[0].Cells["Id_TipoAcceso"].Value);
            int idTipo = Convert.ToInt32(dgvTipoEquipos.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oTecnoTipo.EliminarRelacionTecnoEquipo(idTipoAcceso, idTipo);
                comenzarCarga();
            }
        }

        private void chkServicio_CheckedChanged(object sender, EventArgs e)
        {
            cargarDatos();
            dgvTipoEquipos.Focus();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarRegistro();
            comenzarCarga();
        }
        #endregion
    }
}
