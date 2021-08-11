using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using CapaPresentacion.Abms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios_Contratos : Form
    {
        #region PROPIEDADES
        private Configuracion oConf = new Configuracion();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtServicios = Tablas.DataServicios.Copy();
        private DataTable dtTipoFacturacion = new DataTable();
        private DataTable dtRelaciones = new DataTable();
        private Contrato oContrato = new Contrato();
        private int idServicio;
        private int idTipoFac;
        public bool cargado = false;
        #endregion

        #region METODOS
        private void comenzarCarga()
        {
            cargado = false;
            if (oConf.GetValor_N("id_tipo_facturacion") == 1)//zona
                dtTipoFacturacion = Tablas.DataZonas;
            else
                dtTipoFacturacion = Tablas.DataServiciosCategorias;

            cboTipoFacturacion.DataSource = dtTipoFacturacion;
            cboTipoFacturacion.DisplayMember = "Nombre";
            cboTipoFacturacion.ValueMember = "id";

            cboServicios.DataSource = dtServicios;
            cboServicios.DisplayMember = "descripcion";
            cboServicios.ValueMember = "id";

            idServicio = Convert.ToInt32(cboServicios.SelectedValue);
            idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);

            dtRelaciones = oContrato.ListarPorRelacion(idServicio, idTipoFac);

            pgCircular.Start();
            dgvRelacion.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                idServicio =1;
                idTipoFac =1;

                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            dgvRelacion.DataSource = dtRelaciones;
            cargado = true;
            FormatearGrilla();
        }

        #endregion



        public ABMServicios_Contratos()
        {
            InitializeComponent();
        }

        private void ABMServicios_Contratos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn item in dgvRelacion.Columns)
                item.Visible = false;

            dgvRelacion.Columns["nombre_contrato"].Visible = true;
            dgvRelacion.Columns["nombre_contrato"].HeaderText = "Contrato";
            if(oConf.GetValor_N("id_tipo_facturacion")==1)
                dgvRelacion.Columns["zona"].Visible = true;
            else
                dgvRelacion.Columns["categoria"].Visible = true;
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            ABMContratos ofrmAbm = new ABMContratos();
            ofrmAbm.ShowDialog();
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            ABMContratos ofrmAbm = new ABMContratos();
            ofrmAbm.Seleccionar = true;
            if (ofrmAbm.ShowDialog() == DialogResult.OK)
            {
                idServicio = Convert.ToInt32(cboServicios.SelectedValue);
                idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                int idContrato = ofrmAbm.IdContrato;

               if(oContrato.GuardarRelacion(idContrato, idServicio, idTipoFac))
               {
                    MessageBox.Show("Contrato relacionado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comenzarCarga();
               }
               else
                    MessageBox.Show("Hubo un error al intentar guardar la relacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cboTipoFacturacion_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cargado)
            {
                Tipo_Facturacion oTipo = new Tipo_Facturacion();
                idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                DataTable dtServiciosPorFacturacion = oTipo.Listar(idTipoFac,true);
  
                DataView dvServicios = dtServiciosPorFacturacion.Copy().DefaultView;
                dvServicios.RowFilter = $"id_tipo_facturacion = {idTipoFac}";
                DataTable dtcopia = dvServicios.ToTable();
                cboServicios.DataSource = dtcopia;
                cboServicios.DisplayMember = "servicio";
                cboServicios.ValueMember = "id_servicios";
                dtRelaciones = oContrato.ListarPorRelacion(Convert.ToInt32(cboServicios.SelectedValue), idTipoFac);
                dgvRelacion.DataSource = dtRelaciones;
                FormatearGrilla();

            }
        }

        private void cboServicios_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                dtRelaciones = oContrato.ListarPorRelacion(Convert.ToInt32(cboServicios.SelectedValue), Convert.ToInt32(cboTipoFacturacion.SelectedValue));
                dgvRelacion.DataSource = dtRelaciones;
                FormatearGrilla();
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            ABMContratos ofrmAbm = new ABMContratos();
            ofrmAbm.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ABMContratos ofrmAbm = new ABMContratos();
            ofrmAbm.Seleccionar = true;
            if (ofrmAbm.ShowDialog() == DialogResult.OK)
            {
                idServicio = Convert.ToInt32(cboServicios.SelectedValue);
                idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                int idContrato = ofrmAbm.IdContrato;

                if (oContrato.GuardarRelacion(idContrato, idServicio, idTipoFac))
                {
                    MessageBox.Show("Contrato relacionado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comenzarCarga();
                }
                else
                    MessageBox.Show("Hubo un error al intentar guardar la relacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ABMServicios_Contratos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F7)
                btnVer.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvRelacion.SelectedRows.Count>0)
            {
                int idRelacion = Convert.ToInt32(dgvRelacion.SelectedRows[0].Cells["id"].Value);
                if (oContrato.EliminarRelacion(idRelacion))
                    MessageBox.Show("Contrato eliminado correctamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un error al intentar eliminar el contrato.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
