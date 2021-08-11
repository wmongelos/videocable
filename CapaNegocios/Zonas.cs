using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Zonas
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrad { get; set; }
        public Int32 Id_Zona { get; set; }
        public Int32 Id_Localidades { get; set; }
        public Int32 Id_Servicios { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Zonas oZona, DataTable dtLocalidades)
        {
            try
            {
                oCon.Conectar();

                if (oZona.Id > 0)
                {
                    oCon.CrearComando("UPDATE Zonas SET Nombre = @nombre WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oZona.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO ZONAS(Nombre) VALUES(@nombre); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@nombre", oZona.Nombre.ToUpper());

                if (oZona.Id > 0)
                    oCon.EjecutarComando();
                else
                    oZona.Id = oCon.EjecutarScalar();


                oCon.CrearComando("DELETE FROM Zonas_Localidades WHERE Id_Zona = @id");
                oCon.AsignarParametroEntero("@id", oZona.Id);
                oCon.EjecutarComando();

                foreach (DataRow dr in dtLocalidades.Rows)
                {
                    if (Convert.ToInt32(dr["Id_Zona"]) == 0 || Convert.ToInt32(dr["Id_Zona"]) == oZona.Id)
                    {
                        oCon.CrearComando("INSERT INTO Zonas_Localidades(Id_Zona, Id_Localidad) VALUES(@id, @loca)");
                        oCon.AsignarParametroEntero("@id", oZona.Id);
                        oCon.AsignarParametroEntero("@loca", Convert.ToInt32(dr["Id_Localidad"]));
                        oCon.EjecutarComando();
                    }
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

        }

        public DataTable Listar(bool conTodas = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (conTodas)
                    oCon.CrearComando("SELECT 0 as ID, UPPER('TODAS') as Nombre UNION ALL SELECT Id, nombre FROM Zonas WHERE Borrado = 0 ORDER BY Id");
                else
                    oCon.CrearComando("SELECT * FROM Zonas WHERE Borrado = 0 ORDER BY Id");

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

        public DataTable ListarLocZonas(Int32 idZona)
        {
            oCon.Conectar();

            if (idZona == 0)
                oCon.CrearComando("select *, (select nombre from localidades where id = zonas_localidades.id_localidad) as Localidad, (select codigo_postal from localidades where id = zonas_localidades.id_localidad) as CP from zonas_localidades order by Localidad");
            else
                oCon.CrearComando(String.Format("select *, (select nombre from localidades where id = zonas_localidades.id_localidad) as Localidad, (select codigo_postal from localidades where id = zonas_localidades.id_localidad) as CP from zonas_localidades where id_zona = {0} order by Localidad", idZona));

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public void Eliminar(Int32 id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE zonas SET Borrado = 1 WHERE Id = @id");
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

        public void Eliminar_Localidad(Int32 id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("DELETE FROM zonas_localidades WHERE Id = @id");
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

        public DataTable ListarParametrosAppExtDet(int id_Parametro, int id_App_Ext)
        {
            DataTable dt;
            oCon.Conectar();
            oCon.CrearComando("SELECT zonas.id AS id_Zona, aplicaciones_externas_parametros.id AS id_parametro, aplicaciones_externas_parametros_det.id AS id_parametro_det, " +
                "zonas.nombre AS Zona, aplicaciones_externas_parametros.nombre AS ParametroGIES, " +
                "aplicaciones_externas_parametros.nombre_externo AS ParametroCASS, aplicaciones_externas_parametros.detalle AS Detalle, " +
                "aplicaciones_externas_parametros_det.valor " +
                "FROM aplicaciones_externas_parametros_det " +
                "LEFT JOIN aplicaciones_externas_parametros ON aplicaciones_externas_parametros.id = aplicaciones_externas_parametros_det.id_aplicaciones_externas_parametros " +
                "LEFT JOIN zonas ON zonas.id = aplicaciones_externas_parametros_det.id_tipo_facturacion " +
                "WHERE aplicaciones_externas_parametros_det.borrado = 0 AND aplicaciones_externas_parametros.borrado = 0 AND zonas.borrado = 0 " +
                "AND aplicaciones_externas_parametros.Id = @idPar AND aplicaciones_externas_parametros.id_aplicaciones_externas = @idAppExt " +
                "UNION all " +
                "SELECT Zonas.id as id_Zona, 0, 0, " +
                "zonas.nombre AS Zona, '-', '-', '-', 0 " +
                "from zonas " +
                "WHERE zonas.borrado = 0 and zonas.id not in (Select id_tipo_facturacion from aplicaciones_externas_parametros_det where aplicaciones_externas_parametros_det.id_aplicaciones_externas_parametros = @id_Par_ext)");
            oCon.AsignarParametroEntero("@idPar", id_Parametro);
            oCon.AsignarParametroEntero("@idAppExt", id_App_Ext);
            oCon.AsignarParametroEntero("@id_Par_ext", id_Parametro);
            dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }
    }
}
