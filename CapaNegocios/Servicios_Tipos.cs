using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Tipos
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Id_Servicios_Grupos { get; set; }
        public Int32 Borrado { get; set; }
        private Partes_Soluciones oPartesSoluciones = new Partes_Soluciones();
        public enum TIPOS 
        {  
            TV_BASICA = 1 ,  
            DIGITAL_HD_DIBOX = 2,
            DIGITAL_HD_MINETTI = 3,
            INTERNET = 4,
            INTERNET_SATELITAL=5,
            DIGITAL_MMDS=6,
            INTERNET_IOT=7,
            NO_TIC=8,
            PUBLICIDAD=9,
            INTERNET_PBU_Y_O = 10
        }

        private Conexion oCon = new Conexion();

        public void Guardar(Servicios_Tipos oSerTipo)
        {
            try
            {
                bool agregarOperacion = true;

                oCon.Conectar();

                if (oSerTipo.Id > 0)
                {
                    oCon.CrearComando("UPDATE Servicios_Tipos SET Nombre = @nombre, Id_Servicios_Grupos = @grupo WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oSerTipo.Id);

                    agregarOperacion = false;
                }
                else
                    oCon.CrearComando("INSERT INTO Servicios_Tipos(Nombre, Id_Servicios_Grupos) VALUES(@nombre, @grupo); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@nombre", oSerTipo.Nombre);
                oCon.AsignarParametroEntero("@grupo", oSerTipo.Id_Servicios_Grupos);

                oCon.ComenzarTransaccion();

                if (oSerTipo.Id == 0)
                    oSerTipo.Id = oCon.EjecutarScalar();
                else
                    oCon.EjecutarComando();

                oCon.ConfirmarTransaccion();

                if (agregarOperacion == true)
                {
                    Partes oParte = new Partes();
                    DataTable dt = oParte.ListarOperaciones();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr["Parte_Fallas"]) == 1)
                        {
                            Partes_Solicitudes oSolicitud = new Partes_Solicitudes();
                            oSolicitud.Id_Servicios_Tipos = oSerTipo.Id;
                            oSolicitud.Id_Partes_Operaciones = Convert.ToInt32(dr["Id"]);
                            oSolicitud.Nombre = dr["Nombre"].ToString();
                            oSolicitud.ConCargo = Convert.ToInt32(dr["ConCargo"]);

                            oSolicitud.Guardar(oSolicitud);

                            if (oSolicitud.Id_Partes_Operaciones == Convert.ToInt32(Partes.Partes_Operaciones.FACTIBILIDAD))
                            {
                                List<String> factibilidades = new List<string>();
                                factibilidades.Add("FACTIBILIDAD POSITIVA");
                                factibilidades.Add("FACTIBILIDAD NEGATIVA");

                                foreach (string factibilidad in factibilidades)
                                {
                                    oPartesSoluciones.Id_Falla = oSolicitud.Id;
                                    oPartesSoluciones.Id_Servicios = oSolicitud.Id_Servicios_Tipos;
                                    oPartesSoluciones.Id_Partes_Operaciones = oSolicitud.Id_Partes_Operaciones;
                                    oPartesSoluciones.Nombre = factibilidad;
                                    oPartesSoluciones.Importe = 0.00;
                                    oPartesSoluciones.Borrado = 0;

                                    oPartesSoluciones.Guardar(oPartesSoluciones);
                                }


                            }
                        }
                    }
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE Servicios_Tipos SET Borrado = 1 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT Servicios_Tipos.Id, Servicios_Tipos.Nombre, Servicios_Grupos.Nombre AS Grupo, Id_Servicios_Grupos, Servicios_Tipos.Borrado FROM Servicios_Tipos LEFT JOIN Servicios_Grupos ON Servicios_Grupos.Id = Id_Servicios_Grupos WHERE Borrado = 0 Order By Servicios_Tipos.Nombre");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }
        public DataRow ListarDatosTipoServicio(int idTipoServivicio)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_tipos.nombre,servicios_tipos.id_servicios_grupos,servicios_grupos.nombre FROM servicios_tipos inner join servicios_grupos on servicios_grupos.id=servicios_tipos.id_servicios_grupos WHERE servicios_tipos.id=@idTipo");
                oCon.AsignarParametroEntero("@idTipo", idTipoServivicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                dr = dt.Rows[0];

            return dr;
        }

        public DataTable ListarIdServicioTipo(int IdServTipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Nombre " +
                    "FROM servicios_tipos " +
                    "WHERE borrado = 0 And Id=@idServicio");
                oCon.AsignarParametroEntero("@idServicio", IdServTipo);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return dt;
        }
    }
}
