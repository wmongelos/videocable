using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class AplicacionesExternas
    {
        #region

        public int Id_App;
        public string Nombre_App;
        public string StringConexion;
        public int Id_Tipo_Servicio;
        public int id_Partes_Fallas;
        public int Id_Partes_Operaciones;
        public string Nombre_Falla;
        public string Tipo;
        public string Ejecutable;
        public string Parametros;
        public int Requiere_relacion;
        private Conexion oCon = new Conexion();
        public enum VALORES_TIPO
        {
            INT =1,
            STRING = 2,
            DECIMAL = 3,
            BOOLEAN = 4
        }

        public enum Aplicacion_Externa
        {
            ISP = 1,
            CASS = 2
        }

        #endregion

        public void Eliminar(AplicacionesExternas oAplicaion_Externa)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE AplicacionesExternas SET borrado=1,id_personal=@id_personal WHERE id=@id");
                oCon.AsignarParametroEntero("@id_personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", oAplicaion_Externa.Id_App);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Guardar(AplicacionesExternas oAplicaion_Externa)
        {
            int id = 0;
            try
            {
                oCon.Conectar();
                if (oAplicaion_Externa.Id_App != 0)
                {
                    oCon.CrearComando("UPDATE AplicacionesExternas SET nombre=@nombre,string_conexion=@stringConexion, parametros=@parameter, requiere_relacion=@requiere,id_personal=@personal WHERE id=@id; ");
                    oCon.AsignarParametroEntero("@id", oAplicaion_Externa.Id_App);

                    id = oAplicaion_Externa.Id_App;
                }
                else
                {
                    oCon.CrearComando("INSERT INTO AplicacionesExternas (nombre,string_conexion, parametros, requiere_relacion,id_personal) VALUES (@nombre,@stringConexion, @parameter,@requiere,@personal); SELECT @@IDENTITY");
                }
                oCon.AsignarParametroCadena("@nombre", oAplicaion_Externa.Nombre_App);
                oCon.AsignarParametroCadena("@stringConexion", oAplicaion_Externa.StringConexion);
                oCon.AsignarParametroCadena("@parameter", oAplicaion_Externa.Parametros);
                oCon.AsignarParametroEntero("@requiere", oAplicaion_Externa.Requiere_relacion);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                if (oAplicaion_Externa.Id_App > 0)
                    oCon.EjecutarComando();
                else
                    id = oCon.EjecutarScalar();


                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

                int v = 4;
            }
            return id;
        }

        public int Guardar_Acciones(AplicacionesExternas oAplicaion_Externa, string accion)
        {
            int id = 0;

            oCon.Conectar();
            if (accion == "editar")
            {
                oCon.CrearComando("UPDATE AplicacionesExternas_acciones SET id_servicios_tipos=@id_servicios_tipos,nombre=@nombre,id_partes_operaciones=@id_parte_operaciones,id_partes_fallas=@id_parte_fallas,tipo=@tipo,ejecutable=@ejecutable, borrado=0 WHERE id_app=@id_app");
            }
            else
            {
                oCon.CrearComando("INSERT INTO AplicacionesExternas_acciones (id_app,id_servicios_tipos,nombre,id_partes_operaciones,id_partes_fallas,tipo,ejecutable,borrado) VALUES (@id_app,@id_servicios_tipos,@nombre,@id_parte_operaciones,@id_parte_fallas,@tipo,@ejecutable,0)");
            }
            oCon.AsignarParametroEntero("@id_app", oAplicaion_Externa.Id_App);
            oCon.AsignarParametroEntero("@id_servicios_tipos", oAplicaion_Externa.Id_Tipo_Servicio);
            oCon.AsignarParametroCadena("@nombre", oAplicaion_Externa.Nombre_App);
            oCon.AsignarParametroEntero("@id_parte_operaciones", oAplicaion_Externa.Id_Partes_Operaciones);
            oCon.AsignarParametroEntero("@id_parte_fallas", oAplicaion_Externa.id_Partes_Fallas);
            oCon.AsignarParametroCadena("@tipo", oAplicaion_Externa.Tipo);
            oCon.AsignarParametroCadena("@ejecutable", oAplicaion_Externa.Ejecutable);
            oCon.EjecutarComando();
            oCon.DesConectar();

            return id;
        }

        public void GuardarServiciosCompatibilidad(Int32 Id_Aplicacion_Externa, DataTable dt)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("DELETE FROM AplicacionesExternas_Relacion WHERE Id_AplicacionesExternas = {0}", Id_Aplicacion_Externa));
                oCon.EjecutarComando();

                foreach (DataRow dr in dt.Rows)
                {
                    oCon.CrearComando("INSERT INTO AplicacionesExternas_Relacion(Id_AplicacionesExternas, Id_Servicios, Id_Servicios_Sub, Relacion) " +
                        "VALUES(@externa, @servicio, @subservicio, @compatibilidad)");
                    oCon.AsignarParametroEntero("@externa", Id_Aplicacion_Externa);
                    oCon.AsignarParametroEntero("@servicio", Convert.ToInt32(dr["Id_Servicios"]));
                    oCon.AsignarParametroEntero("@subservicio", Convert.ToInt32(dr["Id_Servicios_Sub"]));
                    oCon.AsignarParametroCadena("@compatibilidad", dr["compatibilidad"].ToString());
                    oCon.EjecutarComando();
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteAplicacion(int id_App)
        {
            bool existe = false;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id_app FROM AplicacionesExternas_acciones WHERE id_app=@id_app");
                oCon.AsignarParametroEntero("@id_app", id_App);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            if (dt.Rows.Count > 0)
            {
                existe = true;
            }
            return existe;
        }

        public bool ProbrarConexion(string DatosConexion)
        {
            bool Conectado = false;
            ConexionesExternas oConexioPrueba = new ConexionesExternas();
            oConexioPrueba.conexionString = DatosConexion;
            try
            {
                oConexioPrueba.Conectar();
                Conectado = true;
            }
            catch (Exception)
            {

            }

            oConexioPrueba.Desconectar();
            return Conectado;
        }

        public void Eliminar_Acciones(int id_app)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE AplicacionesExternas_acciones SET borrado=1 WHERE id_app=@id");
                oCon.AsignarParametroEntero("@id", id_app);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ListarAplicacionesEjecutables(int id = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (id > 0)
                {
                    oCon.CrearComando("SELECT * FROM AplicacionesExternas_acciones WHERE id=@id_app");
                    oCon.AsignarParametroEntero("@id_app", id);
                }
                else
                {
                    oCon.CrearComando("SELECT * FROM AplicacionesExternas_acciones WHERE borrado=0");

                }
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable Listar(int idAplicacionExterna = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "";
                if (idAplicacionExterna == 0)
                {
                    comando = "SELECT * FROM AplicacionesExternas WHERE borrado=0";
                    oCon.CrearComando(comando);

                }
                else
                {

                    comando = "SELECT * FROM AplicacionesExternas WHERE borrado=0 and id=@idApp";
                    oCon.CrearComando(comando);
                    oCon.AsignarParametroEntero("@idApp", idAplicacionExterna);
                }
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }
        public DataTable ListarExternasConRelacion(int idAplicacionExterna = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "";
                if (idAplicacionExterna == 0)
                {
                    comando = "SELECT * FROM AplicacionesExternas WHERE borrado=0 and requiere_relacion=1";
                    oCon.CrearComando(comando);

                }
                else
                {

                    comando = "SELECT * FROM AplicacionesExternas WHERE borrado=0 and id=@idApp";
                    oCon.CrearComando(comando);
                    oCon.AsignarParametroEntero("@idApp", idAplicacionExterna);
                }
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }


        public DataTable ListarServicios(Int32 Id_AplicacionesExternas)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT S.Descripcion AS Servicio, Servicios_Sub.Descripcion AS SubServicios, " +
                    "IFNULL((SELECT Relacion FROM AplicacionesExternas_Relacion WHERE AplicacionesExternas_Relacion.Id_AplicacionesExternas = {0} " +
                    "AND AplicacionesExternas_Relacion.Id_Servicios = Servicios_Sub.Id_Servicios AND AplicacionesExternas_Relacion.Id_Servicios_Sub = Servicios_Sub.Id), '') " +
                    "AS Compatibilidad, Servicios_Sub.Id_Servicios, Servicios_Sub.Id AS Id_Servicios_Sub  FROM Servicios_Sub LEFT JOIN Servicios AS S ON S.Id = Servicios_Sub.Id_Servicios WHERE S.Id_AplicacionesExternas = {0} ", Id_AplicacionesExternas));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public int GuardarUsuarioProducto(int idUsuario, int idUsuarioLocacion, int idProducto, int idCuentaAcceso, int idUsuarioExterno, int idLocacionExterna, int idPersonal)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_servicios_externos (id_usuario,id_usuario_locacion,id_producto,id_cuenta_acceso,id_usuario_externo,id_locacion_externa,id_personal_creado,fecha_creado) VALUES (@id_usu,@id_usu_loc,@id_prod,@id_acceso,@id_usu_ext,@id_loc_ext,@id_personal,@fecha)");
                oCon.AsignarParametroEntero("@id_usu", idUsuario);
                oCon.AsignarParametroEntero("@id_usu_loc", idUsuarioLocacion);
                oCon.AsignarParametroEntero("@id_prod", idProducto);
                oCon.AsignarParametroEntero("@id_acceso", idCuentaAcceso);
                oCon.AsignarParametroEntero("@id_usu_ext", idUsuarioExterno);
                oCon.AsignarParametroEntero("@id_loc_ext", idLocacionExterna);
                oCon.AsignarParametroEntero("@id_personal", idPersonal);
                oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
            return 0;
        }

        public int CambiarProducto(int idCuentaAcceso, int idProductoNuevo, int idProductoViejo)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_servicios_externos set id_producto=@id_prod_nuevo, id_producto_aux=@id_prod_viejo where id_cuenta_acceso=@id_cuenta");
                oCon.AsignarParametroEntero("@id_cuenta", idCuentaAcceso);
                oCon.AsignarParametroEntero("@id_prod_nuevo", idProductoNuevo);
                oCon.AsignarParametroEntero("@id_prod_viejo", idProductoViejo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                retorno = -1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return retorno;
        }

        public DataTable ListarDatosCuentaAcceso(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,id_usuario,id_usuario_locacion,id_producto,id_producto_aux,id_cuenta_acceso,id_usuario_externo,id_locacion_externa from usuarios_servicios_externos where id_cuenta_acceso=@id");
                oCon.AsignarParametroEntero("@id", id);
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

        public void EliminarRelacion(int id_relacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE Cass SET borrado=1 WHERE id=@id_relacion");
                oCon.AsignarParametroEntero("@id_relacion", id_relacion);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable ListarParametros(int id_app_externa)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT AplicacionesExternas.id as id_ap_externa, AplicacionesExternas_parametros.id as id_ap_ext_parametro,  " +
                    "AplicacionesExternas.nombre as aplicacion_externa, AplicacionesExternas.string_conexion as conexion, " +
                    "AplicacionesExternas_parametros.nombre as prametro_gies, AplicacionesExternas_parametros.nombre_externo as prametro_aplicacion_externa, " +
                    "AplicacionesExternas_parametros.detalle as detalle_gies, AplicacionesExternas_parametros.valor AS Valor, " +
                    "AplicacionesExternas_parametros.valor_tipo AS tipoValor " +
                    "FROM AplicacionesExternas_parametros " +
                    "LEFT JOIN AplicacionesExternas ON AplicacionesExternas_parametros.id_AplicacionesExternas = AplicacionesExternas.id " +
                    "WHERE AplicacionesExternas_parametros.borrado = 0 AND AplicacionesExternas.borrado = 0 AND AplicacionesExternas_parametros.id_AplicacionesExternas = @id; ");
                oCon.AsignarParametroEntero("@id", id_app_externa);
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

        public void GuardarParametros(int id_App_Ext, string Parametro, string Parametro_Externo, string Detalle, string Valor, int Valor_Tipo, int id_Registro)
        {
            try
            {
                oCon.Conectar();
                if (id_Registro > 0)
                {
                    oCon.CrearComando("UPDATE AplicacionesExternas_parametros SET id_AplicacionesExternas = @id_app_ext, detalle = @det, " +
                        "valor = @valor, valor_tipo = @valor_Tipo WHERE Id = @id");
                }
                else 
                { 
                    
                    oCon.CrearComando("INSERT INTO AplicacionesExternas_parametros(id_AplicacionesExternas,nombre,nombre_externo,detalle, valor, valor_tipo) VALUES (@id_app_ext,@nombre,@nombre_ext,@det, @valor, @valor_Tipo)");
                    oCon.AsignarParametroCadena("@nombre", Parametro);
                    oCon.AsignarParametroCadena("@nombre_ext", Parametro_Externo);
                }
                oCon.AsignarParametroEntero("@id_app_ext", id_App_Ext);
                oCon.AsignarParametroCadena("@det", Detalle);
                oCon.AsignarParametroCadena("@valor", Valor);
                oCon.AsignarParametroEntero("@valor_Tipo", Valor_Tipo);
                if(id_Registro > 0)
                    oCon.AsignarParametroEntero("@id", id_Registro);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                string error = c.ToString();
                throw;
            }
        }

        public void EliminarParametros(int id_Parametro)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE AplicacionesExternas_parametros SET borrado=1 WHERE id=@id_parametro");
                oCon.AsignarParametroEntero("@id_parametro", id_Parametro);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }

}
