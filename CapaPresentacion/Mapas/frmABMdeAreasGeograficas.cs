using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using CapaNegocios.Mapas;


namespace CapaPresentacion.Mapas
{
    public partial class frmABMdeAreasGeograficas : Form
    {
        Mapa oMapa = new Mapa();
        DataTable dtPoligono = new DataTable();


        GMapOverlay markerOverlay;
        GMarkerGoogleDatos marker;

        GMapOverlay polygonOverlay;
        GMarkerGoogleDatos polygonMarker;

        List<PointLatLng> puntos = new List<PointLatLng>();

        //public List<PointLatLng> puntosDireccion = new List<PointLatLng>();
        public frmABMdeAreasGeograficas()
        {
            InitializeComponent();
        }

        private void frmABMdeAreasGeograficas_Load(object sender, EventArgs e)
        {
            dtPoligono = oMapa.MostrarTablaPoligono();
            dgvPoligonos.DataSource = dtPoligono;
            dgvPoligonos.Columns["id"].Visible = false;
            dgvPoligonos.Columns["ST_AsText(puntos)"].Visible = false;

            setearMapa();
        }

        private void setearMapa()
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(-36.5416395059612, -56.6925430297852);
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;


            markerOverlay = new GMapOverlay("Marcador");
            gMapControl1.Overlays.Add(markerOverlay);

            polygonOverlay = new GMapOverlay("Marcador");
            gMapControl1.Overlays.Add(polygonOverlay);

        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (esta == false)
            {
                double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                puntos.Add(new PointLatLng(lat, lng));

                //marker.Position = new PointLatLng(lat, lng);
                polygonMarker = new GMarkerGoogleDatos(new PointLatLng(lat, lng), GMarkerGoogleType.black_small);
                polygonMarker.Id = -1;


                polygonOverlay.Markers.Add(polygonMarker);

                if(this.KeyPreview==false)
                    this.KeyPreview=true;

                if (lblCancelar.Visible == false)
                    lblCancelar.Visible = true;

                //gMapControl1.Zoom = gMapControl1.Zoom + 1;
                //gMapControl1.Zoom = gMapControl1.Zoom - 1;

                //polygonMarker.ToolTipText = String.Format("Ubicacion: \n Latitud {0} \n Longitud {1}", lat, lng);

                //MessageBox.Show(Convert.ToString(polygonOverlay.Markers.Count()));
            }

        }

        bool esta = false;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        private void Insertar()
        {
            if (esta == false && puntos.Count > 0)
            {
                GMapPolygon poligono = new GMapPolygon(puntos, "Poligono");
                polygonOverlay.Polygons.Add(poligono);

                esta = true;

                lblNombre.Visible = true;
                textNombre.Visible = true;
                btnGuardar.Visible = true;
                textNombre.Focus();
                if (dgvPoligonos.SelectedRows.Count > 0)
                    dgvPoligonos.SelectedRows[0].Selected = false;
            }
            else if (puntos.Count < 1)
            {
                MessageBox.Show("Seleccione los puntos del poligono antes de insertar");
            }
            else
            {
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
                lblNombre.Visible = false;
                textNombre.Visible = false;
                textNombre.Text = "";
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;
                this.KeyPreview = false;
                lblCancelar.Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            string descripcion = textNombre.Text;

            if (descripcion == "")
            {
                MessageBox.Show("Ingrese una descripcion para el poligono");
            }
            else if (puntos.Count == 0)
            {
                MessageBox.Show("Dibuje un poligono antes de guardar");
            }
            else
            {
                try
                {
                    if (dgvPoligonos.SelectedRows.Count > 0)
                        oMapa.GuardarPoligono(puntos, descripcion, out mensaje, Convert.ToInt32(dgvPoligonos.SelectedRows[0].Cells["id"].Value));
                    else
                        oMapa.GuardarPoligono(puntos, descripcion, out mensaje);

                    MessageBox.Show(mensaje);
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }

            polygonOverlay.Polygons.Clear();
            polygonOverlay.Markers.Clear();
            puntos.Clear();
            markerOverlay.Markers.Clear();
            esta = false;
            lblNombre.Visible = false;
            textNombre.Visible = false;
            textNombre.Text = "";
            btnGuardar.Visible = false;
            this.KeyPreview = false;
            lblCancelar.Visible = false;
            dtPoligono = oMapa.MostrarTablaPoligono();
            dgvPoligonos.DataSource = dtPoligono;
        }

        private void dgvPoligonos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(esta==true)
            {
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
            }

            try
            {

                if (dgvPoligonos.Rows.Count > 0)
                {
                    puntos.Clear();
                    string coordenadas;
                    coordenadas = Convert.ToString(dgvPoligonos.SelectedRows[0].Cells["ST_AsText(puntos)"].Value).Replace("MULTIPOINT((", "").Replace("),", "").Replace("(", " ").Replace(")", "");

                    string[] subcoordenadas = coordenadas.Split(' ');

                    List<double> coord = new List<double>();

                    foreach (var sub in subcoordenadas)
                    {
                        coord.Add(Convert.ToDouble(sub, System.Globalization.CultureInfo.InvariantCulture));
                    }

                    for (int i = 0; i < coord.Count; i += 2)
                    {
                        puntos.Add(new PointLatLng(coord.ElementAt(i), coord.ElementAt(i + 1)));
                    }

                }

                if (esta == false)
                {
                    GMapPolygon poligono = new GMapPolygon(puntos, "Poligono");
                    polygonOverlay.Polygons.Add(poligono);

                    esta = true;

                    lblNombre.Visible = true;
                    textNombre.Visible = true;
                    textNombre.Text = Convert.ToString(dgvPoligonos.SelectedRows[0].Cells["descripcion"].Value);
                    btnGuardar.Visible = true;
                    btnEliminar.Visible = true;
                    textNombre.Focus();
                }
            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPoligonos.SelectedRows.Count > 0)
            {
                string mensaje = "";
                oMapa.EliminarPoligono(Convert.ToInt32(dgvPoligonos.SelectedRows[0].Cells["id"].Value), out mensaje);

                dtPoligono = oMapa.MostrarTablaPoligono();
                dgvPoligonos.DataSource = dtPoligono;
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
                lblNombre.Visible = false;
                textNombre.Visible = false;
                textNombre.Text = "";
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;

                MessageBox.Show(mensaje);
            }
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom++;
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom--;
        }

        private void frmABMdeAreasGeograficas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
                lblNombre.Visible = false;
                textNombre.Visible = false;
                textNombre.Text = "";
                btnGuardar.Visible = false;
                this.KeyPreview = false;
                lblCancelar.Visible = false;

            }
        }

        private void btnAreas_Click(object sender, EventArgs e)
        {
            Mapas.frmEstablecerAreas oFormulario = new Mapas.frmEstablecerAreas(dtPoligono);
            oFormulario.ShowDialog();
        }

        private void btnInsDir_Click(object sender, EventArgs e)
        {
            Mapas.frmInsertarPoligonoPorDirecciones oFormulario = new Mapas.frmInsertarPoligonoPorDirecciones();
            if (oFormulario.ShowDialog() == DialogResult.OK)
            {
                puntos=oFormulario.puntosDireccion;
                Insertar();

            }
        }
        
    }
}
