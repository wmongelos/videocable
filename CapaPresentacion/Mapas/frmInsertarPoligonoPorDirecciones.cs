using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaNegocios.Mapas;
using CapaPresentacion.Busquedas;
using GMap.NET;

namespace CapaPresentacion.Mapas
{
    public partial class frmInsertarPoligonoPorDirecciones : Form
    {
        public List<PointLatLng> puntosDireccion = new List<PointLatLng>();
        private DataTable dtLocalidades = new DataTable();
        private Localidades oLocalidades = new Localidades();
        private Mapa oMapa = new Mapa();

        DataTable dtPuntos;
        public frmInsertarPoligonoPorDirecciones()
        {
            InitializeComponent();
        }

        private void frmInsertarPoligonoPorDirecciones_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            dtLocalidades = oLocalidades.Listar();
            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "nombre";
            cboLocalidades.ValueMember = "id";

            dtPuntos = new DataTable();
            dtPuntos.Columns.Add("id", typeof(int));
            dtPuntos.Columns.Add("localidad", typeof(string));
            dtPuntos.Columns.Add("calle", typeof(string));
            dtPuntos.Columns.Add("altura", typeof(string));
            dtPuntos.Columns.Add("lat", typeof(float));
            dtPuntos.Columns.Add("lng", typeof(float));
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("es-AR");
            this.Close();
        }

        private void btnCalle_Click(object sender, EventArgs e)
        {
            using (frmPopUp frmModal = new frmPopUp())
            {
                frmBusquedaCalles frm = new frmBusquedaCalles();
                frm.Id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                List<Int32> listLocalidades = new List<Int32>
                    {
                        Convert.ToInt32(cboLocalidades.SelectedValue)
                    };
                frm.lista_id_localidades = listLocalidades;

                frmModal.Formulario = frm;

                if (frmModal.ShowDialog() == DialogResult.OK)
                {

                    textCalle.Text = frm.Calle;
                    textCalle.Tag = frm.Id_Calle.ToString();
                    textCalle.Focus();

                    //lblAltura.Text = String.Format("Altura Desde {0} Hasta {1}", frm.oCalles.Altura_Desde, frm.oCalles.Altura_Hasta);

                    //this.Altura_Desde = frm.oCalles.Altura_Desde;
                    //this.Altura_Hasta = frm.oCalles.Altura_Hasta;

                    //oUsuLocSer.Id = 0;
                }
                else
                    textCalle.Text = "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textCalle.Text=="" || textAltura.Text=="")
            {
                MessageBox.Show("Complete los datos antes de agregar un nuevo punto", "Mensaje del Sistema");

            }
            else
            {
                string localidad = Convert.ToString(cboLocalidades.Text);
                string calle = textCalle.Text;
                string altura = textAltura.Text;

                puntosDireccion.Add(oMapa.ObtenerCoordenadas(localidad, calle, altura));

                dtPuntos.Rows.Add(puntosDireccion.Count - 1, localidad, calle, altura, puntosDireccion.ElementAt(puntosDireccion.Count - 1).Lat, puntosDireccion.ElementAt(puntosDireccion.Count - 1).Lng);

                dgvPuntos.DataSource = dtPuntos;

                //cboLocalidades.ResetText();
                textCalle.Text = "";
                textAltura.Text = "";
            }
            
        }

        private void btnInsMapa_Click(object sender, EventArgs e)
        {
            if(puntosDireccion.Count>0)
            this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Agregue puntos para insertar", "Mensaje del Sistema");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (puntosDireccion.Count > 0)
            {
                puntosDireccion.RemoveAt(puntosDireccion.Count - 1);
                dtPuntos.Rows.RemoveAt(dtPuntos.Rows.Count - 1);
                dgvPuntos.DataSource = dtPuntos;
            }
            else
            {
                MessageBox.Show("No hay puntos cargados", "Mensaje del Sistema");
            }
        }
    }
}
