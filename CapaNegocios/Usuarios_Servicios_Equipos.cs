using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Servicios_Equipos
    {
        private Conexion oCon = new Conexion();

        public DataTable Listar(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "SELECT usuarios_servicios_equipos.id as id_usuario_serv_equipo, usuarios_servicios_equipos.id_equipo, usuarios_servicios_equipos.id_usuario,"
                               + " usuarios_servicios_equipos.id_usuario_locacion, equipos.serie, equipos.mac, equipos_estados.id as id_equipo_estado, equipos_estados.nombre as equipo_estado,"
                               + " equipos_marcas.id as id_equipo_marca, equipos_marcas.nombre as equipo_marca, equipos_modelos.id as id_equipo_modelo, equipos_modelos.nombre as equipo_modelo,"
                               + " equipos_tipos.id as id_equipo_tipo, equipos_tipos.nombre as equipo_tipo, ifnull(equipos_tarjetas.id, 0) as id_tarjeta, ifnull(equipos_tarjetas.Numero, '') as numero_tarjeta"
                               + " FROM usuarios_servicios_equipos"
                               + " LEFT JOIN equipos ON equipos.id = usuarios_servicios_equipos.id_equipo"
                               + " LEFT JOIN equipos_estados ON equipos_estados.id = equipos.id_equipos_estados"
                               + " LEFT JOIN equipos_marcas ON equipos_marcas.id = equipos.id_equipos_marcas"
                               + " LEFT JOIN equipos_modelos ON equipos_modelos.id = equipos.id_equipos_modelos"
                               + " LEFT JOIN equipos_tipos ON equipos_tipos.id = equipos.id_equipos_tipos"             
                               + " LEFT JOIN equipos_tarjetas ON equipos_tarjetas.Id = equipos.Id_tarjeta"
                               + " WHERE id_usuario_servicio = @idUsuarioServicio AND usuarios_servicios_equipos.borrado = 0";
                oCon.CrearComando(consulta);
                oCon.AsignarParametroEntero("@idUsuarioServicio", idUsuarioServicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    }
}
