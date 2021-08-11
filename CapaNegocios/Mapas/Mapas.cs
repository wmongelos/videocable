using System;
using CapaDatos;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using GMap.NET;
using System.Globalization;

namespace CapaNegocios.Mapas
{
    public delegate void PorcentajeHandler(int numero);
    public class Mapa
    {
        //adasd
        /// CapaDatos.Localidad oLocalidad = new CapaDatos.Localidad();
        public Int32 Id;
        public String Descripcion;
        public String Calle;
        public Int32 Altura;

        public event PorcentajeHandler OnPorcentaje;
        private int numeroRegistros;
        private int numeroRegistrosPorPorcentaje;
        private bool actualizando;

        private Conexion oCon = new Conexion();

        public DataTable TraerColores()
        {

            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("SELECT color FROM servicios_grupos");
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;
        }


        public DataTable MostrarTabla()
        {

            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando(" SELECT usuarios_locaciones.Id AS id_direccion, servicios_grupos.Id AS id_servicio," +
                              " usuarios_locaciones.Id_Usuarios AS id, usuarios.Nombre AS nombre," +
                              " usuarios.Apellido AS apellido, localidades.Nombre AS localidad," +
                              " provincias.Nombre AS provincia, usuarios_locaciones.Calle AS calle," +
                              " usuarios_locaciones.Altura AS altura, servicios_tipos.Nombre AS nombre_servicio," +
                              " usuarios_locaciones.lat AS lat, usuarios_locaciones.lng AS lng," +
                              " servicios_grupos.color AS color, servicios_estados.Id AS id_estados" +
                              " FROM usuarios_locaciones" +
                              " INNER JOIN usuarios ON usuarios.Id = usuarios_locaciones.Id_Usuarios" +
                              " INNER JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades" +
                              " INNER JOIN provincias ON provincias.Id = usuarios_locaciones.Id_Provincias" +
                              " INNER JOIN usuarios_servicios ON usuarios_servicios.Id_Usuarios = usuarios.Id" +
                              " INNER JOIN servicios_tipos ON servicios_tipos.Id = usuarios_servicios.Id_Servicios_Tipo" +
                              " INNER JOIN servicios_grupos ON servicios_grupos.Id = servicios_tipos.Id_Servicios_Grupos" +
                              " INNER JOIN servicios_estados ON servicios_estados.Id = usuarios_servicios.Id_Servicios_Estados" +
                              " WHERE usuarios_locaciones.Borrado = 0 AND usuarios_servicios.Borrado = 0 AND usuarios_locaciones.Id_Usuarios=8 LIMIT 200;");
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;

        }

        public DataTable TablaServicios()
        {

            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando(" SELECT usuarios_locaciones.Id_Usuarios AS id_usuario, usuarios_locaciones.Id AS id_direccion," +
                              " GROUP_CONCAT(servicios_grupos.Id) AS ids_grupos," +
                              " GROUP_CONCAT(usuarios_servicios.Id_Servicios) AS ids_servicios," +
                              " GROUP_CONCAT(servicios_estados.Id) AS ids_estados, usuarios.Nombre AS nombre," +
                              " GROUP_CONCAT(servicios_grupos.color) AS color," +
                              " usuarios.Apellido AS apellido, localidades.Nombre AS localidad," +
                              " usuarios_locaciones.Calle AS calle," +
                              " usuarios_locaciones.Altura AS altura, servicios_tipos.Nombre AS nombre_servicio," +
                              " usuarios_locaciones.lat AS lat, usuarios_locaciones.lng AS lng" +
                              " FROM usuarios_locaciones" +
                              " INNER JOIN usuarios ON usuarios.Id = usuarios_locaciones.Id_Usuarios" +
                              " INNER JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades" +
                              " INNER JOIN usuarios_servicios ON usuarios_servicios.Id_Usuarios = usuarios.Id" +
                              " INNER JOIN servicios_tipos ON servicios_tipos.Id = usuarios_servicios.Id_Servicios_Tipo" +
                              " INNER JOIN servicios_grupos ON servicios_grupos.Id = servicios_tipos.Id_Servicios_Grupos" +
                              " INNER JOIN servicios_estados ON servicios_estados.Id = usuarios_servicios.Id_Servicios_Estados" +
                              " WHERE usuarios_locaciones.Borrado = 0 AND usuarios_servicios.Borrado = 0" +
                              " GROUP BY id_direccion");
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;

        }


