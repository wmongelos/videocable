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
    public partial class frmVerUsuarioMapa : Form
    {
        GMapOverlay markerOverlay;

        GMarkerGoogleDatos marker;

        Mapa oLocacion = new Mapa();

        public frmVerUsuarioMapa()
        {
            InitializeComponent();
        }

        private void frmVerUsuarioMapa_Load(object sender, EventArgs e)
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
            marker.ToolTipText = String.Format("{0} \n AL {1}", Usuarios.CurrentUsuario.Calle, Convert.ToString(Usuarios.CurrentUsuario.Altura));
            markerOverlay.Markers.Add(marker);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
