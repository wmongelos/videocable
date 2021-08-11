using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Categorias
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int16 Genera_Punitorio { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Servicios_Categorias oCat)
        {
            try
            {
                oCon.Conectar();

                if (oCat.Id > 0)
                {
                    oCon.CrearComando("UPDATE servicios_categorias set Nombre = @nombre, genera_punitorio = @generapuni WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oCat.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO servicios_categorias(Nombre, genera_punitorio) VALUES(@nombre, @generapuni)");

                oCon.AsignarParametroCadena("@nombre", oCat.Nombre);
                oCon.AsignarParametroEntero("@generapuni", oCat.Genera_Punitorio);

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
                oCon.CrearComando("UPDATE servicios_categorias SET Borrado = 1 WHERE Id = @id");
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
            oCon.CrearComando("SELECT *, IF(genera_punitorio = 1, upper('SI'), upper('NO')) AS generapun FROM servicios_categorias WHERE Borrado = 0 Order By Id");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public void EliminarServicios(int idcategoria, int idservicio)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("DELETE FROM tipo_facturacion_servicios WHERE Id_Servicios = @idser AND id_tipo_facturacion = @idcat");
                oCon.AsignarParametroEntero("@idser", idservicio);
                oCon.AsignarParametroEntero("@idcat", idcategoria);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ListarParametrosDetallesAppExt(int id_Parametro, int id_App_Ext)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_categorias.id AS id_Cat, aplicaciones_externas_parametros.id AS id_parametro, aplicaciones_externas_parametros_det.id AS id_parametro_det, " +
                    "servicios_categorias.nombre AS Categoria, aplicaciones_externas_parametros.nombre AS ParametroGIES, " +
                    "aplicaciones_externas_parametros.nombre_externo AS ParametroCASS, aplicaciones_externas_parametros.detalle AS Detalle, " +
                    "aplicaciones_externas_parametros_det.valor " +
                    "FROM aplicaciones_externas_parametros_det " +
                    "LEFT JOIN aplicaciones_externas_parametros ON aplicaciones_externas_parametros.id = aplicaciones_externas_parametros_det.id_aplicaciones_externas_parametros " +
                    "LEFT JOIN servicios_categorias ON servicios_categorias.id = aplicaciones_externas_parametros_det.id_tipo_facturacion " +
                    "WHERE aplicaciones_externas_parametros_det.borrado = 0 AND aplicaciones_externas_parametros.borrado = 0 AND servicios_categorias.borrado = 0 " +
                    "AND aplicaciones_externas_parametros.Id = @idParametro AND aplicaciones_externas_parametros.id_aplicaciones_externas = @idAppExt " +
                    "UNION all " +
                    "SELECT servicios_categorias.id as id_Cat, 0, 0, " +
                    "servicios_categorias.nombre AS Categoria, '-', " +
                    "'-', '-', 0 " +
                    "from servicios_categorias " +
                    "WHERE servicios_categorias.borrado = 0 and servicios_categorias.id not in (Select id_tipo_facturacion from aplicaciones_externas_parametros_det where aplicaciones_externas_parametros_det.id_aplicaciones_externas_parametros = @id_Par_ext)");
                oCon.AsignarParametroEntero("@idParametro", id_Parametro);
                oCon.AsignarParametroEntero("@idAppExt", id_App_Ext);
                oCon.AsignarParametroEntero("@id_Par_ext", id_Parametro);
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