        public DataTable TablaLocaciones()
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando(" SELECT usuarios_locaciones.Id AS id_direccion," +
                             " localidades.Nombre AS localidad," +
                             " usuarios_locaciones.Calle AS calle, usuarios_locaciones.Altura AS altura," +
                             " usuarios_locaciones.lat AS lat, usuarios_locaciones.lng AS lng" +
                             " FROM usuarios_locaciones" +
                             " INNER JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades" +
                             " WHERE usuarios_locaciones.Borrado = 0 AND lat='0'");
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;
        }

        public void AgregarCoord(DataTable dt)
        {
            //DataTable dt = new DataTable();
            //dt = TablaLocaciones();

            actualizando = true;

            Int32 Id;
            string Calle;
            string Altura;
            string Localidad;
            string lng = "";
            string lat = "";
            WebClient wc = new WebClient();

            //linea para solucionar el error de download string
            System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            if (OnPorcentaje != null)
            {
                DeterminarCantidadDeRegistrosPorPorcentaje(dt.Rows.Count);
            }

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                int index = 0, porcentaje = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (!actualizando)
                    {
                        oCon.CancelarTransaccion();
                        oCon.DesConectar();
                        return;
                    }

                    index++;
                    if (OnPorcentaje != null && index % numeroRegistrosPorPorcentaje == 0) // && index % numeroRegistrosPorPorcentaje == 0
                    {
                        OnPorcentaje(++porcentaje);
                    }

                    Id = Convert.ToInt32(dr["id_direccion"]);
                    Calle = Convert.ToString(dr["calle"]).Replace(" ", "+");
                    Altura = Convert.ToString(dr["altura"]).Replace(" ", "+");
                    Localidad = Convert.ToString(dr["localidad"]).Replace(" ", "+");
                    if (Convert.ToString(dr["lat"], System.Globalization.CultureInfo.InvariantCulture) == "0")
                    {
                        var url1 = "https://maps.googleapis.com/maps/api/geocode/json?address=" + Altura + "+Calle+" + Calle + ",+" + Localidad + ",+Argentina&key=";
                        var datos = wc.DownloadString(url1);
                        var resultado = JsonConvert.DeserializeObject<Root>(datos);
                        foreach (var coord in resultado.results)
                        {
                            lat = Convert.ToString(coord.geometry.location.lat, System.Globalization.CultureInfo.InvariantCulture);
                            lng = Convert.ToString(coord.geometry.location.lng, System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }

                    oCon.CrearComando("UPDATE usuarios_locaciones SET lat = '" + lat + "', lng = '" + lng + "' WHERE id= " + Id + " AND lat='0'");
                    oCon.EjecutarComando();

                }
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                actualizando = false;

            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                actualizando = false;
                throw ex;
            }
        }

        public void CancelarCargaDeCoordenadas()
        {
            actualizando = false;
        }

        private void DeterminarCantidadDeRegistrosPorPorcentaje(int cantidadDeRegistros)
        {
            if (cantidadDeRegistros < 100)
            {
                numeroRegistros = cantidadDeRegistros;
                numeroRegistrosPorPorcentaje = 100 / numeroRegistros;
            }
            else
            {
                numeroRegistros = cantidadDeRegistros;
                numeroRegistrosPorPorcentaje = numeroRegistros / 100;
            }
            
        }
        public PointLatLng ObtenerCoordenadas(string localidad, string calle, string altura)
        {
            PointLatLng latLng = new PointLatLng();
            WebClient wc = new WebClient();

            calle=calle.Replace(" ", "+");
            localidad=localidad.Replace(" ", "+");

            var url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + altura + "+Calle+" + calle + ",+" + localidad + ",+Argentina&key=AIzaSyAgkK5ZGD1RWtdJG-U5JyHju9dcBE2EfFs";
            var datos = wc.DownloadString(url);
            var resultado = JsonConvert.DeserializeObject<Root>(datos);
            foreach (var coord in resultado.results)
            {
                latLng.Lat = coord.geometry.location.lat;
                latLng.Lng = coord.geometry.location.lng;
            }

            return latLng;
        }

        public DataTable TraerLatLng(int id)
        {
            DataTable dt = new DataTable();


            oCon.Conectar();
            oCon.CrearComando("SELECT lat,lng FROM usuarios_locaciones where Id=@id");
            oCon.AsignarParametroEntero("@id", id);
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;
        }
            
