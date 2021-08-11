using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion.Herramientas
{
    public partial class frmIspEdicionEquipo : Form
    {
        #region propiedades
        private DataTable dtMarcas = Tablas.DataEquiposMarcas.Copy();
        private DataTable dtModelos = Tablas.DataEquiposModelos.Copy();
        public string Mac,Ip,Serial;
        public int idEquipment;
        public string marca, modelo;
        private bool requiereMac, requiereSerie, requiereIp;
        private int idMarcaSeleccionada, idModeloSeleccionado;
        public bool HuboCambios = false;
        public Isp oIsp;
        private void cboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

        }

        private void cboModelo_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {

        }

        private void txtMarca_Enter(object sender, EventArgs e)
        {
            txtMarca.SelectionStart = 0;
            txtMarca.SelectionLength = txtMarca.Text.Length;
        }

        private void txtModelo_Enter(object sender, EventArgs e)
        {
            txtModelo.SelectionStart = 0;
            txtModelo.SelectionLength = txtModelo.Text.Length;
        }

        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txtModelo.Focus();
        }

        private void cboModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        #endregion
        #region metodos
        private bool ValidarMac()
        {
            bool bStatus = true;
            if (txtMac.Text == "")
            {
                errorProvider1.SetError(txtMac, "Ingrese Mac");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtMac, "");
            return bStatus;
        }

        private bool existe(DataTable dt, string nombre,out int id)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"nombre = '{nombre.ToUpper()}'";
            if (dv.Count > 0)
            {
                DataTable dtAux = dv.ToTable();
                id = Convert.ToInt32(dtAux.Rows[0]["id"]);
                return true;
            }
            else
            {
                id = -1;
                return false;
            }
        }
        #endregion

        public frmIspEdicionEquipo()
        {
            InitializeComponent();
        }

        private void frmIspEdicionEquipo_Load(object sender, EventArgs e)
        {
            string[] postFuenteMarcas = dtMarcas
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("nombre"))
                    .ToArray();
            AutoCompleteStringCollection fuenteMarcas = new AutoCompleteStringCollection();
            fuenteMarcas.AddRange(postFuenteMarcas);
            txtMarca.AutoCompleteCustomSource = fuenteMarcas;
            txtMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMarca.Text = this.marca.ToUpper();

            string[] postFuenteModelos = dtModelos
                   .AsEnumerable()
                   .Select<System.Data.DataRow, String>(x => x.Field<String>("nombre"))
                   .ToArray();
            AutoCompleteStringCollection fuenteModelos = new AutoCompleteStringCollection();
            fuenteModelos.AddRange(postFuenteModelos);
            txtModelo.AutoCompleteCustomSource = fuenteModelos;
            txtModelo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtModelo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtModelo.Text = this.modelo.ToUpper();




            if (!existe(dtMarcas, this.marca,out idMarcaSeleccionada))
            {
                if(MessageBox.Show("Esta marca de equipo no esta cargada en GIES, ¿Desea cargarla?","Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Abms.ABMEquipos_Marcas oFrmMarcas = new Abms.ABMEquipos_Marcas();
                    oFrmMarcas.NombreMarca = this.txtMarca.Text.ToString().ToUpper();
                    oFrmMarcas.AgregaExistente = true;
                    frmPopUp oFrmPop = new frmPopUp();
                    oFrmPop.Formulario = oFrmMarcas;
                    if (oFrmPop.ShowDialog() == DialogResult.OK)
                    {
                        dtMarcas = Tablas.DataEquiposMarcas.Copy();
                        if (!existe(dtModelos, this.modelo, out idModeloSeleccionado))
                        {
                            if (MessageBox.Show("Este modelo de equipo no esta cargado en GIES, ¿Desea cargarlo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Abms.ABMEquipos_Modelos oFrmModelos = new Abms.ABMEquipos_Modelos();
                                oFrmModelos.NombreModelo = this.txtModelo.Text.ToString().ToUpper();
                                oFrmModelos.AgregaExistente = true;
                                oFrmModelos.idMarca = idMarcaSeleccionada;

                                frmPopUp oFrmPop2 = new frmPopUp();
                                oFrmPop2.Formulario = oFrmModelos;
                                oFrmPop2.ShowDialog();
                                dtModelos = Tablas.DataEquiposModelos.Copy();
                            }
                        }

                    }
                }
            
            
            }



           
            txtIp.Text = Ip;
            txtMac.Text = Mac;
            txtSerial.Text = Serial;



        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (!existe(dtMarcas, txtMarca.Text, out idMarcaSeleccionada)){
                if (MessageBox.Show("Esta marca de equipo no esta cargada en GIES, ¿Desea cargarla?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Abms.ABMEquipos_Marcas oFrmMarcas = new Abms.ABMEquipos_Marcas();
                    oFrmMarcas.NombreMarca = this.txtMarca.Text.ToString().ToUpper();
                    oFrmMarcas.AgregaExistente = true;
                    frmPopUp oFrmPop = new frmPopUp();
                    oFrmPop.Formulario = oFrmMarcas;
                    oFrmPop.ShowDialog();
                    dtMarcas = Tablas.DataEquiposMarcas.Copy();
                    existe(dtMarcas, txtMarca.Text, out idMarcaSeleccionada);
                }
            }

            if (!existe(dtModelos, this.modelo, out idModeloSeleccionado))
            {
                if (MessageBox.Show("Este modelo de equipo no esta cargado en GIES, ¿Desea cargarlo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Abms.ABMEquipos_Modelos oFrmModelos = new Abms.ABMEquipos_Modelos();
                    oFrmModelos.NombreModelo = this.txtModelo.Text.ToString().ToUpper();
                    oFrmModelos.idMarca = idMarcaSeleccionada;
                    oFrmModelos.AgregaExistente = true;
                    frmPopUp oFrmPop2 = new frmPopUp();
                    oFrmPop2.Formulario = oFrmModelos;
                    oFrmPop2.ShowDialog();
                    dtModelos = Tablas.DataEquiposModelos.Copy();
                    existe(dtModelos, txtModelo.Text, out idModeloSeleccionado);

                }
            }



            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            Mac = txtMac.Text;
            Ip = txtIp.Text;
            Serial = txtSerial.Text;

            if (oIsp.ActualizarDatosEquipment(idEquipment, Mac, Ip, marca, modelo,Serial) == 0)
            {
                MessageBox.Show("Datos del equipo modeificados correctamente","Mensaje del equipo en la plataforma ISP",MessageBoxButtons.OK,MessageBoxIcon.Information);
                HuboCambios = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if(MessageBox.Show("Hubo un error al intentar modificar los datos del equipo","Mensaje del Sistema", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    if (oIsp.ActualizarDatosEquipment(idEquipment, Mac, Ip, marca, modelo,Serial) == 0)
                    {
                        MessageBox.Show("Datos del equipo modeificados correctamente", "Mensaje del equipo en la plataforma ISP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HuboCambios = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (MessageBox.Show("Hubo un error al intentar modificar los datos del equipo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)==DialogResult.OK)
                        {
                            HuboCambios = false;
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                }
                else
                {
                    HuboCambios = false;
                    this.DialogResult = DialogResult.Cancel;
                }
            }


        }
    }
}
