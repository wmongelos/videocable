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
    public partial class frmCortesMapa : Form
    {
        DataTable dtPoligono = new DataTable();
        public DataTable dtCortes = new DataTable();
        Mapa oMapa = new Mapa();

        GMapOverlay markerOverlay;
        GMarkerGoogleDatos marker;

        GMapOverlay polygonOverlay;
        GMarkerGoogleDatos polygonMarker;

        List<PointLatLng> puntos = new List<PointLatLng>();

        private bool esta=false;
        public frmCortesMapa(DataTable dt)
        {
            InitializeComponent();
            dtCortes = dt.Copy();
        }

        private void frmCortesMapa_Load(object sender, EventArgs e)
        {
            setearDgv();
            setearMapa();
        }

        private void setearDgv()
        {
            dtPoligono = oMapa.MostrarTablaPoligono();
            dgvPoligono.DataSource = dtPoligono;
            dgvPoligono.Columns["id"].Visible = false;
            dgvPoligono.Columns["ST_AsText(puntos)"].Visible = false;
            dgvPoligono.Columns["descripcion"].HeaderText = "SECTORES";
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

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom++;
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom--;
        }

        private void dgvPoligonos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            polygonOverlay.Polygons.Clear();
            polygonOverlay.Markers.Clear();
            puntos.Clear();
            markerOverlay.Markers.Clear();
            esta = false;

            try
            {

                if (dgvPoligono.Rows.Count > 0)
                {
                    puntos.Clear();
                    string coordenadas;
                    coordenadas = Convert.ToString(dgvPoligono.SelectedRows[0].Cells["ST_AsText(puntos)"].Value).Replace("MULTIPOINT((", "").Replace("),", "").Replace("(", " ").Replace(")", "");

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

                    Actualizar();
                    gMapControl1.Position = new PointLatLng(puntos.ElementAt(0).Lat, puntos.ElementAt(0).Lng);
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Actualizar()
        {
            int contador = 0;
            GMapPolygon poligono = new GMapPolygon(puntos, "Poligono");
            polygonOverlay.Polygons.Add(poligono);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
            esta = true;

            PointLatLng coord = new PointLatLng();


            foreach (DataRow dr in dtCortes.Rows)
            {

                bool dentro = false;

                coord.Lat = Convert.ToDouble(dr["lat"], System.Globalization.CultureInfo.InvariantCulture);
                coord.Lng = Convert.ToDouble(dr["lng"], System.Globalization.CultureInfo.InvariantCulture);
                dr["Elige"] = false;

                dentro = poligono.IsInside(coord);
                //dentro = pnpoly(puntos, coord);

                if (dentro == true)
                {
                    contador++;
                    marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), GMarkerGoogleType.red);
                    markerOverlay.Markers.Add(marker);
                    dr["Elige"] = true;
                }


            }

            lblRegistros.Text = "Cantidad por zona: "+contador+"";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