        public void GuardarPoligono(List<PointLatLng> puntos, string descripcion, out string msg, int id=0)
        {
            string comando = "";

            if(id>0)
            {
                comando = "UPDATE poligono SET descripcion='" + descripcion + "' WHERE id="+id+"";
                msg = "Actualizado";
            }
            else
            {

                comando = "INSERT INTO poligono(descripcion, puntos) VALUES('" + descripcion + "', ST_GEOMFROMTEXT('MULTIPOINT(";

                string aux;

                foreach (var coord in puntos)
                {
                    aux = Convert.ToString(coord.Lat).Replace(",", ".");
                    comando += String.Join(" ", aux, "");
                    if (puntos.Last().Lng != coord.Lng)
                    {
                        aux = Convert.ToString(coord.Lng).Replace(",", ".");
                        comando += String.Join("", aux, ",");
                    }
                    else
                    {
                        aux = Convert.ToString(coord.Lng).Replace(",", ".");
                        comando += String.Join("", aux, "");
                    }
                }

                comando += String.Join("", ")'))");
                msg = "Insertado";

            }

            try
            {
                oCon.Conectar();
                oCon.CrearComando(comando);
                oCon.EjecutarComando();
                oCon.DesConectar();
                
            }
            catch (Exception c)
            {
                throw c;
            }
        }

        public void EliminarPoligono(int id, out string msg)
        {
            string comando="";
            comando = "UPDATE poligono SET borrado=1 WHERE id=" + id + "";

            try
            {
                oCon.Conectar();
                oCon.CrearComando(comando);
                oCon.EjecutarComando();
                oCon.DesConectar();

                msg = "Eliminado con exito";
            }
            catch (Exception c)
            {
                throw c;
            }
        }

        public DataTable MostrarTablaPoligono()
        {

            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("SELECT id,descripcion,ST_AsText(puntos) FROM poligono WHERE borrado=0");
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;


        }

        public DataTable Servicios()
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("SELECT direccion_servicio.id AS id_direccion_servicio, servicio.id AS id_servicio, " +
                              "localidad.id AS id_direccion, localidad.descripcion AS L_descripcion, " +
                              "calle, altura, lat, lng, color, servicio.descripcion AS desc_servicio " +
                              "FROM direccion_servicio " +
                              "INNER JOIN localidad ON localidad.id = direccion_servicio.id_direccion " +
                              "INNER JOIN servicio ON servicio.id = direccion_servicio.id_servicio");
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;
        }

        public DataTable Estados()
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("SELECT Id,Estado FROM servicios_estados");
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;
        }

        public DataTable Partes()
        {
            DataTable dt = new DataTable();


            oCon.Conectar();
            oCon.CrearComando("SELECT Id,Nombre FROM partes_operaciones");
            dt = oCon.Tabla();
            oCon.DesConectar();


            return dt;
        }

        public DataTable ServiciosTipos()
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("SELECT Id,Nombre FROM servicios_tipos");
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;
        }

        public DataTable ServiciosPartes(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(" SET SESSION group_concat_max_len = 1000000; " +
                                  " SELECT usuarios_locaciones.id AS id_direccion," +
                                  " GROUP_CONCAT(partes.id) AS id_parte," +
                                  " GROUP_CONCAT(partes_fallas.Id_Partes_Operaciones) AS id_parte_operacion," +
                                  " IF(partes_usuarios_servicios.Id_usuarios_servicios = 0, GROUP_CONCAT(partes_usuarios_servicios.id_servicio_tipo), GROUP_CONCAT(servicios.Id_Servicios_Tipos) )  AS id_servicio_tipo," +
                                  " partes.Id_Usuarios AS id_usuario," +
                                  " usuarios_locaciones.Calle AS calle, usuarios_locaciones.Altura AS altura," +
                                  " usuarios_locaciones.lat, usuarios_locaciones.lng," +
                                  " GROUP_CONCAT(partes.Fecha_Reclamo) AS Fecha_Reclamo," +
                                  " GROUP_CONCAT(servicios_grupos.color) AS color" +
                                  " FROM partes_usuarios_servicios" +
                                  " INNER JOIN partes ON partes_usuarios_servicios.Id_parte = partes.id" +
                                  " INNER JOIN partes_fallas ON partes.Id_Partes_Fallas = partes_fallas.id" +
                                  " INNER JOIN usuarios_locaciones ON partes.Id_Usuarios_Locaciones = usuarios_locaciones.id" +
                                  " INNER JOIN servicios ON partes_usuarios_servicios.Id_servicio = servicios.id" +
                                  " INNER JOIN servicios_tipos ON servicios_tipos.Id = servicios.Id_Servicios_Tipos" +
                                  " INNER JOIN servicios_grupos ON servicios_grupos.Id = servicios_tipos.Id_Servicios_Grupos" +
                                  " WHERE partes_usuarios_servicios.Borrado = 0 AND partes.borrado = 0" +
                                  " AND DATE(partes.Fecha_Reclamo) BETWEEN '" + desde.ToString("yyyy-MM-dd") + "' AND '" + hasta.ToString("yyyy-MM-dd") + "'" +
                                  " GROUP BY usuarios_locaciones.Id;");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;


        }

    }

}