using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Bonificaciones_Aplicacion_Condiciones
    {
        public Int32 Id { get; set; }
        public Int32 Id_Bonificacion_Aplicacion { get; set; }
        public Int32 Id_Item { get; set; }
        public Int32 Nivel { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 Tipo_Condicion { get; set; }
        public Int32 Borrado { get; set; }
        public string Nombre_Item { get; set; }
        public string Tipo_Servicio_Sub { get; set; }
        public string Bonificacion_Nombre { get; set; }
        public string Aplicacion { get; set; }

        public enum NIVEL
        {
            GRUPO = 0,
            TIPO_SERVICIO = 1,
            SERVICIO = 2,
            SUBSERVICIO = 3
        }

        public enum TIPO_CONDICION
        {
            SERVICIOS = 1,
            SUBSERVICIOS = 2,
            EQUIPOS = 3,
            SOLICITUDES = 4
        }

        private Conexion oCon = new Conexion();

        public Int32 Guardar(Bonificaciones_Aplicacion_Condiciones oBonificacionCondicion)
        {
            try
            {
                oCon.Conectar();
                if (oBonificacionCondicion.Id > 0)
                {
                    oCon.CrearComando("UPDATE bonificaciones_aplicacion_condiciones SET cantidad=@cantidad,id_personal=@personal where id=@id; SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@cantidad", oBonificacionCondicion.Cantidad);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oBonificacionCondicion.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO bonificaciones_aplicacion_condiciones(id_bonificacion_aplicacion, id_item, nivel, cantidad, tipo_condicion, nombre_item, tipo_servicio_sub,id_personal) values(@id_bonificacion_aplicacion, @id_item, @nivel, @cantidad, @tipo_condicion, @nombre_item, @tipo_servicio_sub,@personal); SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@id_bonificacion_aplicacion", oBonificacionCondicion.Id_Bonificacion_Aplicacion);
                    oCon.AsignarParametroEntero("@id_item", oBonificacionCondicion.Id_Item);
                    oCon.AsignarParametroEntero("@nivel", oBonificacionCondicion.Nivel);
                    oCon.AsignarParametroEntero("@cantidad", oBonificacionCondicion.Cantidad);
                    oCon.AsignarParametroEntero("@tipo_condicion", oBonificacionCondicion.Tipo_Condicion);
                    oCon.AsignarParametroCadena("@nombre_item", oBonificacionCondicion.Nombre_Item);
                    oCon.AsignarParametroCadena("@tipo_servicio_sub", oBonificacionCondicion.Tipo_Servicio_Sub);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                }




                oCon.ComenzarTransaccion();
                oBonificacionCondicion.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
            return oBonificacionCondicion.Id;
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE bonificaciones_aplicacion_condiciones SET Borrado = 1,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public DataTable ListarPorIdBonificacionAplicacion(int Id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id, id_bonificacion_aplicacion,nivel, id_item,cantidad, CASE WHEN tipo_condicion=1 THEN 'Servicio' WHEN tipo_condicion=2 THEN 'Sub servicios' WHEN tipo_condicion=3 THEN 'Equipo' WHEN tipo_condicion=4 THEN 'Solicitud' END as tipo_condicion_texto, CASE WHEN nivel=0 THEN 'Grupo' WHEN nivel=1 THEN 'Tipo de servicio' WHEN nivel=2 THEN 'Servicio' WHEN nivel=3 THEN 'Sub servicio' END as nivel_texto, nombre_item, tipo_condicion, tipo_servicio_sub from bonificaciones_aplicacion_condiciones where id_bonificacion_aplicacion={0} and borrado=0", Id));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }
    }
}
