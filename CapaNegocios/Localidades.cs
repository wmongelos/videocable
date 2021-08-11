using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Localidades
    {
        public Int32 Id { get; set; }
        public Int32 Id_Provincias { get; set; }
        public String Nombre { get; set; }
        public String Abreviatura { get; set; }
        public String Codigo_Postal { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Localidades oLoc)
        {
            try
            {
                oCon.Conectar();

                if (oLoc.Id > 0)
                {
                    oCon.CrearComando("UPDATE localidades set Id_Provincias = @prov, Nombre = @nombre, Abreviatura = @abre, Codigo_Postal = @cp WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oLoc.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO localidades(Id_Provincias, Nombre, Abreviatura, Codigo_Postal) VALUES(@prov, @nombre, @abre, @cp)");

                oCon.AsignarParametroEntero("@prov", oLoc.Id_Provincias);
                oCon.AsignarParametroCadena("@nombre", oLoc.Nombre);
                oCon.AsignarParametroCadena("@abre", oLoc.Abreviatura);
                oCon.AsignarParametroCadena("@cp", oLoc.Codigo_Postal);

                oCon.ComenzarTransaccion();
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE localidades SET Borrado = 1 WHERE Id = @id");
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

        public DataTable Listar(bool conTodas = false)
        {
            oCon.Conectar();
            if (conTodas)
                oCon.CrearComando("SELECT 0 as Id, UPPER('TODAS') as Nombre UNION ALL SELECT Id, Nombre FROM Localidades WHERE borrado = 0 ORDER BY Id");
            else
                oCon.CrearComando("SELECT *, (SELECT Nombre FROM Provincias WHERE Id = Localidades.Id_Provincias) AS Provincia FROM Localidades WHERE Borrado = 0 Order By Nombre");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable Listar_con_calles()
        {
            oCon.Conectar();
            oCon.CrearComando("select * from (select * from localidades where borrado=0)localidades inner join (select id_localidades from localidades_calles where borrado = 0 group by id_localidades)loc_con_calles on localidades.id = loc_con_calles.id_localidades");
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }
        public DataRow TraerDatosLocalidad(int idLocalidad)
        {
            DataRow dr;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre,id_provincias,Abreviatura,Codigo_Postal,borrado from localidades WHERE id=@idLoc");
                oCon.AsignarParametroEntero("@idLoc", idLocalidad);
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
            else
                dr = null;
            return dr;
        }

        public DataTable ListarLocalidad_Zona(int IdLoc)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id_localidad,Id_zona " +
                    "FROM zonas_localidades " +
                    "WHERE id_localidad=@idLocalidad; ");
                oCon.AsignarParametroEntero("@idLocalidad", IdLoc);
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

        public DataTable ListarLocalidadesConZona()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "select localidades.id as id_localidad, localidades.nombre as localidad, zonas_localidades.id_zona from localidades"
                                + " inner join zonas_localidades ON zonas_localidades.id_localidad = localidades.id where localidades.borrado = 0";
                oCon.CrearComando(consulta);
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
