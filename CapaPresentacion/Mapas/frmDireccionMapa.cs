using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using CapaNegocios;
using CapaNegocios.Mapas;

namespace CapaPresentacion.Mapas
{
    public partial class frmDireccionMapa : Form
    {
        GMapOverlay markerOverlay;

        GMarkerGoogleDatos marker;

        PointLatLng nuevasCoord = new PointLatLng();

        Mapa oLocacion = new Mapa();

        Usuarios oUsu = new Usuarios();


        public frmDireccionMapa()
        {
            InitializeComponent();
        }

        private void frmDireccionMapa_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = oLocacion.TraerLatLng(Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
            double lat = Convert.ToDouble(dt.Rows[0]["lat"], System.Globalization.CultureInfo.InvariantCulture);
            double lng = Convert.ToDouble(dt.Rows[0]["lng"], System.Globalization.CultureInfo.InvariantCulture);
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(lat, lng);
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 17;
            gMapControl1.AutoScroll = true;
            markerOverlay = new GMapOverlay("Marcador");
            gMapControl1.Overlays.Add(markerOverlay);
            marker = new GMarkerGoogleDatos(new PointLatLng(lat, lng), GMarkerGoogleType.green);
            marker.ToolTipText = String.Format("Ubicacion: \n Latitud {0} \n Longitud {1}", lat, lng);
            markerOverlay.Markers.Add(marker);
        }
        private void btnGeo_Click(object sender, EventArgs e)
        {
            Mapa localidad = new Mapa();
            PointLatLng coord = new PointLatLng();
            if (textLocalidad.Text == "" || textCalle.Text == "" || textAltura.Text == "")
                MessageBox.Show("Error, complete correctamente los campos");
            else
            {
                coord = localidad.ObtenerCoordenadas(textLocalidad.Text, textCalle.Text, textAltura.Text);
                MessageBox.Show("" + coord.Lat + ", " + coord.Lng + "");

                markerOverlay.Markers.Clear();

                gMapControl1.Position = new PointLatLng(coord.Lat, coord.Lng);
             
                marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), GMarkerGoogleType.green);
                marker.ToolTipText = String.Format("Ubicacion: \n Latitud {0} \n Longitud {1}", coord.Lat, coord.Lng);
                markerOverlay.Markers.Add(marker);
            }
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            markerOverlay.Markers.Clear();

            nuevasCoord.Lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            nuevasCoord.Lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            marker = new GMarkerGoogleDatos(new PointLatLng(nuevasCoord.Lat, nuevasCoord.Lng), GMarkerGoogleType.green);
            marker.ToolTipText = String.Format("Ubicacion: \n Latitud {0} \n Longitud {1}", nuevasCoord.Lat, nuevasCoord.Lng);
            markerOverlay.Markers.Add(marker);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //metodo que guarda lat y long en la base
            MessageBox.Show("POSICION SETEADA");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
