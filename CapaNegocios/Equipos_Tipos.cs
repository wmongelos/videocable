using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Equipos_Tipos
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Verificar_Mac { get; set; }
        public Int32 Verificar_Serie { get; set; }
        public Int32 Requiere_Tarjeta { get; set; }
        public Int32 Requiere_Config { get; set; }
        public Int32 Id_Iva_Alicuotas { get; set; }

        public enum REQUIERE_CONFIG
        {
            NO = 0,
            SI = 1
        }

        private Conexion oCon = new Conexion();

        public void Guardar(Equipos_Tipos oEquipo_Tipos, DataTable dtTipoServicios)
        {
            try
            {
                oCon.Conectar();

                if (oEquipo_Tipos.Id > 0)
                {
                    oCon.CrearComando("UPDATE equipos_tipos set Nombre = @nombre, Verificar_Serie=@verificar_serie, Verificar_Mac=@verificar_mac, Requiere_Tarjeta = @tarjeta, Requiere_Config = @config, Id_Iva_Alicuotas = @iva,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oEquipo_Tipos.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO equipos_tipos(Nombre, Verificar_Serie, Verificar_Mac, Requiere_Tarjeta, Requiere_Config, Id_Iva_Alicuotas,id_personal) VALUES(@nombre, @verificar_serie, @verificar_mac, @tarjeta, @config, @iva,@personal); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@nombre", oEquipo_Tipos.Nombre);
                oCon.AsignarParametroEntero("@verificar_serie", oEquipo_Tipos.Verificar_Serie);
                oCon.AsignarParametroEntero("@verificar_mac", oEquipo_Tipos.Verificar_Mac);
                oCon.AsignarParametroEntero("@tarjeta", oEquipo_Tipos.Requiere_Tarjeta);
                oCon.AsignarParametroEntero("@config", oEquipo_Tipos.Requiere_Config);
                oCon.AsignarParametroEntero("@iva", oEquipo_Tipos.Id_Iva_Alicuotas);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.ComenzarTransaccion();

                if (oEquipo_Tipos.Id > 0)
                    oCon.EjecutarComando();
                else
                    oEquipo_Tipos.Id = oCon.EjecutarScalar();

                oCon.CrearComando("DELETE FROM equipos_tipos_servicios WHERE Id_Equipos_Tipos = @id_tipo");
                oCon.AsignarParametroEntero("@id_tipo", oEquipo_Tipos.Id);
                oCon.EjecutarComando();

                foreach (DataRow dr in dtTipoServicios.Rows)
                {
                    oCon.CrearComando(String.Format("INSERT INTO equipos_tipos_servicios(Id_Servicios_Tipos, Id_Equipos_Tipos,id_personal) VALUES({0}, {1},{2})", dr["Id_Servicios_Tipos"], oEquipo_Tipos.Id,Personal.Id_Login));
                    oCon.EjecutarComando();
                }

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
                oCon.CrearComando("SELECT * FROM equipos_tipos WHERE Borrado = 0 ORDER BY Id");
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

        public DataTable ListarCantidadEquiposTipos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * , (SELECT COUNT(*) FROM Equipos WHERE Id_Equipos_Tipos = Equipos_Tipos.Id " +
                    "AND Equipos.Borrado = 0 AND Equipos.Id_Equipos_Estados IN(1)) as total " +
                    "from equipos_tipos " +
                    "where borrado = 0 ORDER BY equipos_tipos.nombre");
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

        public DataTable ListarPorTipoServicios(Int32 idServicios_Tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT equipos_tipos_servicios.Id_Equipos_Tipos ,equipos_tipos.nombre as Nombre,equipos_tipos.Requiere_Tarjeta as Requiere_Tarjeta, Id_Equipos_Tipos as Id  FROM equipos_tipos_servicios" +
                    " inner join equipos_tipos on equipos_tipos.id = equipos_tipos_servicios.Id_Equipos_Tipos" +
                    " WHERE equipos_tipos_servicios.Id_Servicios_Tipos = {0} and equipos_tipos.borrado = 0", idServicios_Tipo));
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

        public DataTable ListarTiposServicios(Int32 idTipoEquipo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                if (idTipoEquipo == 0)
                    oCon.CrearComando("SELECT Id, Id_Servicios_Tipos, Id_Equipos_Tipos, " +
                        "IFNULL((SELECT Nombre From Servicios_Tipos WHERE Id = Id_Servicios_Tipos), '') AS TipoServicio " +
                        "FROM equipos_tipos_servicios");
                else
                    oCon.CrearComando(String.Format("SELECT Id, Id_Servicios_Tipos, Id_Equipos_Tipos, " +
                        "IFNULL((SELECT Nombre From Servicios_Tipos WHERE Id = Id_Servicios_Tipos), '') AS TipoServicio " +
                        "FROM equipos_tipos_servicios WHERE Id_Equipos_Tipos = {0}", idTipoEquipo));

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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE equipos_tipos,id_personal=@personal SET Borrado = 1 WHERE Id = @id");
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

        public DataTable VerificarAsignacionDeEquipos(int IdEquipo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos.id,id_equipos_tipos " +
                    "FROM equipos " +
                    "LEFT JOIN equipos_tipos ON equipos.id_equipos_tipos = equipos_tipos.id " +
                    "WHERE equipos.borrado = 0 and equipos.id_equipos_tipos= @idEqui ");
                oCon.AsignarParametroEntero("@idEqui", IdEquipo);
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


        public void Eliminar_Tipo_Servicios(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("DELETE FROM equipos_tipos_servicios,id_personal=@personal WHERE Id = @id");
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

        public bool VerificarRequerimientoConfig(int idTipoEquipo)
        {
            bool respuesta = false;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select requiere_config from equipos_tipos where id={0}", idTipoEquipo));
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["requiere_config"]) == Convert.ToInt32(REQUIERE_CONFIG.SI))
                    respuesta = true;
                else
                    respuesta = false;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return respuesta;
        }
    }
}
