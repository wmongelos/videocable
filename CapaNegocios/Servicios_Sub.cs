using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Sub
    {
        public Int32 Id { get; set; }
        public Int32 Id_Servicios { get; set; }
        public String Descripcion { get; set; }
        public Int32 Requiere_IP { get; set; }
        public Int32 Valor_Defecto { get; set; }
        public Int32 Id_Servicios_Sub_Tipos { get; set; }
        public Int32 Id_Iva_Alicuotas { get; set; }

        private Conexion oCon = new Conexion();

        public enum SERVICIO_SUB_TIPOS
        {
            SUBSERVICIO = 1,
            MANTENIMIENTO = 2,
            COSTO_ADICIONAL = 3,
            DERECHO_DE_CONEXION = 4
        }

        public void Guardar(Servicios_Sub oSub, int id_personal)
        {
            try
            {
                oCon.Conectar();
                if (oSub.Id == 0)
                {
                    oCon.CrearComando("INSERT INTO servicios_sub(Id_Servicios, Id_Servicios_sub_tipos, Descripcion, Requiere_IP, Valor_Defecto, Id_Iva_Alicuotas,id_personal) " +
                        "VALUES(@id_servicio, @tipo, @descrip, @requiereip, @valordefecto, @iva, @personal); SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@id_servicio", oSub.Id_Servicios);

                }
                else
                {
                    oCon.CrearComando("Update servicios_sub set Descripcion=@descrip, Id_Servicios_sub_tipos=@tipo, Requiere_IP=@requiereip, Valor_Defecto=@valordefecto, Id_Iva_Alicuotas = @iva, Id_Personal=@personal where Id=@id");
                    oCon.AsignarParametroEntero("@id", oSub.Id);
                }


                oCon.AsignarParametroEntero("@tipo", oSub.Id_Servicios_Sub_Tipos);
                oCon.AsignarParametroCadena("@descrip", oSub.Descripcion);
                oCon.AsignarParametroEntero("@requiereip", oSub.Requiere_IP);
                oCon.AsignarParametroEntero("@valordefecto", oSub.Valor_Defecto);
                oCon.AsignarParametroEntero("@iva", oSub.Id_Iva_Alicuotas);
                oCon.AsignarParametroEntero("@personal", id_personal);

                if (oSub.Id > 0)
                    oCon.EjecutarComando();
                else
                    oSub.Id = oCon.EjecutarScalar();

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
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *, IF(Requiere_IP = 0, 'NO', 'SI') AS IP FROM servicios_sub Where servicios_sub.Borrado = 0 ORDER BY Id");
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

        public DataTable Listar(int id_tipo_facturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *, IF(Requiere_IP = 0, 'NO', 'SI') AS IP FROM servicios_sub " +
                    "where id_servicios in (select id_servicios from tipo_facturacion_servicios where id_tipo_facturacion = @idtipo) " +
                    "and id in (Select Id_servicios_sub from tipo_facturacion_servicios where id_tipo_facturacion = @idtipofac) and servicios_sub.Borrado = 0 ORDER BY Id");

                oCon.AsignarParametroEntero("@idtipo", id_tipo_facturacion);
                oCon.AsignarParametroEntero("@idtipofac", id_tipo_facturacion);
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

        public DataTable ListarTipos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_sub_tipos ORDER BY Id");
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

        public DataTable ListarPorServicio(Int32 Id_Servicio)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_sub WHERE Id_Servicios = @idservicio and servicios_sub.Borrado = 0 ORDER BY Id");
                oCon.AsignarParametroEntero("@idservicio", Id_Servicio);
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

        public void EliminarSubSer(Int32 id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE servicios_sub SET Borrado = 1 where Id = @id");
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.CrearComando("DELETE FROM zonas_servicios WHERE Id_Servicios_Sub = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public DataTable Verificar_Servicio_Editar(Int32 Id_Servicio, Int32 id_subservicio)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_sub WHERE Id_Servicios = @idservicio and Id!=@idsubservicio");
                oCon.AsignarParametroEntero("@idservicio", Id_Servicio);
                oCon.AsignarParametroEntero("@idsubservicio", id_subservicio);
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

        public int VerificarEliminar(int idServicioSub)
        {
            //verifica que un subservicio esta activo en algun usuario
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            int resultado = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id_usuarios_servicios FROM usuarios_servicios_sub where id_servicios_sub=@idserviciosub and borrado=0");
                oCon.AsignarParametroEntero("@idserviciosub", idServicioSub);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            int cont = 0, idEstado;
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    oCon.Conectar();
                    int idUsuarioServicio = Convert.ToInt32(item["id_usuarios_servicios"]);
                    oCon.CrearComando("SELECT id,id_servicios_estados FROM usuarios_servicios where id=@idusuariosservicios");
                    oCon.AsignarParametroEntero("@idusuariosservicios", idUsuarioServicio);
                    dt1 = oCon.Tabla();
                    oCon.DesConectar();
                    idEstado = Convert.ToInt32(dt1.Rows[0]["id_servicios_estados"]);
                    if (idEstado <= 3)
                        cont++;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            if (cont == 0)
                resultado = 0;
            else
                resultado = 1;

            return resultado;
        }

        public DataRow TraerDatosSubServicio(int idSub)
        {
            DataRow dr;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,Id_Servicios,Id_Servicios_Sub_Tipos,Descripcion,Requiere_IP,Valor_Defecto,Id_Iva_Alicuotas,Borrado FROM servicios_sub WHERE id=@id");
                oCon.AsignarParametroEntero("@id", idSub);
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

        public DataTable ListarServiciosSubCASS(int ID_Aplicacion_Externa)
        {

            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios.id AS Id_Serv, servicios_Sub.id AS Id_serv_Sub, id_servicios_sub_tipos AS id_serv_sub_tipos, " +
                    "CONCAT(servicios.Descripcion, ' - ', servicios_sub.Descripcion) AS Servicio, servicios_sub.Descripcion as Sub_servicio " +
                    "FROM servicios_sub " +
                    "LEFT JOIN servicios ON servicios_sub.Id_Servicios = servicios.id " +
                    "WHERE servicios.borrado = 0 AND servicios_sub.borrado = 0 " +
                    "AND(servicios.Id_Aplicaciones_Externas=@idAplicacion); ");
                oCon.AsignarParametroEntero("@idAplicacion", ID_Aplicacion_Externa);
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
