using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;


namespace CapaNegocios.Mapas
{
    public class GMarkerGoogleDatos : GMarkerGoogle
    {
        public Int32 Id { get; set; }

        public Int32 Id_Direccion { get; set; }

        public GMarkerGoogleDatos(PointLatLng p, GMarkerGoogleType type) : base(p, type) { }
        public GMarkerGoogleDatos(PointLatLng p, Bitmap Bitmap) : base(p, Bitmap) { }
    }
}
