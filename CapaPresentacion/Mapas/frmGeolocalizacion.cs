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
using CapaNegocios;
using CapaNegocios.Mapas;
using System.Threading;


namespace CapaPresentacion.Mapas
{
    public partial class frmGeolocalizacion : Form
    {
        private Thread hilo;
        private delegate void myDel();

        Mapa oLocalidad = new Mapa();
        DataTable dtLocalidad = new DataTable();
        DataTable dtLocalidad2 = new DataTable();
        DataTable dtPoligono = new DataTable();
        DataTable dtServicios = new DataTable();
        DataTable dtEstados = new DataTable();
        DataTable dtPartes = new DataTable();
        DataTable dtServiciosTipos = new DataTable();
        DataTable dtServiciosPartes = new DataTable();
        DataTable dtTablaPrueba = new DataTable();
        DataTable dtColores = new DataTable();

        Usuarios oUsu = new Usuarios();

        GMapOverlay markerOverlay;
        GMarkerGoogleDatos marker;

        GMapOverlay polygonOverlay;
        GMarkerGoogleDatos polygonMarker;

        List<PointLatLng> puntos = new List<PointLatLng>();

        public frmGeolocalizacion()
        {
            InitializeComponent();
        }

        private void Comenzar()
        {
            //dtLocalidad = oLocalidad.Buscar(textLocalidad.Text);
            //dtTablaPrueba = oLocalidad.TablaLocaciones();
            //dtLocalidad = oLocalidad.TablaServicios();        
            //dgvLocalidades.DataSource = dtTablaPrueba;
            //dtServicios = oLocalidad.Servicios();
            //dgv1.DataSource = dtServicios;

            dtEstados = oLocalidad.Estados();
            dtPartes = oLocalidad.Partes();
            dtServiciosTipos = oLocalidad.ServiciosTipos();
            dtColores = oLocalidad.TraerColores();
            dtPoligono = oLocalidad.MostrarTablaPoligono();
            // 
        }

        private void cargarMapa()
        {
            hilo = new Thread(new ThreadStart(CargarMapServicios));
            hilo.Start();
        }
        private void CargarMapServicios() 
        {
            dtServicios = oLocalidad.TablaServicios();
            progress1.Stop();
        }


        private void setReferencias()
        {
            string colorCable = Convert.ToString(dtColores.Rows[0]["color"]);
            string colorInternet = Convert.ToString(dtColores.Rows[1]["color"]);
            lblCombo.BackColor = Color.Yellow;
            lblCable.BackColor = Color.FromName(colorCable);
            lblInternet.BackColor = Color.FromName(colorInternet);
        }

        private void setearDgv()
        {
            dgvPoligono.DataSource = dtPoligono;
            dgvPoligono.Columns["id"].Visible = false;
            dgvPoligono.Columns["ST_AsText(puntos)"].Visible = false;
            dgvPoligono.Columns["descripcion"].HeaderText = "SECTORES";
        }


