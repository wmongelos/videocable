using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaPartes : Form
    {
        /// <summary>
        /// Función del formulario: Permite la búsqueda de partes de acuerdo con el o los estados de parte que reciba, y retorna el Id del parte seleccionado
        /// </summary>

        #region [PROPIEDADES]
        private Partes oPartes = new Partes();
        private Personal oPersonal = new Personal();
        private Partes_Estados oPartes_Estados = new Partes_Estados();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtPartes;
        private DataTable dtEstados;
        public int id_parte_seleccionado = 0;
        public List<int> lista_partes_equipos = new List<int>();
        public Partes.Partes_Estados Estado;
        public List<Int32> lista_estados_busqueda = new List<Int32>();
        int id_estado_seleccionado;

        #endregion

        #region [MÉTODOS]
        private void comenzarCarga()
        {
            id_parte_seleccionado = 0;

            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                int id_estado = 0;

                dtEstados = oPartes_Estados.Listar();

                if (lista_estados_busqueda.Count > 0)
                    id_estado = id_estado_seleccionado;
                else
                    id_estado = Convert.ToInt32(dtEstados.Rows[0]["id"]);

                if (id_estado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.ASIGNADO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.EN_TRATAMIENTO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.EN_TRATAMIENTO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.REALIZADO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.DERIVADO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.DERIVADO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.ANULADO))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.ANULADO);
                else if (id_estado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA);
                else
                    dtPartes = oPartes.Listar(Partes.Partes_Estados.TODOS);





                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {

            if (lista_estados_busqueda.Count > 0)
            {
                string row_filter_estados = "";
                for (int x = 0; x < lista_estados_busqueda.Count; x++)
                {
                    if (x != (lista_estados_busqueda.Count - 1))
                        row_filter_estados += "id=" + lista_estados_busqueda[x] + " OR ";
                    else
                        row_filter_estados += "id=" + lista_estados_busqueda[x];
                }

                dtEstados.DefaultView.RowFilter = row_filter_estados;

            }

            cbEstado.DataSource = dtEstados;
            cbEstado.DisplayMember = "nombre";
            cbEstado.ValueMember = "id";

            if (lista_estados_busqueda.Count > 0)
                cbEstado.SelectedValue = id_estado_seleccionado;



            if (dtPartes.Rows.Count > 0)
            {

                dgv.DataSource = dtPartes;

                for (int i = 0; i < dgv.Columns.Count; i++)
                    dgv.Columns[i].Visible = false;

                dgv.Columns["id"].Visible = true;
                dgv.Columns["fecha"].Visible = true;
                dgv.Columns["usuario"].Visible = true;
                dgv.Columns["servicio"].Visible = true;
                dgv.Columns["direccion"].Visible = true;
                dgv.Columns["localidad"].Visible = true;
                dgv.Columns["falla"].Visible = true;
                dgv.Columns["piso"].Visible = false;
                dgv.Columns["depto"].Visible = false;
                dgv.Columns["manzana"].Visible = false;
                dgv.Columns["tecnico"].Visible = true;
                dgv.Columns["detalle_solucion"].Visible = false;
                dgv.Columns["estado"].Visible = false;
                dgv.Columns["id"].HeaderText = "N°";
                dgv.Columns["falla"].HeaderText = "Solicitud";
                dgv.Columns["id"].Width = 40;
                dgv.Columns["fecha"].Width = 100;


            }


            lblTotal.Text = String.Format("Total de Registros: {0}", dtPartes.Rows.Count);
        }

        public void AsignarListaEstados(List<Int32> lista_recibida)
        {
            lista_estados_busqueda = lista_recibida;

        }

        private void FiltroGeneral()
        {
            if (Convert.ToInt32(cbEstado.SelectedValue) != id_estado_seleccionado)
            {
                id_estado_seleccionado = Convert.ToInt32(cbEstado.SelectedValue);
                comenzarCarga();

            }

            try
            {
                dtPartes.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "' or servicio Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or falla Like '%" + txtBuscar.Text + "%' or direccion Like '%" + txtBuscar.Text + "%'  or localidad Like '%" + txtBuscar.Text + "%' or detalle_solucion Like '%" + txtBuscar.Text + "%' ");
            }
            catch
            {
                dtPartes.DefaultView.RowFilter = String.Format("servicio Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or falla Like '%" + txtBuscar.Text + "%' or direccion Like '%" + txtBuscar.Text + "%'  or localidad Like '%" + txtBuscar.Text + "%' or detalle_solucion Like '%" + txtBuscar.Text + "%' ");
            }
        }

        private void AsignarValores(int rowindex)
        {
            lblParteSeleccionado.Text = String.Format("Parte seleccionado: {0}", dgv.Rows[rowindex].Cells["id"].Value.ToString());
            lblServicio.Text = String.Format("Servicio: {0}", dgv.Rows[rowindex].Cells["servicio"].Value.ToString());
            lblLocacion.Text = String.Format("Locación: {0}, Piso: {1}, Depto: {2}, {3}", dgv.Rows[rowindex].Cells["direccion"].Value.ToString(), dgv.Rows[rowindex].Cells["piso"].Value.ToString(), dgv.Rows[rowindex].Cells["depto"].Value.ToString(), dgv.Rows[rowindex].Cells["localidad"].Value.ToString());
        }

        #endregion

        public frmBusquedaPartes()
        {
            InitializeComponent();
        }

        private void frmBuscaParte_Load(object sender, EventArgs e)
        {
            if (lista_estados_busqueda.Count > 0)
                id_estado_seleccionado = lista_estados_busqueda[0];
            comenzarCarga();
        }

        private void frmBusquedaPartes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnAsignar_Click_1(object sender, EventArgs e)
        {
            if (id_parte_seleccionado != 0)
            {
                id_parte_seleccionado = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No se ha seleccionado parte.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltroGeneral();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
                dtPartes.DefaultView.RowFilter = "id>0";
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {

                int rowindex = 0;
                try
                {
                    id_parte_seleccionado = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                    rowindex = dgv.SelectedRows[0].Index;
                }
                catch
                {
                    id_parte_seleccionado = Convert.ToInt32(dgv.Rows[0].Cells["id"].Value);
                    rowindex = dgv.Rows[0].Index;
                }

                AsignarValores(rowindex);
            }
        }

        private void ImgSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