        private void crearCheckListBox()
        {


            foreach (DataRow drEstado in dtEstados.Rows)
            {
                checkedListBoxServiciosEstados.Items.Add(new CheckListBoxItem()
                {
                    Tag = drEstado["Id"].ToString(),
                    Text = drEstado["Estado"].ToString()
                });

            }

            foreach (DataRow drPartes in dtPartes.Rows)
            {
                checkedListBoxPartes.Items.Add(new CheckListBoxItem()
                {
                    Tag = drPartes["Id"].ToString(),
                    Text = drPartes["Nombre"].ToString()
                });

            }

            foreach (DataRow drServiciosTipos in dtServiciosTipos.Rows)
            {
                checkedListBoxServiciosTipos.Items.Add(new CheckListBoxItem()
                {
                    Tag = drServiciosTipos["Id"].ToString(),
                    Text = drServiciosTipos["Nombre"].ToString()
                });

            }
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

        private void comenzarCarga()
        {

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }


        private void cargarDatos()
        {
            try
            {

                Comenzar();


                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void asignarDatos()
        {
            crearCheckListBox();
            setReferencias();
            setearMapa();
            setearDgv();
            progress1.Start();
            cargarMapa();

        }

            private void frmGeolocalizacion_Load(object sender, EventArgs e)
        {
            comenzarCarga();

            //Comenzar();

            //crearCheckListBox();

            //setearMapa();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Localidad localidad = new Localidad();
            //DataTable dtLocalidad = new DataTable();         
            //dtLocalidad = localidad.Buscar(localidad);
            //dgvLocalidades.DataSource = dtLocalidad;
            //Limpiar();
        }

        private void dgvLocalidades_SelectionChanged(object sender, EventArgs e)
        {
            //    try 
            //    { 
            //        if(dgvLocalidades.Rows.Count > 0) 
            //        { 

            //            textLocalidad.Text = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["descripcion"].Value); //oSelected.tostring() al final
            //            textCalle.Text = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["calle"].Value);
            //            textAltura.Text = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["altura"].Value);
            //        }
            //    }
            //    catch { }

        }

        private void txtGral_TextChanged(object sender, EventArgs e)
        {
            //dtLocalidad.DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%' OR apellido LIKE '%{0}%' OR calle LIKE '%{0}%' OR Convert([altura], System.String) LIKE '%{0}%'", txtGral.Text);
        }

        private void dgvLocalidades_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    if (dgvLocalidades.Rows.Count > 0)
            //    {
            //        marker.Overlay.Markers.Clear();
            //        //textLocalidad.Text = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["localidad"].Value); //oSelected.tostring() al final
            //        //textCalle.Text = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["calle"].Value);
            //        //textAltura.Text = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["altura"].Value);
            //        string calle = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["calle"].Value);
            //        string altura = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["altura"].Value);
            //        string localidad = Convert.ToString(dgvLocalidades.SelectedRows[0].Cells["localidad"].Value);
            //        double lat = Convert.ToDouble(dgvLocalidades.SelectedRows[0].Cells["lat"].Value, System.Globalization.CultureInfo.InvariantCulture);
            //        double lng = Convert.ToDouble(dgvLocalidades.SelectedRows[0].Cells["lng"].Value, System.Globalization.CultureInfo.InvariantCulture);
            //        gMapControl1.Position = new PointLatLng(lat, lng);
            //        marker = new GMarkerGoogleDatos(new PointLatLng(lat, lng), GMarkerGoogleType.arrow);
            //        marker.ToolTipText = String.Format("Calle {0} al {1} \n {2}", calle, altura, localidad);
            //        markerOverlay.Markers.Add(marker);
            //        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            //        //marker.ToolTipText = "" + Calle + " " + Altura + "\n" + Localidad + "";
            //        gMapControl1.Zoom = gMapControl1.Zoom + 1;
            //        gMapControl1.Zoom = gMapControl1.Zoom - 1;

            //    }
            //}
            //catch { }
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(esta==false)
            {
                double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                puntos.Add(new PointLatLng(lat, lng));

                //marker.Position = new PointLatLng(lat, lng);
                polygonMarker = new GMarkerGoogleDatos(new PointLatLng(lat, lng), GMarkerGoogleType.black_small);
                polygonMarker.Id = -1;


                polygonOverlay.Markers.Add(polygonMarker);

                if (this.KeyPreview == false)
                    this.KeyPreview = true;

                if (lblCancelar.Visible == false)
                    lblCancelar.Visible = true;

                //gMapControl1.Zoom = gMapControl1.Zoom + 1;
                //gMapControl1.Zoom = gMapControl1.Zoom - 1;

                //polygonMarker.ToolTipText = String.Format("Ubicacion: \n Latitud {0} \n Longitud {1}", lat, lng);

                //MessageBox.Show(Convert.ToString(polygonOverlay.Markers.Count()));
            }

        }

        private void btnCoord_Click(object sender, EventArgs e)
        {
            //oLocalidad.AgregarCoord();
            Comenzar();
        }

        bool esta = false;
        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            if (tabControlFiltro.SelectedTab.Name == "tabPage1")
            {
                InsertaPoligonoBien();
            }
            else if (tabControlFiltro.SelectedTab.Name == "tabPage2")
            {
                if (esta == false && puntos.Count > 0)
                {
                    progress1.Start();
                    cargarServiciosPartes();
                }
                else
                    InsertarPoligonoBien2();
            }
        }

        private void cargarServiciosPartes()
        {
            hilo = new Thread(new ThreadStart(traerServiciosPartes));
            hilo.Start();
            
            //hilo.Join();
        }

        private void traerServiciosPartes()
        {
            dtServiciosPartes = oLocalidad.ServiciosPartes(dateTimePickerDesde.Value, dateTimePickerHasta.Value);
            progress1.Stop();

            myDel MD = new myDel(InsertarPoligonoBien2);

            this.Invoke(MD, new object[] { });
            
        }

        private bool pnpoly(List<PointLatLng> poly, PointLatLng pnt)
        {

            //true esta || false no esta
            int i, j;
            int nvert = poly.Count;
            bool c = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((poly.ElementAt(i).Lat > pnt.Lat) != (poly.ElementAt(j).Lat > pnt.Lat)) &&
                 (pnt.Lng < (poly.ElementAt(j).Lng - poly.ElementAt(i).Lng) * (pnt.Lat - poly.ElementAt(i).Lat) / (poly.ElementAt(j).Lat - poly.ElementAt(i).Lat) + poly.ElementAt(i).Lng))
                    c = !c;
            }
            return c;
        }

        private void btnGuardarPoligono_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            string descripcion = ""; //= textPoligono.Text;
            Mapa localidad = new Mapa();
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
                    localidad.GuardarPoligono(puntos, descripcion, out mensaje);
                    MessageBox.Show(mensaje);
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            dtPoligono=localidad.MostrarTablaPoligono();
            dgvPoligono.DataSource = dtPoligono;
        }

        private void dgvPoligono_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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


                    if (tabControlFiltro.SelectedTab.Name == "tabPage1")
                    {
                        InsertaPoligonoBien();
                    }
                    else if (tabControlFiltro.SelectedTab.Name == "tabPage2")
                    {
                        if (esta == false && puntos.Count > 0)
                        {
                            progress1.Start();
                            cargarServiciosPartes();
                        }
                    }

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
            GMapPolygon poligono = new GMapPolygon(puntos, "Poligono");
            polygonOverlay.Polygons.Add(poligono);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
            esta = true;

            PointLatLng coord = new PointLatLng();


            foreach (DataRow dr in dtServicios.Rows)
            {

                bool dentro = false;

                coord.Lat = Convert.ToDouble(dr["lat"], System.Globalization.CultureInfo.InvariantCulture);
                coord.Lng = Convert.ToDouble(dr["lng"], System.Globalization.CultureInfo.InvariantCulture);
                string calle = Convert.ToString(dr["calle"]);
                string altura = Convert.ToString(dr["altura"]);
                string localidad = Convert.ToString(dr["localidad"]);
                string[] grupos = Convert.ToString(dr["ids_grupos"]).Split(',');
                string[] estados = Convert.ToString(dr["ids_estados"]).Split(',');
                int id = Convert.ToInt32(dr["id_usuario"]);
                int id_direccion = Convert.ToInt32(dr["id_direccion"]);
                GMarkerGoogleType MarkerColor;
                dentro = pnpoly(puntos, coord);

                int flag = 0, cant2 = 0, cant1 = 0;
                string colorAux2 = "";
                string colorAux1 = "";
                if (dentro == true)
                {
                    if (grupos.Length > 1)
                    {
                        string[] color1 = Convert.ToString(dr["color"]).Split(',');

                        for (int i = 0; i < grupos.Length; i++)
                        {

                            if (rbCombo.Checked || rbTodos.Checked)
                            {

                                if (idsEstados.Contains(Convert.ToInt32(estados[i])) && grupos[i] == "2")
                                {
                                    cant2++;
                                    colorAux2 = color1[i];
                                }
                                else if (idsEstados.Contains(Convert.ToInt32(estados[i])) && grupos[i] == "1")
                                {
                                    cant1++;
                                    colorAux1 = color1[i];
                                }
                                if (cant1 >= 1 && cant2 >= 1 && flag == 0)
                                {
                                    flag = 1;
                                    string color = "yellow";
                                    MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), color, true);
                                    marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                                    marker.Id = id;
                                    marker.Id_Direccion = id_direccion;
                                    marker.ToolTipText = String.Format("Calle {0} al {1} \n {2}", calle, altura, localidad);
                                    markerOverlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                            }
                            else if (
                                        ((rbInternet.Checked && grupos[i] == "2" && flag == 0) ||
                                        (rbCable.Checked && grupos[i] == "1" && flag == 0) ||
                                        (rbTodos.Checked && flag == 0)) &&
                                        (idsEstados.Contains(Convert.ToInt32(estados[i])))
                                    )
                            {
                                flag = 1;

                                MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), color1[i], true);
                                marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                                marker.Id = id;
                                marker.Id_Direccion = id_direccion;
                                marker.ToolTipText = String.Format("Calle {0} al {1} \n {2}", calle, altura, localidad);
                                markerOverlay.Markers.Add(marker);
                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            }
                        }

                        if (cant1 == 0 && cant2 >= 1 && flag == 0 && rbTodos.Checked)
                        {
                            flag = 1;

                            MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), colorAux2, true);
                            marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                            marker.Id = id;
                            marker.Id_Direccion = id_direccion;
                            marker.ToolTipText = String.Format("Calle {0} al {1} \n {2}", calle, altura, localidad);
                            markerOverlay.Markers.Add(marker);
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }
                        if (cant1 >= 1 && cant2 == 0 && flag == 0 && rbTodos.Checked)
                        {
                            flag = 1;

                            MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), colorAux1, true);
                            marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                            marker.Id = id;
                            marker.Id_Direccion = id_direccion;
                            marker.ToolTipText = String.Format("Calle {0} al {1} \n {2}", calle, altura, localidad);
                            markerOverlay.Markers.Add(marker);
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }

                    }

                    else if (
                            ((rbInternet.Checked && grupos[0] == "2") ||
                            (rbCable.Checked && grupos[0] == "1") ||
                            (rbTodos.Checked)) &&
                            (idsEstados.Contains(Convert.ToInt32(estados[0])))
                            )
                    {
                        string color = Convert.ToString(dr["color"]);
                        MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), color, true);
                        marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                        marker.Id = id;
                        marker.Id_Direccion = id_direccion;
                        marker.ToolTipText = String.Format("Calle {0} al {1} \n {2}", calle, altura, localidad);
                        markerOverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    }
                }


            }
        }
        private void InsertaPoligonoBien()
        {
            if (esta == false && puntos.Count > 0)
            {
                Actualizar();
            }
            else if (puntos.Count == 0)
            {
                MessageBox.Show("Seleccione los puntos del poligono con Doble click antes de Insertar o Seleccione uno de la Tabla");
            }
            else
            {
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
                this.KeyPreview = false;
                lblCancelar.Visible = false;
            }
        }
        private void actualizarRadioBien()
        {
            markerOverlay.Markers.Clear();
            polygonOverlay.Polygons.Clear();
            if (esta == true && puntos.Count > 0)
            {
                Actualizar();
            }

        }

        private void rbInternet_CheckedChanged(object sender, EventArgs e)
        {
            if (esta == true)
            {
                actualizarRadioBien();
            }
        }

        private void rbCable_CheckedChanged(object sender, EventArgs e)
        {
            if (esta == true)
            {
                actualizarRadioBien();
            }
        }

        private void rbCombo_CheckedChanged(object sender, EventArgs e)
        {
            if (esta == true)
            {
                actualizarRadioBien();
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (esta == true)
            {
                actualizarRadioBien();
            }
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            Int32 id = ((GMarkerGoogleDatos)item).Id;
            if (id != -1)
            {
                Int32 id_direccion = ((GMarkerGoogleDatos)item).Id_Direccion;
                oUsu.LlenarObjeto(id);
                Usuarios.CurrentUsuario.Id_Usuarios_Locacion = id_direccion;
                this.Close();
            }
        }
        



        // hacer los radio button de estados check button y agregar id_estados en insertar poligono y actualizar


        private List<int> idsEstados = new List<int>();
        private void checkedListBoxServiciosEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

            idsEstados.Clear();
            var chequeados = checkedListBoxServiciosEstados.CheckedItems;

            foreach (CheckListBoxItem item in chequeados)
            {
                idsEstados.Add(Convert.ToInt32(item.Tag));
            }

            if (esta == true)
            {
                actualizarRadioBien();
            }
        }

        private List<int> idsPartes = new List<int>();
        private void checkedListBoxPartes_SelectedIndexChanged(object sender, EventArgs e)
        {

            idsPartes.Clear();
            var chequeados = checkedListBoxPartes.CheckedItems;

            foreach (CheckListBoxItem item in chequeados)
            {
                idsPartes.Add(Convert.ToInt32(item.Tag));
            }

            if (esta == true)
            {
                actualizarRadioBien2();
            }
        }

        private List<int> idsServiciosTipos = new List<int>();

        private void checkedListBoxServiciosTipos_SelectedIndexChanged(object sender, EventArgs e)
        {

            idsServiciosTipos.Clear();
            var chequeados = checkedListBoxServiciosTipos.CheckedItems;

            foreach (CheckListBoxItem item in chequeados)
            {
                idsServiciosTipos.Add(Convert.ToInt32(item.Tag));
            }

            if (esta == true)
            {
                actualizarRadioBien2();
            }
        }


        private void Actualizar2()
        {
            GMapPolygon poligono = new GMapPolygon(puntos, "Poligono");
            polygonOverlay.Polygons.Add(poligono);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
            esta = true;

            PointLatLng coord = new PointLatLng();

            string primerColor=Convert.ToString(dtColores.Rows[0]["color"]);
            string segundoColor = Convert.ToString(dtColores.Rows[1]["color"]);

            foreach (DataRow dr in dtServiciosPartes.Rows)
            {

                bool dentro = false;

                coord.Lat = Convert.ToDouble(dr["lat"], System.Globalization.CultureInfo.InvariantCulture);
                coord.Lng = Convert.ToDouble(dr["lng"], System.Globalization.CultureInfo.InvariantCulture);
                string calle = Convert.ToString(dr["calle"]);
                string altura = Convert.ToString(dr["altura"]);
                string[] parte = Convert.ToString(dr["id_parte"]).Split(',');
                string[] partes = Convert.ToString(dr["id_parte_operacion"]).Split(',');
                string[] servicios = Convert.ToString(dr["id_servicio_tipo"]).Split(',');
                int id = Convert.ToInt32(dr["id_usuario"]);
                int id_direccion = Convert.ToInt32(dr["id_direccion"]);
                GMarkerGoogleType MarkerColor;
                dentro = pnpoly(puntos, coord);

                int flag = 0, cant2 = 0, cant1 = 0;
                string colorAux2 = "";
                string colorAux1 = "";
                if (dentro == true)
                {
                    if (partes.Length > 1)
                    {
                        string[] color1 = Convert.ToString(dr["color"]).Split(',');

                        for (int i = 0; i < partes.Length; i++)
                        {
                            if (idsPartes.Contains(Convert.ToInt32(partes[i])) && idsServiciosTipos.Contains(Convert.ToInt32(servicios[i])) && color1[i].Equals(segundoColor))
                            {
                                cant2++;
                                colorAux2 = color1[i];
                            }
                            if (idsPartes.Contains(Convert.ToInt32(partes[i])) && idsServiciosTipos.Contains(Convert.ToInt32(servicios[i])) && color1[i].Equals(primerColor))
                            {
                                cant1++;
                                colorAux1 = color1[i];
                            }
                            if (cant1 >= 1 && cant2 >= 1)
                            {
                                flag = 1;
                            }
                        }

                        if (flag == 1)
                        {
                            string color = "yellow";
                            MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), color, true);
                            marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                            marker.Id = id;
                            marker.Id_Direccion = id_direccion;
                            marker.ToolTipText = String.Format("Calle {0} al {1} \n", calle, altura);
                            markerOverlay.Markers.Add(marker);
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }

                        if (cant1 == 0 && cant2 >= 1 && flag == 0)
                        {
                            MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), colorAux2, true);
                            marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                            marker.Id = id;
                            marker.Id_Direccion = id_direccion;
                            marker.ToolTipText = String.Format("Calle {0} al {1}", calle, altura);
                            markerOverlay.Markers.Add(marker);
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }
                        if (cant1 >= 1 && cant2 == 0 && flag == 0)
                        {
                            MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), colorAux1, true);
                            marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                            marker.Id = id;
                            marker.Id_Direccion = id_direccion;
                            marker.ToolTipText = String.Format("Calle {0} al {1}", calle, altura);
                            markerOverlay.Markers.Add(marker);
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        }
                    }

                    else if (idsPartes.Contains(Convert.ToInt32(partes[0])) && idsServiciosTipos.Contains(Convert.ToInt32(servicios[0])))
                    {
                        string color = Convert.ToString(dr["color"]);
                        MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), color, true);
                        marker = new GMarkerGoogleDatos(new PointLatLng(coord.Lat, coord.Lng), MarkerColor);
                        marker.Id = id;
                        marker.Id_Direccion = id_direccion;
                        marker.ToolTipText = String.Format("Calle {0} al {1} \n", calle, altura);
                        markerOverlay.Markers.Add(marker);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    }
                }
            }
        }

        private void InsertarPoligonoBien2()
        {
            if (esta == false && puntos.Count > 0)
            {
                Actualizar2();
            }
            else if (puntos.Count == 0)
            {
                MessageBox.Show("Seleccione los puntos del poligono con Doble click antes de Insertar o Seleccione uno de la Tabla");
            }
            else
            {
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
                this.KeyPreview = false;
                lblCancelar.Visible = false;
            }
        }

        private void actualizarRadioBien2()
        {
            markerOverlay.Markers.Clear();
            polygonOverlay.Polygons.Clear();
            if (esta == true && puntos.Count > 0)
            {
                Actualizar2();
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom--;
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom++;
        }

        private void frmGeolocalizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                polygonOverlay.Polygons.Clear();
                polygonOverlay.Markers.Clear();
                puntos.Clear();
                markerOverlay.Markers.Clear();
                esta = false;
                this.KeyPreview = false;
                lblCancelar.Visible = false;

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }


    class CheckListBoxItem
    {
        public object Tag;
        public string Text;
        public override string ToString() { return Text; }
    }


}
